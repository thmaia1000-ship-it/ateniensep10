/**
 * Master Escolar Ateniense - Frontend Application Logic
 */

const App = {
  user: null,
  token: null,
  currentView: 'dashboard',
  selectedAlunoId: null,
  cart: [],

  init() {
    this.token = localStorage.getItem('ateniense_token');
    const userStr = localStorage.getItem('ateniense_user');
    if (this.token && userStr) {
      try {
        this.user = JSON.parse(userStr);
        this.showApp();
      } catch (e) {
        this.showLogin();
      }
    } else {
      this.showLogin();
    }

    this.bindEvents();
  },

  async api(endpoint, method = 'GET', data = null) {
    const headers = { 'Content-Type': 'application/json' };
    if (this.token) {
      headers['Authorization'] = `Bearer ${this.token}`;
    }
    const options = { method, headers };
    if (data && method !== 'GET') {
      options.body = JSON.stringify(data);
    }
    try {
      const response = await fetch(endpoint, options);
      if (response.status === 401) {
        this.logout();
        throw new Error('Sessão expirada. Faça login novamente.');
      }
      return await response.json();
    } catch (err) {
      console.error(`Erro na requisição ${endpoint}:`, err);
      throw err;
    }
  },

  bindEvents() {
    // Formulário de Login
    const loginForm = document.getElementById('loginForm');
    if (loginForm) {
      loginForm.addEventListener('submit', async (e) => {
        e.preventDefault();
        const u = document.getElementById('loginUser').value;
        const p = document.getElementById('loginPass').value;
        const errDiv = document.getElementById('loginError');
        errDiv.classList.add('d-none');
        try {
          const res = await this.api('/api/auth/login', 'POST', { username: u, password: p });
          if (res.token) {
            this.token = res.token;
            this.user = res;
            localStorage.setItem('ateniense_token', this.token);
            localStorage.setItem('ateniense_user', JSON.stringify(this.user));
            this.showApp();
          } else {
            errDiv.innerText = res.error || 'Credenciais inválidas';
            errDiv.classList.remove('d-none');
          }
        } catch (e) {
          errDiv.innerText = e.message || 'Erro ao conectar ao servidor';
          errDiv.classList.remove('d-none');
        }
      });
    }

    // Toggle menu dropdowns
    document.querySelectorAll('.sidebar-nav .has-sub > a').forEach(el => {
      el.addEventListener('click', (e) => {
        e.preventDefault();
        const parent = el.closest('.has-sub');
        const sub = parent.querySelector('.nav-submenu');
        if (sub) {
          sub.classList.toggle('show');
        }
      });
    });

    // Links de navegação
    document.querySelectorAll('[data-view]').forEach(el => {
      el.addEventListener('click', (e) => {
        e.preventDefault();
        const view = el.getAttribute('data-view');
        this.navigate(view);
      });
    });

    // Logout
    const btnLogout = document.getElementById('btnLogout');
    if (btnLogout) {
      btnLogout.addEventListener('click', () => this.logout());
    }
  },

  showLogin() {
    document.getElementById('loginScreen').classList.remove('d-none');
    document.getElementById('appScreen').classList.add('d-none');
  },

  showApp() {
    document.getElementById('loginScreen').classList.add('d-none');
    document.getElementById('appScreen').classList.remove('d-none');
    
    // Atualiza dados do usuário na barra
    if (this.user) {
      document.getElementById('userNameBadge').innerText = this.user.nome || this.user.username;
      document.getElementById('userNivelBadge').innerText = `Nível ${this.user.nivel}`;
      document.getElementById('userAvatarLetter').innerText = (this.user.nome || this.user.username)[0].toUpperCase();
    }
    
    this.navigate('dashboard');
  },

  logout() {
    if (this.token) {
      this.api('/api/auth/logout', 'POST', { token: this.token }).catch(() => {});
    }
    this.token = null;
    this.user = null;
    localStorage.removeItem('ateniense_token');
    localStorage.removeItem('ateniense_user');
    this.showLogin();
  },

  async navigate(view) {
    this.currentView = view;
    
    // Atualiza links ativos
    document.querySelectorAll('[data-view]').forEach(el => {
      el.classList.toggle('active', el.getAttribute('data-view') === view);
    });

    // Oculta todas as views e exibe a selecionada
    document.querySelectorAll('.view-content').forEach(el => el.classList.add('d-none'));
    const target = document.getElementById(`view-${view}`);
    if (target) {
      target.classList.remove('d-none');
    }

    // Carrega dados da view correspondente
    switch (view) {
      case 'dashboard':
        await this.loadDashboard();
        break;
      case 'secretaria-nova-matricula':
        await this.initNovaMatricula();
        break;
      case 'secretaria-consultar':
        await this.loadAlunos();
        break;
      case 'secretaria-cursos':
        await this.loadSecretariaCursos();
        break;
      case 'secretaria-turmas':
        await this.loadTurmas();
        break;
      case 'secretaria-professores':
        await this.loadProfessores();
        break;
      case 'secretaria-declaracoes':
        await this.setupDeclaracoes();
        break;
      case 'secretaria-contratos':
        await this.setupContratos();
        break;
      case 'secretaria-resp-acad':
        await this.loadResponsaveis('academico');
        break;
      case 'secretaria-resp-fin':
        await this.loadResponsaveis('financeiro');
        break;
      case 'financeiro-caixa':
        await this.loadCaixa();
        break;
      case 'financeiro-mensalidades':
        await this.loadMensalidades();
        break;
      case 'financeiro-tabela-mensalidades':
        await this.loadTabelaMensalidades();
        break;
      case 'academico-boletim':
        await this.setupBoletim();
        break;
      case 'academico-diario':
        await this.loadDiario();
        break;
      case 'academico-bimestre':
        await this.loadBimestres();
        break;
      case 'contabil-despesas':
        await this.loadDespesas();
        break;
      case 'contabil-dre':
        await this.loadDRE();
        break;
      case 'produtos-cadastro':
      case 'produtos-gestao':
        await this.loadProdutos();
        break;
      case 'produtos-pdv':
        await this.setupPDV();
        break;
      case 'cursos-gestao':
        await this.loadCursos();
        break;
      case 'cursos-mensalidades':
        await this.loadCursosMensalidades();
        break;
      case 'config-usuarios':
        await this.loadUsuarios();
        break;
      default:
        break;
    }
  },

  // 1. DASHBOARD
  async loadDashboard() {
    try {
      const data = await this.api('/api/dashboard');
      document.getElementById('statTotalAlunos').innerText = data.total_alunos || 0;
      document.getElementById('statTotalTurmas').innerText = data.total_turmas || 0;
      
      const fatEl = document.getElementById('statFaturamentoMes');
      if (fatEl) {
        fatEl.innerText = `R$ ${(data.faturamento_mes_total || 0).toLocaleString('pt-BR', {minimumFractionDigits: 2})}`;
      }
      const fatSub = document.getElementById('statFaturamentoSub');
      if (fatSub) {
        fatSub.innerText = `${data.mes_vigente || 'Mês atual'} (${data.faturamento_mes_qtd || 0} faturamentos)`;
      }

      const recEl = document.getElementById('statMensalidadesMes');
      if (recEl) {
        recEl.innerText = `R$ ${(data.mensalidades_a_receber_mes_total || 0).toLocaleString('pt-BR', {minimumFractionDigits: 2})}`;
      }
      const recSub = document.getElementById('statMensalidadesSub');
      if (recSub) {
        recSub.innerText = `${data.mes_vigente || 'Mês atual'} (${data.mensalidades_a_receber_mes_qtd || 0} a receber)`;
      }

      const subTable = document.getElementById('tableRecentCaixaSubtitle');
      if (subTable) {
        subTable.innerText = `Lançamentos registrados em ${data.mes_vigente || 'mês vigente'}`;
      }
      
      const tbody = document.getElementById('tableRecentCaixa');
      if (tbody) {
        if (!data.ultimos_lancamentos || data.ultimos_lancamentos.length === 0) {
          tbody.innerHTML = `<tr><td colspan="6" class="text-center py-4 text-muted">Nenhum lançamento registrado no mês de ${data.mes_vigente || 'vigente'}.</td></tr>`;
        } else {
          tbody.innerHTML = data.ultimos_lancamentos.map(item => `
            <tr>
              <td><span class="badge ${item.tipo_movimentacao.includes('ENTRADA') ? 'bg-success' : 'bg-danger'}">${item.tipo_movimentacao}</span></td>
              <td><strong class="${item.tipo_movimentacao.includes('ENTRADA') ? 'text-success' : 'text-danger'}">R$ ${parseFloat(item.valor_total || 0).toFixed(2)}</strong></td>
              <td>${item.descricao || item.nome || '-'}</td>
              <td><span class="badge bg-secondary">${item.forma || 'DINHEIRO'}</span></td>
              <td>${item.data} ${item.horario || ''}</td>
              <td><small class="text-muted">${item.usuario}</small></td>
            </tr>
          `).join('');
        }
      }
    } catch (e) {
      console.error(e);
    }
  },

  // 2. ALUNOS & SECRETARIA
  async loadAlunos(busca = '') {
    try {
      const data = await this.api(`/api/alunos?busca=${encodeURIComponent(busca)}`);
      const tbody = document.getElementById('tableAlunos');
      if (tbody) {
        tbody.innerHTML = (data.alunos || []).map(a => `
          <tr>
            <td>#${a.id}</td>
            <td><strong>${a.nome}</strong></td>
            <td>${a.nome_turma || a.etapa || '-'}</td>
            <td>${a.turno || '-'}</td>
            <td>${a.telefone || '-'}</td>
            <td><span class="badge ${a.status === 'ATIVO' ? 'bg-success' : 'bg-warning text-dark'}">${a.status || 'ATIVO'}</span></td>
            <td class="text-end">
              <button class="btn btn-sm btn-outline-primary" onclick="App.verAluno(${a.id})"><i class="bi bi-eye"></i> Ver</button>
              <button class="btn btn-sm btn-outline-info" onclick="App.gerarDocumentoRapido(${a.id})"><i class="bi bi-file-earmark-text"></i> Documentos</button>
              <button class="btn btn-sm btn-outline-danger" onclick="App.excluirAluno(${a.id})"><i class="bi bi-trash"></i></button>
            </td>
          </tr>
        `).join('');
      }
      document.getElementById('totalAlunosConsultados').innerText = `${data.total || 0} alunos encontrados`;
    } catch (e) {
      console.error(e);
    }
  },

  async verAluno(id) {
    try {
      const data = await this.api(`/api/alunos/${id}`);
      this.selectedAlunoId = id;
      const modalBody = document.getElementById('modalAlunoDetalhesBody');
      const a = data.aluno;
      const ra = data.responsavel_academico || {};
      const rf = data.responsavel_financeiro || {};

      modalBody.innerHTML = `
        <div class="row g-3">
          <div class="col-md-6">
            <h6 class="text-primary border-bottom pb-1"><i class="bi bi-person"></i> Dados do Aluno</h6>
            <p><strong>Nome:</strong> ${a.nome_aluno}</p>
            <p><strong>Nascimento:</strong> ${a.datanasc || '-'} (${a.sexo || '-'})</p>
            <p><strong>Etapa / Turma:</strong> ${a.etapa || '-'} / ${a.nome_turma || '-'}</p>
            <p><strong>Turno:</strong> ${a.turno || '-'}</p>
            <p><strong>Mãe:</strong> ${a.mae || '-'}</p>
            <p><strong>Pai:</strong> ${a.pai || '-'}</p>
            <p><strong>Endereço:</strong> ${a.rua || ''}, ${a.numero || ''} - ${a.bairro || ''} (${a.cidade || ''}/${a.UF || ''})</p>
          </div>
          <div class="col-md-6">
            <h6 class="text-primary border-bottom pb-1"><i class="bi bi-person-badge"></i> Responsável Financeiro</h6>
            <p><strong>Nome:</strong> ${rf.nome || '-'}</p>
            <p><strong>CPF:</strong> ${rf.CPF || '-'}</p>
            <p><strong>Telefone:</strong> ${rf.telefone || '-'}</p>
            <p><strong>Email:</strong> ${rf.email || '-'}</p>
            <h6 class="text-primary border-bottom pb-1 mt-3"><i class="bi bi-mortarboard"></i> Responsável Acadêmico</h6>
            <p><strong>Nome:</strong> ${ra.nome || '-'}</p>
            <p><strong>CPF:</strong> ${ra.CPF || '-'}</p>
            <p><strong>Telefone:</strong> ${ra.telefone || '-'}</p>
          </div>
        </div>
        <hr/>
        <div class="d-flex gap-2 flex-wrap justify-content-center">
          <button class="btn btn-outline-primary" onclick="App.imprimirDocumento('matricula', ${id})"><i class="bi bi-printer"></i> Declaração Matrícula</button>
          <button class="btn btn-outline-success" onclick="App.imprimirDocumento('quitacao', ${id})"><i class="bi bi-printer"></i> Declaração Quitação</button>
          <button class="btn btn-outline-warning text-dark" onclick="App.imprimirDocumento('comparecimento', ${id})"><i class="bi bi-printer"></i> Comparecimento</button>
          <button class="btn btn-outline-info" onclick="App.imprimirDocumento('frequencia', ${id})"><i class="bi bi-printer"></i> Frequência</button>
          <button class="btn btn-outline-secondary" onclick="App.imprimirDocumento('transferencia', ${id})"><i class="bi bi-printer"></i> Guia Transferência</button>
          <button class="btn btn-outline-dark" onclick="App.imprimirDocumento('contrato_normal', ${id})"><i class="bi bi-file-text"></i> Contrato de Ensino</button>
          <button class="btn btn-outline-danger" onclick="App.imprimirDocumento('termo', ${id})"><i class="bi bi-shield-check"></i> Termo de Resp.</button>
          <button class="btn btn-primary" onclick="App.verBoletim(${id})"><i class="bi bi-journal-check"></i> Ver Boletim</button>
        </div>
      `;
      const modal = new bootstrap.Modal(document.getElementById('modalAlunoDetalhes'));
      modal.show();
    } catch (e) {
      alert('Erro ao carregar detalhes do aluno');
    }
  },

  async excluirAluno(id) {
    if (confirm(`Deseja realmente excluir o aluno #${id}?`)) {
      try {
        await this.api(`/api/alunos/${id}`, 'DELETE');
        alert('Aluno excluído com sucesso');
        this.loadAlunos();
      } catch (e) {
        alert('Erro ao excluir aluno');
      }
    }
  },

  // 3. CAIXA & MENSALIDADES
  async loadCaixa() {
    try {
      const data = await this.api('/api/caixa');
      document.getElementById('caixaSaldoTotal').innerText = `R$ ${(data.saldo.saldo_atual || 0).toLocaleString('pt-BR', {minimumFractionDigits: 2})}`;
      document.getElementById('caixaEntradasTotal').innerText = `R$ ${(data.saldo.total_entradas || 0).toLocaleString('pt-BR', {minimumFractionDigits: 2})}`;
      document.getElementById('caixaSaidasTotal').innerText = `R$ ${(data.saldo.total_saidas || 0).toLocaleString('pt-BR', {minimumFractionDigits: 2})}`;
      
      const tbody = document.getElementById('tableCaixa');
      if (tbody) {
        tbody.innerHTML = (data.caixa || []).map(c => `
          <tr>
            <td>#${c.id}</td>
            <td><span class="badge ${c.tipo_movimentacao.includes('ENTRADA') ? 'bg-success' : 'bg-danger'}">${c.tipo_movimentacao}</span></td>
            <td><strong>R$ ${parseFloat(c.valor_total || 0).toFixed(2)}</strong></td>
            <td>${c.nome || '-'}</td>
            <td>${c.descricao || '-'}</td>
            <td><span class="badge bg-light text-dark border">${c.forma || 'DINHEIRO'}</span></td>
            <td>${c.data} ${c.horario || ''}</td>
            <td>${c.usuario}</td>
            <td>
              <button class="btn btn-sm btn-outline-secondary" onclick="App.imprimirRecibo(${c.id})"><i class="bi bi-receipt"></i> 2ª Via</button>
            </td>
          </tr>
        `).join('');
      }
    } catch (e) {
      console.error(e);
    }
  },

  async loadMensalidades(status = 'todas', busca = '') {
    try {
      const data = await this.api(`/api/mensalidades?status=${status}&busca=${encodeURIComponent(busca)}`);
      const tbody = document.getElementById('tableMensalidades');
      if (tbody) {
        tbody.innerHTML = (data.mensalidades || []).map(m => {
          const saldo = parseFloat(m.saldo_devedor || 0);
          const total = parseFloat(m.valor_total || 0);
          const isPaga = saldo <= 0;
          return `
            <tr>
              <td>#${m.id}</td>
              <td><strong>${m.nome_aluno || 'ALUNO'}</strong></td>
              <td>${m.responsavel_nome || '-'}</td>
              <td>R$ ${parseFloat(m.valor_parcela || 0).toFixed(2)}</td>
              <td>${m.parcelas_pagas || 0} / ${m.n_parcelas || 12}</td>
              <td><strong>R$ ${saldo.toFixed(2)}</strong></td>
              <td><span class="badge ${isPaga ? 'bg-success' : 'bg-danger'}">${isPaga ? 'QUITADO' : 'EM ABERTO'}</span></td>
              <td>
                <button class="btn btn-sm btn-primary" onclick="App.abrirPagamentoMensalidade(${m.id}, '${m.nome_aluno}', ${m.valor_parcela}, ${m.parcelas_pagas}, ${m.n_parcelas})">
                  <i class="bi bi-cash-coin"></i> Receber
                </button>
                <button class="btn btn-sm btn-outline-secondary" onclick="App.imprimirCarne(${m.idaluno})">
                  <i class="bi bi-printer"></i> Carnê
                </button>
              </td>
            </tr>
          `;
        }).join('');
      }
    } catch (e) {
      console.error(e);
    }
  },

  abrirPagamentoMensalidade(id, aluno, valorParcela, pagas, totalParcelas) {
    document.getElementById('pagMensalidadeId').value = id;
    document.getElementById('pagAlunoNome').value = aluno;
    document.getElementById('pagValorParcela').value = valorParcela;
    document.getElementById('pagParcelasPagas').value = `${pagas} de ${totalParcelas}`;
    document.getElementById('pagQtdParcelas').value = 1;
    this.calcularSubtotalPagamento();
    const modal = new bootstrap.Modal(document.getElementById('modalPagarMensalidade'));
    modal.show();
  },

  calcularSubtotalPagamento() {
    const valor = parseFloat(document.getElementById('pagValorParcela').value || 0);
    const qtd = parseInt(document.getElementById('pagQtdParcelas').value || 1);
    const subtotal = valor * qtd;
    document.getElementById('pagSubtotal').innerText = `R$ ${subtotal.toFixed(2)}`;
  },

  async confirmarPagamentoMensalidade() {
    const id = document.getElementById('pagMensalidadeId').value;
    const qtd = parseInt(document.getElementById('pagQtdParcelas').value || 1);
    const forma = document.getElementById('pagFormaPagamento').value;
    const obs = document.getElementById('pagObs').value;

    try {
      const res = await this.api('/api/mensalidades/pagar', 'POST', {
        mensalidade_id: id,
        quantidade_parcelas: qtd,
        forma_pagamento: forma,
        observacao: obs
      });
      alert(`Pagamento de R$ ${res.total_pago.toFixed(2)} efetuado com sucesso!`);
      bootstrap.Modal.getInstance(document.getElementById('modalPagarMensalidade')).hide();
      this.loadMensalidades();
      if (res.caixa_id) {
        this.imprimirRecibo(res.caixa_id);
      }
    } catch (e) {
      alert(e.message || 'Erro ao processar pagamento');
    }
  },

  // 3.1 TABELA DE MENSALIDADES POR CURSO E HORÁRIO
  async loadTabelaMensalidades() {
    try {
      const data = await this.api('/api/financeiro/tabela-mensalidades');
      const tabela = data.tabela || [];
      const tbody = document.getElementById('tableTabelaMensalidades');

      let minVal = Infinity;
      let maxVal = -Infinity;

      if (tbody) {
        tbody.innerHTML = tabela.map(item => {
          const valor = parseFloat(item.valor_mensalidade || 0);
          if (valor < minVal) minVal = valor;
          if (valor > maxVal) maxVal = valor;

          let turnoBadge = 'bg-secondary';
          if (item.turno.includes('MATUTINO') && !item.turno.includes('PERIODO')) turnoBadge = 'bg-primary';
          else if (item.turno.includes('VESPERTINO') && !item.turno.includes('PERIODO')) turnoBadge = 'bg-warning text-dark';
          else if (item.turno.includes('PERIODO')) turnoBadge = 'bg-info text-dark';
          else if (item.turno.includes('INTEGRAL')) turnoBadge = 'bg-success';

          return `
            <tr>
              <td><strong>${item.curso}</strong></td>
              <td>${item.etapa || 'Todas'}</td>
              <td><span class="badge ${turnoBadge}">${item.turno}</span></td>
              <td><small class="text-muted"><i class="bi bi-clock me-1"></i>${item.horario_descricao || 'Horário Padrão'}</small></td>
              <td><h5 class="m-0 fw-bold text-success">R$ ${valor.toFixed(2)}</h5></td>
              <td>${item.n_parcelas_padrao || 12}x</td>
              <td><span class="badge bg-light text-dark border">${item.ano_vigente || '2026'}</span></td>
              <td class="text-end">
                <button class="btn btn-sm btn-primary fw-bold" onclick="App.abrirModalEditarPlano(${item.id}, '${item.curso}', '${item.etapa}', '${item.turno}', '${item.horario_descricao || ''}', ${valor}, ${item.n_parcelas_padrao || 12}, '${item.ano_vigente || '2026'}')">
                  <i class="bi bi-pencil me-1"></i> Alterar Valor
                </button>
                <button class="btn btn-sm btn-outline-danger" onclick="App.excluirPlanoMensalidade(${item.id})" title="Excluir">
                  <i class="bi bi-trash"></i>
                </button>
              </td>
            </tr>
          `;
        }).join('');
      }

      const countEl = document.getElementById('totalPlanosConfigurados');
      if (countEl) countEl.innerText = `${tabela.length} modalidades`;
      const faixaEl = document.getElementById('faixaValoresMensalidade');
      if (faixaEl && tabela.length > 0) {
        faixaEl.innerText = `R$ ${minVal.toFixed(2)} a R$ ${maxVal.toFixed(2)}`;
      }
    } catch (e) {
      console.error('Erro ao carregar tabela de mensalidades:', e);
    }
  },

  async abrirModalEditarPlano(id, curso, etapa, turno, horario, valor, parcelas, ano) {
    document.getElementById('editPlanoId').value = id;

    document.getElementById('editPlanoCurso').value = curso || '';

    // Seleciona o turno
    const selectTurno = document.getElementById('editPlanoTurno');
    if (selectTurno) {
      selectTurno.value = turno || 'MATUTINO';
    }

    // Seleciona a etapa/série
    const selectEtapa = document.getElementById('editPlanoEtapa');
    if (selectEtapa) {
      // Se a etapa existir nas opções, seleciona, senão adiciona
      let found = false;
      for (let opt of selectEtapa.options) {
        if (opt.value.trim().toUpperCase() === (etapa || '').trim().toUpperCase()) {
          opt.selected = true;
          found = true;
          break;
        }
      }
      if (!found && etapa) {
        const newOpt = new Option(etapa, etapa, true, true);
        selectEtapa.add(newOpt);
      }
    }

    // Seleciona o horário
    const selectHorario = document.getElementById('editPlanoHorario');
    if (selectHorario) {
      let found = false;
      for (let opt of selectHorario.options) {
        if (opt.value.trim().startsWith((horario || '').trim())) {
          opt.selected = true;
          found = true;
          break;
        }
      }
      if (!found && horario) {
        const newOpt = new Option(horario, horario, true, true);
        selectHorario.add(newOpt);
      }
    }

    document.getElementById('editPlanoValor').value = valor;
    document.getElementById('editPlanoParcelas').value = parcelas || 12;
    document.getElementById('editPlanoAno').value = ano || '2026';
    document.getElementById('checkReajustarAtivos').checked = false;

    const modal = new bootstrap.Modal(document.getElementById('modalEditarValorMensalidade'));
    modal.show();
  },

  async salvarAlteracaoValorMensalidade() {
    const id = document.getElementById('editPlanoId').value;
    const curso = document.getElementById('editPlanoCurso').value;
    const turno = document.getElementById('editPlanoTurno').value;
    const etapa = document.getElementById('editPlanoEtapa').value;
    const horario = document.getElementById('editPlanoHorario').value;
    const valor = parseFloat(document.getElementById('editPlanoValor').value || 0);
    const parcelas = parseInt(document.getElementById('editPlanoParcelas').value || 12);
    const ano = document.getElementById('editPlanoAno').value;
    const reajustar = document.getElementById('checkReajustarAtivos').checked;

    if (isNaN(valor) || valor <= 0) {
      alert('Por favor, informe um valor de mensalidade válido.');
      return;
    }

    try {
      const res = await this.api(`/api/financeiro/tabela-mensalidades/${id}`, 'PUT', {
        curso: curso,
        turno: turno,
        etapa: etapa,
        horario_descricao: horario,
        valor_mensalidade: valor,
        n_parcelas_padrao: parcelas,
        ano_vigente: ano,
        reajustar_contratos_ativos: reajustar
      });
      alert(res.message || 'Valor alterado com sucesso!');
      bootstrap.Modal.getInstance(document.getElementById('modalEditarValorMensalidade')).hide();
      this.loadTabelaMensalidades();
    } catch (e) {
      alert('Erro ao salvar alteração: ' + e.message);
    }
  },

  async abrirModalNovoPlano() {
    // Popula o select de cursos com os cursos do banco
    try {
      const dataCursos = await this.api('/api/cursos');
      const selectCurso = document.getElementById('novoPlanoCurso');
      if (selectCurso) {
        selectCurso.innerHTML = (dataCursos.cursos || []).map(c => 
          `<option value="${c.nome_curso}">${c.nome_curso}</option>`
        ).join('');
      }
    } catch (e) {
      console.error(e);
    }

    document.getElementById('novoPlanoValor').value = '';
    const modal = new bootstrap.Modal(document.getElementById('modalNovoPlanoMensalidade'));
    modal.show();
  },

  async cadastrarNovoPlanoMensalidade() {
    const curso = document.getElementById('novoPlanoCurso').value.trim();
    const turno = document.getElementById('novoPlanoTurno').value;
    const etapa = document.getElementById('novoPlanoEtapa').value;
    const horario = document.getElementById('novoPlanoHorario').value;
    const valor = parseFloat(document.getElementById('novoPlanoValor').value || 0);
    const parcelas = parseInt(document.getElementById('novoPlanoParcelas').value || 12);
    const ano = document.getElementById('novoPlanoAno').value.trim() || '2026';

    if (!curso) {
      alert('Selecione o curso/modalidade.');
      return;
    }
    if (isNaN(valor) || valor <= 0) {
      alert('Informe um valor de mensalidade válido.');
      return;
    }

    try {
      const res = await this.api('/api/financeiro/tabela-mensalidades', 'POST', {
        curso, turno, etapa, horario_descricao: horario, valor_mensalidade: valor, n_parcelas_padrao: parcelas, ano_vigente: ano
      });
      alert(res.message || 'Modalidade cadastrada com sucesso!');
      bootstrap.Modal.getInstance(document.getElementById('modalNovoPlanoMensalidade')).hide();
      this.loadTabelaMensalidades();
    } catch (e) {
      alert('Erro ao cadastrar modalidade: ' + e.message);
    }
  },

  async excluirPlanoMensalidade(id) {
    if (confirm('Deseja realmente excluir esta configuração de mensalidade e horário?')) {
      try {
        await this.api(`/api/financeiro/tabela-mensalidades/${id}`, 'DELETE');
        this.loadTabelaMensalidades();
      } catch (e) {
        alert('Erro ao excluir: ' + e.message);
      }
    }
  },

  // 3.2 SECRETARIA - CRIAR OU EDITAR CURSOS
  async loadSecretariaCursos() {
    try {
      const data = await this.api('/api/cursos');
      const cursos = data.cursos || [];
      const tbody = document.getElementById('tableSecretariaCursos');
      if (tbody) {
        tbody.innerHTML = cursos.map(c => `
          <tr>
            <td><strong>#${c.id}</strong></td>
            <td><h6 class="m-0 fw-bold text-primary">${c.nome_curso}</h6></td>
            <td class="text-end">
              <button class="btn btn-sm btn-outline-primary fw-bold me-1" onclick="App.abrirModalEditarCurso(${c.id}, '${c.nome_curso}')">
                <i class="bi bi-pencil me-1"></i> Editar Nome
              </button>
              <button class="btn btn-sm btn-outline-danger" onclick="App.excluirCurso(${c.id})" title="Excluir Curso">
                <i class="bi bi-trash"></i>
              </button>
            </td>
          </tr>
        `).join('');
      }
      const countEl = document.getElementById('totalCursosCount');
      if (countEl) countEl.innerText = `${cursos.length} cursos cadastrados`;
    } catch (e) {
      console.error('Erro ao carregar cursos:', e);
    }
  },

  abrirModalNovoCurso() {
    const input = document.getElementById('inputNovoCursoNome');
    if (input) input.value = '';
    const modal = new bootstrap.Modal(document.getElementById('modalNovoCurso'));
    modal.show();
  },

  async salvarNovoCurso() {
    const nome = (document.getElementById('inputNovoCursoNome')?.value || '').trim();
    if (!nome) {
      alert('Por favor, informe o nome do curso.');
      return;
    }
    try {
      const res = await this.api('/api/cursos', 'POST', { nome_curso: nome });
      alert(res.message || 'Curso cadastrado com sucesso!');
      bootstrap.Modal.getInstance(document.getElementById('modalNovoCurso')).hide();
      this.loadSecretariaCursos();
    } catch (e) {
      alert('Erro ao salvar curso: ' + e.message);
    }
  },

  abrirModalEditarCurso(id, nome) {
    document.getElementById('editCursoId').value = id;
    document.getElementById('editCursoNome').value = nome;
    const modal = new bootstrap.Modal(document.getElementById('modalEditarCurso'));
    modal.show();
  },

  async salvarEdicaoCurso() {
    const id = document.getElementById('editCursoId').value;
    const nome = (document.getElementById('editCursoNome')?.value || '').trim();
    if (!nome) {
      alert('Por favor, informe o nome do curso.');
      return;
    }
    try {
      const res = await this.api(`/api/cursos/${id}`, 'PUT', { nome_curso: nome });
      alert(res.message || 'Curso atualizado com sucesso!');
      bootstrap.Modal.getInstance(document.getElementById('modalEditarCurso')).hide();
      this.loadSecretariaCursos();
    } catch (e) {
      alert('Erro ao atualizar curso: ' + e.message);
    }
  },

  async excluirCurso(id) {
    if (confirm('Deseja realmente excluir este curso? Esta ação não pode ser desfeita.')) {
      try {
        await this.api(`/api/cursos/${id}`, 'DELETE');
        this.loadSecretariaCursos();
      } catch (e) {
        alert('Erro ao excluir curso: ' + e.message);
      }
    }
  },

  // 3.3 SECRETARIA - NOVA MATRÍCULA
  async initNovaMatricula() {
    try {
      // Carrega Cursos
      const dataCursos = await this.api('/api/cursos');
      const selCurso = document.getElementById('matrCurso');
      if (selCurso) {
        selCurso.innerHTML = '<option value="">Selecione o Curso...</option>' + 
          (dataCursos.cursos || []).map(c => `<option value="${c.id}">${c.nome_curso}</option>`).join('');
      }

      // Carrega Turmas
      const dataTurmas = await this.api('/api/turmas');
      const selTurma = document.getElementById('matrTurma');
      if (selTurma) {
        selTurma.innerHTML = '<option value="">Selecione a Turma...</option>' + 
          (dataTurmas.turmas || []).map(t => `<option value="${t.id}">${t.nome_turma} (${t.turno})</option>`).join('');
      }
    } catch (e) {
      console.error('Erro ao inicializar formulário de matrícula:', e);
    }
  },

  copiarRespAcadParaFin() {
    document.getElementById('matrRespFinNome').value = document.getElementById('matrRespAcadNome').value;
    document.getElementById('matrRespFinParentesco').value = document.getElementById('matrRespAcadParentesco').value;
    document.getElementById('matrRespFinCPF').value = document.getElementById('matrRespAcadCPF').value;
    document.getElementById('matrRespFinRG').value = document.getElementById('matrRespAcadRG').value;
    document.getElementById('matrRespFinProfissao').value = document.getElementById('matrRespAcadProfissao').value;
    document.getElementById('matrRespFinTelefone').value = document.getElementById('matrRespAcadTelefone').value;
    document.getElementById('matrRespFinEmail').value = document.getElementById('matrRespAcadEmail').value;
    alert('Dados do Responsável Acadêmico copiados para o Responsável Financeiro!');
  },

  async salvarNovaMatricula() {
    const nomeAluno = (document.getElementById('matrNomeAluno')?.value || '').trim();
    if (!nomeAluno) {
      alert('Por favor, informe o nome completo do aluno.');
      return;
    }

    const payload = {
      nome_aluno: nomeAluno,
      datanasc: document.getElementById('matrDataNasc')?.value || '',
      sexo: document.getElementById('matrSexo')?.value || 'Masculino',
      cor: document.getElementById('matrCor')?.value || 'Parda',
      cidade: document.getElementById('matrCidade')?.value || 'MANAUS',
      UF: document.getElementById('matrUF')?.value || 'AM',
      rua: document.getElementById('matrRua')?.value || '',
      numero: document.getElementById('matrNumero')?.value || '',
      bairro: document.getElementById('matrBairro')?.value || '',
      cep: document.getElementById('matrCEP')?.value || '',
      telefone: document.getElementById('matrTelefone')?.value || '',
      vive_com: document.getElementById('matrViveCom')?.value || 'PAIS',
      mae: document.getElementById('matrMae')?.value || '',
      pai: document.getElementById('matrPai')?.value || '',
      doenca: document.getElementById('matrDoenca')?.value || 'NÃO',
      emergencia: document.getElementById('matrEmergencia')?.value || '',
      
      // Resp Acadêmico
      resp_acad_nome: document.getElementById('matrRespAcadNome')?.value || '',
      resp_acad_parentesco: document.getElementById('matrRespAcadParentesco')?.value || 'MÃE',
      resp_acad_cpf: document.getElementById('matrRespAcadCPF')?.value || '',
      resp_acad_rg: document.getElementById('matrRespAcadRG')?.value || '',
      resp_acad_nasc: document.getElementById('matrRespAcadNasc')?.value || '',
      resp_acad_telefone: document.getElementById('matrRespAcadTelefone')?.value || '',
      resp_acad_email: document.getElementById('matrRespAcadEmail')?.value || '',
      resp_acad_profissao: document.getElementById('matrRespAcadProfissao')?.value || '',

      // Resp Financeiro
      resp_fin_nome: document.getElementById('matrRespFinNome')?.value || '',
      resp_fin_parentesco: document.getElementById('matrRespFinParentesco')?.value || 'PAI',
      resp_fin_cpf: document.getElementById('matrRespFinCPF')?.value || '',
      resp_fin_rg: document.getElementById('matrRespFinRG')?.value || '',
      resp_fin_profissao: document.getElementById('matrRespFinProfissao')?.value || '',
      resp_fin_telefone: document.getElementById('matrRespFinTelefone')?.value || '',
      resp_fin_email: document.getElementById('matrRespFinEmail')?.value || '',

      // Curso & Turma
      idcurso: document.getElementById('matrCurso')?.value || null,
      idturma: document.getElementById('matrTurma')?.value || null,
      turno: document.getElementById('matrTurno')?.value || 'MATUTINO',
      etapa: document.getElementById('matrEtapa')?.value || '',
      ano_letivo: document.getElementById('matrAnoLetivo')?.value || '2026',
      observacao: document.getElementById('matrObservacao')?.value || '',
      status: 'ATIVO'
    };

    try {
      const res = await this.api('/api/alunos', 'POST', payload);
      alert(`Matrícula efetivada com sucesso! Matrícula #${res.id} - ${nomeAluno}`);
      document.getElementById('formNovaMatricula').reset();
      this.navigate('secretaria-consultar');
    } catch (e) {
      alert('Erro ao salvar matrícula: ' + e.message);
    }
  },

  // 3.4 SECRETARIA - RESPONSÁVEIS ACADÊMICOS & FINANCEIROS
  async loadResponsaveis(tipo = 'academico', busca = '') {
    try {
      const data = await this.api(`/api/responsaveis?tipo=${tipo}&busca=${encodeURIComponent(busca)}`);
      const itens = data.responsaveis || [];

      if (tipo === 'academico') {
        const countEl = document.getElementById('totalRespAcadCount');
        if (countEl) countEl.innerText = `${itens.length} responsáveis encontrados`;
        const tbody = document.getElementById('tableRespAcad');
        if (tbody) {
          tbody.innerHTML = itens.map(r => `
            <tr>
              <td><strong>#${r.id}</strong></td>
              <td><h6 class="m-0 fw-bold text-dark">${r.nome}</h6></td>
              <td><span class="badge bg-light text-dark border">${r.parentesco || 'Responsável'}</span></td>
              <td><span class="font-monospace small">${r.CPF || '-'}</span></td>
              <td>
                <div class="small fw-bold">${r.telefone || '-'}</div>
                <div class="small text-muted">${r.email || ''}</div>
              </td>
              <td><small class="text-muted">${r.bairro || ''} ${r.rua ? '- ' + r.rua : ''}</small></td>
              <td>
                ${r.nome_aluno ? `
                  <span class="badge bg-primary text-white me-1">#${r.idaluno}</span>
                  <button class="btn btn-sm btn-link p-0 text-decoration-none fw-bold" onclick="App.verDetalhesAluno(${r.idaluno})">
                    ${r.nome_aluno}
                  </button>
                ` : '<span class="text-muted small">Não vinculado</span>'}
              </td>
            </tr>
          `).join('');
        }
      } else {
        const countEl = document.getElementById('totalRespFinCount');
        if (countEl) countEl.innerText = `${itens.length} responsáveis financeiros`;
        const tbody = document.getElementById('tableRespFin');
        if (tbody) {
          tbody.innerHTML = itens.map(r => `
            <tr>
              <td><strong>#${r.id}</strong></td>
              <td><h6 class="m-0 fw-bold text-success">${r.nome}</h6></td>
              <td><span class="badge bg-light text-dark border">${r.parentesco || 'Financeiro'}</span></td>
              <td><span class="font-monospace small">${r.CPF || '-'}</span></td>
              <td>
                <div class="small fw-bold">${r.telefone || '-'}</div>
                <div class="small text-muted">${r.email || ''}</div>
              </td>
              <td><small class="text-muted">${r.bairro || ''} ${r.rua ? '- ' + r.rua : ''}</small></td>
              <td>
                ${r.nome_aluno ? `
                  <span class="badge bg-success text-white me-1">#${r.idaluno}</span>
                  <button class="btn btn-sm btn-link p-0 text-decoration-none fw-bold text-dark" onclick="App.verDetalhesAluno(${r.idaluno})">
                    ${r.nome_aluno}
                  </button>
                ` : '<span class="text-muted small">Não vinculado</span>'}
              </td>
              <td class="text-end">
                ${r.idaluno ? `
                  <button class="btn btn-sm btn-outline-success fw-bold" onclick="App.gerarCarneAluno(${r.idaluno})" title="Ver Carnê de Pagamento">
                    <i class="bi bi-receipt me-1"></i> Carnê
                  </button>
                ` : ''}
              </td>
            </tr>
          `).join('');
        }
      }
    } catch (e) {
      console.error('Erro ao carregar responsáveis:', e);
    }
  },

  buscarResponsaveis(tipo) {
    const inputId = tipo === 'academico' ? 'inputBuscaRespAcad' : 'inputBuscaRespFin';
    const busca = (document.getElementById(inputId)?.value || '').trim();
    this.loadResponsaveis(tipo, busca);
  },

  // 3.5 SECRETARIA - GESTÃO DE TURMAS
  async loadTurmas() {
    try {
      const data = await this.api('/api/turmas');
      const turmas = data.turmas || [];
      const countEl = document.getElementById('totalTurmasCount');
      if (countEl) countEl.innerText = `${turmas.length} turmas cadastradas`;

      const tbody = document.getElementById('tableSecretariaTurmas');
      if (tbody) {
        tbody.innerHTML = turmas.map(t => {
          const ocupacaoPct = t.qtd_alunos > 0 ? Math.min(100, Math.round((t.total_matriculados / t.qtd_alunos) * 100)) : 0;
          const badgeTurno = t.turno === 'MATUTINO' ? 'bg-primary' : (t.turno === 'VESPERTINO' ? 'bg-warning text-dark' : 'bg-info text-dark');
          return `
            <tr>
              <td><strong>#${t.id}</strong></td>
              <td><h6 class="m-0 fw-bold text-primary">${t.nome_turma}</h6></td>
              <td><span class="fw-semibold text-secondary">${t.serie || '-'}</span></td>
              <td><span class="badge ${badgeTurno}">${t.turno || 'GERAL'}</span></td>
              <td><span class="small fw-bold text-dark"><i class="bi bi-person me-1"></i>${t.professor_nome || 'Sem Professor'}</span></td>
              <td>
                <div class="d-flex align-items-center gap-2">
                  <span class="fw-bold">${t.total_matriculados} / ${t.qtd_alunos}</span>
                  <div class="progress flex-grow-1" style="height: 6px; width: 60px;">
                    <div class="progress-bar ${ocupacaoPct > 90 ? 'bg-danger' : 'bg-success'}" style="width: ${ocupacaoPct}%"></div>
                  </div>
                </div>
              </td>
              <td><span class="badge bg-light text-muted border">${t.ano_letivo || '2026'}</span></td>
              <td class="text-end">
                <button class="btn btn-sm btn-outline-primary fw-bold" onclick="App.filtrarAlunosPorTurma(${t.id}, '${t.nome_turma}')">
                  <i class="bi bi-people me-1"></i> Ver Alunos
                </button>
              </td>
            </tr>
          `;
        }).join('');
      }
    } catch (e) {
      console.error('Erro ao carregar turmas:', e);
    }
  },

  async abrirModalNovaTurma() {
    try {
      const dataProfs = await this.api('/api/professores');
      const selectProf = document.getElementById('selectTurmaProfessor');
      if (selectProf) {
        selectProf.innerHTML = '<option value="0">Selecione o Professor Titular...</option>' + 
          (dataProfs.professores || []).map(p => `<option value="${p.id}">${p.nome}</option>`).join('');
      }
    } catch (e) {
      console.error(e);
    }

    document.getElementById('inputTurmaNome').value = '';
    document.getElementById('inputTurmaSerie').value = '';
    const modal = new bootstrap.Modal(document.getElementById('modalNovaTurma'));
    modal.show();
  },

  async salvarNovaTurma() {
    const nome = (document.getElementById('inputTurmaNome')?.value || '').trim();
    if (!nome) {
      alert('Por favor, informe o nome da turma.');
      return;
    }
    const serie = document.getElementById('inputTurmaSerie')?.value || '';
    const turno = document.getElementById('inputTurmaTurno')?.value || 'MATUTINO';
    const profId = parseInt(document.getElementById('selectTurmaProfessor')?.value || 0);
    const qtd = parseInt(document.getElementById('inputTurmaQtd')?.value || 30);
    const ano = parseInt(document.getElementById('inputTurmaAno')?.value || 2026);

    try {
      const res = await this.api('/api/turmas', 'POST', {
        nome_turma: nome,
        serie: serie,
        turno: turno,
        idprofessor: profId,
        qtd_alunos: qtd,
        ano_letivo: ano
      });
      alert(res.message || 'Turma cadastrada com sucesso!');
      bootstrap.Modal.getInstance(document.getElementById('modalNovaTurma')).hide();
      this.loadTurmas();
    } catch (e) {
      alert('Erro ao salvar turma: ' + e.message);
    }
  },

  async filtrarAlunosPorTurma(turmaId, nomeTurma) {
    await this.navigate('secretaria-consultar');
    const selectTurma = document.getElementById('filtroTurma');
    if (selectTurma) {
      let exists = false;
      for (let opt of selectTurma.options) {
        if (opt.value == turmaId) { opt.selected = true; exists = true; break; }
      }
      if (!exists) {
        selectTurma.add(new Option(nomeTurma, turmaId, true, true));
      }
      this.carregarAlunos(0);
    }
  },

  // 3.6 SECRETARIA - PROFESSORES
  async loadProfessores() {
    try {
      const data = await this.api('/api/professores');
      const profs = data.professores || [];
      const countEl = document.getElementById('totalProfessoresCount');
      if (countEl) countEl.innerText = `${profs.length} professores cadastrados`;

      const tbody = document.getElementById('tableSecretariaProfessores');
      if (tbody) {
        tbody.innerHTML = profs.map(p => `
          <tr>
            <td><strong>#${p.id}</strong></td>
            <td><h6 class="m-0 fw-bold text-dark"><i class="bi bi-person-circle text-primary me-2"></i>${p.nome}</h6></td>
            <td><span class="small fw-semibold text-secondary"><i class="bi bi-telephone me-1"></i>${p.telefone || '(Sem telefone)'}</span></td>
            <td><code>${p.username || '-'}</code></td>
            <td><span class="badge bg-primary rounded-pill px-3 py-1 fs-6">${p.total_turmas || 0} turmas</span></td>
          </tr>
        `).join('');
      }
    } catch (e) {
      console.error('Erro ao carregar professores:', e);
    }
  },

  abrirModalNovoProfessor() {
    document.getElementById('inputProfNome').value = '';
    document.getElementById('inputProfTelefone').value = '';
    document.getElementById('inputProfUsername').value = '';
    document.getElementById('inputProfSenha').value = '';
    const modal = new bootstrap.Modal(document.getElementById('modalNovoProfessor'));
    modal.show();
  },

  async salvarNovoProfessor() {
    const nome = (document.getElementById('inputProfNome')?.value || '').trim();
    if (!nome) {
      alert('Por favor, informe o nome do professor.');
      return;
    }
    const tel = (document.getElementById('inputProfTelefone')?.value || '').trim();
    const user = (document.getElementById('inputProfUsername')?.value || '').trim();
    const senha = (document.getElementById('inputProfSenha')?.value || '').trim();

    try {
      const res = await this.api('/api/professores', 'POST', {
        nome: nome,
        telefone: tel,
        username: user,
        senha: senha
      });
      alert(res.message || 'Professor cadastrado com sucesso!');
      bootstrap.Modal.getInstance(document.getElementById('modalNovoProfessor')).hide();
      this.loadProfessores();
    } catch (e) {
      alert('Erro ao salvar professor: ' + e.message);
    }
  },

  // ==========================================
  // 3.8 SECRETARIA - DECLARAÇÕES OFICIAIS
  // ==========================================
  cacheDeclaracaoDados: null,

  async setupDeclaracoes() {
    try {
      // 1. Carrega turmas no select de filtro
      const dataTurmas = await this.api('/api/turmas');
      const selTurma = document.getElementById('declaracaoTurmaSelect');
      if (selTurma) {
        selTurma.innerHTML = '<option value="">Todas as Turmas...</option>' + 
          (dataTurmas.turmas || []).map(t => {
            const anoStr = t.ano_letivo ? ` (${t.ano_letivo})` : '';
            return `<option value="${t.id}">${t.nome_turma}${anoStr}</option>`;
          }).join('');
      }

      // 2. Carrega lista inicial de alunos
      await this.carregarAlunosParaDeclaracao();

      // 3. Configura campos extras de acordo com o tipo
      this.onTipoDeclaracaoChange();

    } catch (e) {
      console.error('Erro ao configurar tela de declarações:', e);
    }
  },

  async carregarAlunosParaDeclaracao(turmaId = '') {
    const url = turmaId ? `/api/turmas/${encodeURIComponent(turmaId)}/alunos` : '/api/alunos?limit=300';
    const data = await this.api(url);
    const select = document.getElementById('declaracaoAlunoSelect');
    if (select) {
      const alunos = data.alunos || [];
      select.innerHTML = '<option value="">Selecione o aluno...</option>' + 
        alunos.map(a => `<option value="${a.id}">${a.nome} (Matrícula #${a.id})</option>`).join('');

      // Se houver alunos e nenhum selecionado, seleciona o primeiro
      if (alunos.length > 0 && !select.value) {
        select.value = alunos[0].id;
        await this.carregarDeclaracao();
      }
    }
  },

  async filtrarAlunosDeclaracao() {
    const turmaId = document.getElementById('declaracaoTurmaSelect')?.value || '';
    await this.carregarAlunosParaDeclaracao(turmaId);
  },

  onTipoDeclaracaoChange() {
    const tipo = document.getElementById('declaracaoTipoSelect')?.value || 'matricula';
    const painelExtras = document.getElementById('declaracaoCamposExtras');
    const campoComp = document.getElementById('campoExtraComparecimento');
    const campoResc = document.getElementById('campoExtraRescisao');

    if (tipo === 'comparecimento') {
      painelExtras?.classList.remove('d-none');
      campoComp?.classList.remove('d-none');
      campoResc?.classList.add('d-none');
    } else if (tipo === 'rescisao') {
      painelExtras?.classList.remove('d-none');
      campoComp?.classList.add('d-none');
      campoResc?.classList.remove('d-none');
    } else {
      painelExtras?.classList.add('d-none');
      campoComp?.classList.add('d-none');
      campoResc?.classList.add('d-none');
    }

    this.carregarDeclaracao();
  },

  atualizarTextoDeclaracao() {
    if (this.cacheDeclaracaoDados) {
      this.renderDeclaracao(this.cacheDeclaracaoDados);
    }
  },

  async carregarDeclaracao() {
    const alunoId = document.getElementById('declaracaoAlunoSelect')?.value;
    const tipo = document.getElementById('declaracaoTipoSelect')?.value || 'matricula';
    const container = document.getElementById('declaracaoDocumentContainer');

    if (!alunoId) {
      if (container) {
        container.innerHTML = `
          <div class="text-center text-muted p-5 bg-white rounded border shadow-sm">
            <i class="bi bi-file-earmark-text display-4 text-secondary mb-2 d-block"></i>
            <h5 class="fw-bold text-secondary">Nenhum Aluno Selecionado</h5>
            <p class="mt-2 text-muted">Selecione o tipo de declaração e o aluno acima para visualizar e imprimir o documento timbrado oficial.</p>
          </div>
        `;
      }
      return;
    }

    try {
      const data = await this.api(`/api/documentos/declaracao?tipo=${encodeURIComponent(tipo)}&aluno_id=${encodeURIComponent(alunoId)}`);
      if (!data || data.error) {
        alert(data.error || 'Erro ao carregar dados do documento');
        return;
      }
      this.cacheDeclaracaoDados = data;
      this.renderDeclaracao(data);
    } catch (e) {
      console.error('Erro ao carregar declaração:', e);
      if (container) {
        container.innerHTML = `<div class="alert alert-danger m-3">Erro ao carregar declaração: ${e.message}</div>`;
      }
    }
  },

  renderDeclaracao(data) {
    const container = document.getElementById('declaracaoDocumentContainer');
    if (!container) return;

    const tipo = document.getElementById('declaracaoTipoSelect')?.value || 'matricula';
    const a = data.aluno || {};
    const t = a.nome_turma || a.etapa || '-';
    const turno = a.turma_turno || a.turno || '-';
    const rf = data.resp_fin || {};
    const ra = data.resp_acad || {};

    // Cabeçalho Oficial Padrão Timbrado
    const headerHtml = `
      <div class="print-header">
        <div class="row align-items-center">
          <div class="col-3 text-start">
            <img src="/static/img/LogoAteniense.png" alt="Colégio Ateniense" style="max-height: 80px;" />
          </div>
          <div class="col-9 text-end">
            <h4 class="fw-bold mb-0 text-dark" style="font-family: 'Times New Roman', serif; letter-spacing: 0.5px;">CENTRO EDUCACIONAL ATENIENSE</h4>
            <p class="mb-0 text-muted small" style="font-size: 9pt;">Educação Infantil e Ensino Fundamental I</p>
            <p class="mb-0 text-muted small" style="font-size: 8pt;">Resolução Nº 021/99 – CEE/AM | CNPJ: 35.062.987/0001-53</p>
            <p class="mb-0 text-muted small" style="font-size: 8pt;">Rua Rosalind Franklin, 25 - Parque 10 de Novembro - CEP: 69.054-730 - Manaus/AM</p>
            <p class="mb-0 text-muted small" style="font-size: 8pt;">Tel: (92) 98450-3988 / (92) 98452-3953 | E-mail: ceateniensep10@hotmail.com</p>
          </div>
        </div>
        <hr style="border-top: 2px solid #000; margin: 12px 0 0;" />
      </div>
    `;

    let corpoHtml = '';

    if (tipo === 'matricula') {
      corpoHtml = `
        <div class="print-title mt-4 mb-4">DECLARAÇÃO DE MATRÍCULA</div>
        <div class="print-body" style="font-size: 13pt; line-height: 2; text-align: justify;">
          <p>
            Declaramos, para os devidos fins e a quem possa interessar, que o(a) aluno(a) <strong>${a.nome_aluno || '-'}</strong>, 
            nascido(a) em <strong>${a.datanasc_formatada || '-'}</strong>, natural de <strong>${a.cidade || 'MANAUS'} / ${a.UF || 'AM'}</strong>, 
            nacionalidade <strong>${a.nacionalidade || 'BRASILEIRA'}</strong>, filho(a) de <strong>${a.pai || 'Não informado'}</strong> 
            e de <strong>${a.mae || 'Não informada'}</strong>, residente na ${a.rua || ''}, nº ${a.numero || 'S/N'}, 
            bairro ${a.bairro || ''}, CEP: ${a.cep || ''}, encontra-se regularmente matriculado(a) e com frequência ativa neste 
            Estabelecimento de Ensino no Ano Letivo de <strong>${data.ano_letivo}</strong>, cursando o <strong>${t}</strong>, 
            no turno <strong>${turno}</strong>.
          </p>
          <p>
            Por ser a expressão da verdade, firmamos a presente declaração para que produza seus regulares efeitos legais.
          </p>
          <div class="p-3 my-4 bg-light rounded border text-muted" style="font-size: 9.5pt; line-height: 1.5;">
            <strong>OBSERVAÇÕES LEGAIS:</strong> Expedida em conformidade com a Lei de Diretrizes e Bases da Educação Nacional 
            (Lei Federal nº 9.394/1996), Leis Federais nº 11.114/2005 e nº 11.274/2006, e Resolução nº 098/2005 do Conselho 
            Estadual de Educação do Amazonas (CEE/AM).
          </div>
          <p class="small text-muted text-end">
            <em>Declaração válida por 30 (trinta) dias a contar da data de sua expedição.</em>
          </p>
        </div>
        <div class="text-end my-4" style="font-size: 12pt;">
          <strong>${data.data_extenso}</strong>
        </div>
        <div class="print-footer mt-5 pt-3">
          <div class="row">
            <div class="col-6"><div class="print-signature">Secretaria Escolar</div></div>
            <div class="col-6"><div class="print-signature">Direção Pedagógica</div></div>
          </div>
        </div>
      `;
    } else if (tipo === 'quitacao') {
      const responsavelNome = rf.nome || a.mae || a.pai || 'Responsável Financeiro';
      const responsavelCpf = rf.cpf ? `portador(a) do CPF/MF nº ${rf.cpf}` : 'inscrito(a) sob o cadastro escolar';
      corpoHtml = `
        <div class="print-title mt-4 mb-4">DECLARAÇÃO DE QUITAÇÃO DE DÉBITOS</div>
        <div class="print-body" style="font-size: 13pt; line-height: 2; text-align: justify;">
          <p>
            O <strong>CENTRO EDUCACIONAL ATENIENSE</strong>, entidade mantenedora de ensino devidamente credenciada pela 
            Resolução CEE/AM nº 021/99, inscrita no CNPJ/MF sob o nº 35.062.987/0001-53, declara para os devidos fins de direito que:
          </p>
          <p>
            O(A) estudante <strong>${a.nome_aluno || '-'}</strong>, Matrícula nº <strong>#${a.ID_aluno}</strong>, regularmente matriculado(a) 
            no <strong>${t}</strong>, turno <strong>${turno}</strong>, sob a responsabilidade financeira do(a) Sr.(a) 
            <strong>${responsavelNome}</strong>, ${responsavelCpf}, encontra-se plenamente em dia com todas as suas obrigações financeiras 
            e mensalidades escolares relativas ao Ano Letivo de <strong>${data.ano_letivo}</strong>.
          </p>
          <p>
            Atestamos, para todos os efeitos de comprovação legal, matrícula ou transferência, que <strong>NÃO CONSTAM DÉBITOS</strong>, 
            parcelas pendentes ou quaisquer obrigações pecuniárias em aberto vinculadas ao prontuário do(a) estudante junto à Tesouraria 
            deste Estabelecimento de Ensino até a presente data, outorgando-se a respectiva quitação de débitos.
          </p>
          <p class="small text-muted text-end my-3">
            <em>Declaração válida por 30 (trinta) dias para fins de comprovação e transferência escolar.</em>
          </p>
        </div>
        <div class="text-end my-4" style="font-size: 12pt;">
          <strong>${data.data_extenso}</strong>
        </div>
        <div class="print-footer mt-5 pt-3">
          <div class="row">
            <div class="col-6"><div class="print-signature">Setor Financeiro / Tesouraria</div></div>
            <div class="col-6"><div class="print-signature">Direção Geral</div></div>
          </div>
        </div>
      `;
    } else if (tipo === 'comparecimento') {
      const respInputNome = document.getElementById('declRespNome')?.value || rf.nome || ra.nome || a.mae || a.pai || 'Responsável';
      const respInputDoc = document.getElementById('declRespDoc')?.value || rf.cpf || ra.cpf || 'Apresentado na Secretaria';
      const respInputHora = document.getElementById('declRespHora')?.value || (turno === 'VESPERTINO' ? '14:00 às 15:30' : '08:00 às 09:30');
      const respInputMotivo = document.getElementById('declRespMotivo')?.value || 'Atendimento pedagógico, alinhamento curricular e acompanhamento escolar';

      corpoHtml = `
        <div class="print-title mt-4 mb-4">DECLARAÇÃO DE COMPARECIMENTO</div>
        <div class="print-body" style="font-size: 13pt; line-height: 2; text-align: justify;">
          <p>
            Declaramos, para os devidos fins de comprovação e justificação de ausência perante empregador, repartição pública ou autoridade 
            competente, que o(a) Sr.(a) <strong>${respInputNome}</strong>, portador(a) do documento de identificação RG/CPF nº 
            <strong>${respInputDoc}</strong>, na condição de responsável legal pelo(a) aluno(a) <strong>${a.nome_aluno || '-'}</strong>, 
            matriculado(a) no <strong>${t}</strong>, turno <strong>${turno}</strong>, compareceu a este Estabelecimento de Ensino 
            no dia de hoje, <strong>${data.hoje_formatado}</strong>, permanecendo nas dependências escolares durante o período 
            das <strong>${respInputHora}</strong>.
          </p>
          <p>
            <strong>Finalidade / Assunto tratado:</strong> ${respInputMotivo}.
          </p>
          <p>
            Por ser a expressão fiel da verdade, expedimos a presente declaração que segue devidamente assinada e chancelada pela 
            coordenação deste Centro Educacional.
          </p>
        </div>
        <div class="text-end my-5" style="font-size: 12pt;">
          <strong>${data.data_extenso}</strong>
        </div>
        <div class="print-footer mt-5 pt-4">
          <div class="row justify-content-center">
            <div class="col-8"><div class="print-signature">Secretaria Escolar / Coordenação Pedagógica</div></div>
          </div>
        </div>
      `;
    } else if (tipo === 'frequencia') {
      const faltas = data.total_faltas || 0;
      corpoHtml = `
        <div class="print-title mt-4 mb-4">DECLARAÇÃO DE FREQUÊNCIA ESCOLAR</div>
        <div class="print-body" style="font-size: 13pt; line-height: 2; text-align: justify;">
          <p>
            Declaramos, para os devidos fins de direito e comprovação institucional (inclusive para fins de benefícios sociais, comprovação 
            trabalhista ou acompanhamento pedagógico), que o(a) aluno(a) <strong>${a.nome_aluno || '-'}</strong>, Matrícula nº 
            <strong>#${a.ID_aluno}</strong>, nascido(a) em <strong>${a.datanasc_formatada || '-'}</strong>, filho(a) de 
            <strong>${a.pai || 'Não informado'}</strong> e de <strong>${a.mae || 'Não informada'}</strong>, é aluno(a) assíduo(a) deste 
            Estabelecimento de Ensino, regularmente matriculado(a) e frequentando com assiduidade satisfatória as aulas do 
            <strong>${t}</strong>, no turno <strong>${turno}</strong>, durante o Ano Letivo de <strong>${data.ano_letivo}</strong>.
          </p>
          <p>
            Atestamos que o(a) referido(a) estudante cumpre integralmente as exigências de frequência escolar previstas no Artigo 24, inciso VI 
            da Lei Federal nº 9.394/1996 (LDB), mantendo participação nas atividades letivas programadas no calendário pedagógico oficial.
          </p>
          <div class="p-3 my-3 bg-light rounded border" style="font-size: 11pt; line-height: 1.6;">
            <div><strong>Total de Faltas Registradas no Histórico:</strong> ${faltas} falta(s) letiva(s)</div>
            <div><strong>Situação de Assiduidade:</strong> Regular / Apto(a)</div>
          </div>
          <p class="small text-muted text-end my-2">
            <em>Declaração válida por 30 (trinta) dias a contar de sua emissão.</em>
          </p>
        </div>
        <div class="text-end my-4" style="font-size: 12pt;">
          <strong>${data.data_extenso}</strong>
        </div>
        <div class="print-footer mt-5 pt-3">
          <div class="row">
            <div class="col-6"><div class="print-signature">Secretaria Escolar</div></div>
            <div class="col-6"><div class="print-signature">Coordenação Pedagógica</div></div>
          </div>
        </div>
      `;
    } else if (tipo === 'transferencia') {
      const notas = data.materias_notas || [];
      corpoHtml = `
        <div class="print-title mt-3 mb-2 text-center">GUIA DE TRANSFERÊNCIA ESCOLAR</div>
        <p class="text-center text-muted small mb-3">HISTÓRICO ESCOLAR E APROVEITAMENTO PEDAGÓGICO</p>
        
        <div class="p-2 mb-3 bg-light rounded border font-monospace" style="font-size: 10pt; line-height: 1.6;">
          <div class="row">
            <div class="col-8"><strong>ALUNO(A):</strong> ${a.nome_aluno || '-'}</div>
            <div class="col-4"><strong>MATRÍCULA:</strong> #${a.ID_aluno}</div>
            <div class="col-6"><strong>NASCIMENTO:</strong> ${a.datanasc_formatada || '-'} (${a.cidade || 'Manaus'}/${a.UF || 'AM'})</div>
            <div class="col-6"><strong>NACIONALIDADE:</strong> ${a.nacionalidade || 'Brasileira'}</div>
            <div class="col-6"><strong>FILIAÇÃO:</strong> ${a.mae || a.pai || '-'}</div>
            <div class="col-6"><strong>ANO LETIVO:</strong> ${data.ano_letivo}</div>
            <div class="col-6"><strong>SÉRIE / ETAPA:</strong> ${t}</div>
            <div class="col-6"><strong>TURNO:</strong> ${turno}</div>
          </div>
        </div>

        <div class="print-body mb-3" style="font-size: 11pt; line-height: 1.6; text-align: justify;">
          <p class="m-0">
            O CENTRO EDUCACIONAL ATENIENSE confere a presente <strong>GUIA DE TRANSFERÊNCIA</strong> ao(à) estudante acima nominado(a), 
            tendo sua transferência solicitada formalmente por seu responsável legal, estando apto(a), de acordo com a legislação em vigor, 
            a prosseguir seus estudos em qualquer outro Estabelecimento de Ensino devidamente legalizado do país.
          </p>
        </div>

        <table class="table table-bordered table-sm text-center align-middle mb-3" style="font-size: 9.5pt;">
          <thead class="table-light">
            <tr>
              <th class="text-start">COMPONENTE CURRICULAR</th>
              <th>1º BIM</th>
              <th>2º BIM</th>
              <th>3º BIM</th>
              <th>4º BIM</th>
              <th>MÉDIA</th>
              <th>SITUAÇÃO</th>
            </tr>
          </thead>
          <tbody>
            ${notas.length > 0 ? notas.map(m => `
              <tr>
                <td class="text-start fw-bold">${m.materia}</td>
                <td>${m.b1 || '-'}</td>
                <td>${m.b2 || '-'}</td>
                <td>${m.b3 || '-'}</td>
                <td>${m.b4 || '-'}</td>
                <td class="fw-bold">${m.media || '-'}</td>
                <td><span class="badge ${m.situacao === 'Aprovado' ? 'bg-success' : (m.situacao === 'Recuperação' ? 'bg-warning text-dark' : 'bg-secondary')}">${m.situacao}</span></td>
              </tr>
            `).join('') : `
              <tr><td colspan="7" class="text-muted py-2">Registros acadêmicos em fase de consolidação pedagógica.</td></tr>
            `}
          </tbody>
        </table>

        <div class="p-2 mb-3 bg-light rounded border text-muted" style="font-size: 8.5pt; line-height: 1.4;">
          <strong>BASE LEGAL:</strong> A nota mínima para aprovação institucional é 6,0 (seis inteiros). Transferência expedida de acordo com 
          as Leis Federais nº 9.394/96, nº 11.114/2005 e nº 11.274/2006, e Res. nº 098/2005 do CEE/AM. Documento isento de autenticação cartorária 
          conforme Art. 70 da Resolução 99/97 - CEE/AM.
        </div>

        <div class="text-end my-3" style="font-size: 11pt;">
          <strong>${data.data_extenso}</strong>
        </div>

        <div class="print-footer mt-4 pt-2">
          <div class="row">
            <div class="col-6"><div class="print-signature">Secretário(a) Escolar</div></div>
            <div class="col-6"><div class="print-signature">Diretor(a) Pedagógico(a)</div></div>
          </div>
        </div>
      `;
    } else if (tipo === 'rescisao') {
      const respNome = rf.nome || ra.nome || a.mae || a.pai || 'Responsável Legal';
      const respCpf = rf.cpf || ra.cpf || 'Cadastrado no Sistema';
      const motivoResc = document.getElementById('declRescisaoMotivo')?.value || 'Transferência de domicílio / Solicitação de interesse particular da família';
      const obsResc = document.getElementById('declRescisaoObs')?.value || '';

      corpoHtml = `
        <div class="print-title mt-3 mb-2 text-center">TERMO DE RESCISÃO CONTRATUAL</div>
        <p class="text-center text-muted small mb-3">CONTRATO DE PRESTAÇÃO DE SERVIÇOS EDUCACIONAIS</p>

        <div class="print-body" style="font-size: 11.5pt; line-height: 1.8; text-align: justify;">
          <p>
            Pelo presente instrumento particular de distrato e encerramento contratual, de um lado:
          </p>
          <div class="p-2 bg-light rounded border mb-3" style="font-size: 10.5pt; line-height: 1.6;">
            <strong>CONTRATADA:</strong> <strong>CENTRO EDUCACIONAL ATENIENSE</strong>, pessoa jurídica de direito privado, inscrita no CNPJ/MF sob o nº 35.062.987/0001-53, com sede na Rua Rosalind Franklin, 25 - Parque 10 de Novembro, Manaus/AM;<br>
            <strong>CONTRATANTE / RESPONSÁVEL:</strong> <strong>${respNome}</strong>, inscrito(a) no CPF sob o nº <strong>${respCpf}</strong>, responsável legal pelo(a) estudante <strong>${a.nome_aluno || '-'}</strong>, Matrícula nº <strong>#${a.ID_aluno}</strong>, matriculado(a) no <strong>${t}</strong>, turno <strong>${turno}</strong>, Ano Letivo de <strong>${data.ano_letivo}</strong>.
          </div>
          <p>
            Têm entre si, justo e acordado, o presente <strong>TERMO DE RESCISÃO CONTRATUAL</strong>, mediante as seguintes cláusulas:
          </p>
          <p>
            <strong>CLÁUSULA PRIMEIRA:</strong> Fica formalmente rescindido e cancelado, a contar desta data, o Contrato de Prestação de Serviços Educacionais celebrado para o ano letivo em curso, cancelando-se a matrícula do(a) estudante e desobrigando o Contratante das parcelas com vencimento posterior à data deste termo.
          </p>
          <p>
            <strong>CLÁUSULA SEGUNDA:</strong> O Contratante declara ciência de que as parcelas e encargos educacionais vencidos até a data deste cancelamento permanecem sob sua responsabilidade, dando a Contratada quitação das mensalidades devidamente pagas até o presente momento.
          </p>
          <p>
            <strong>CLÁUSULA TERCEIRA:</strong> A expedição da documentação escolar oficial de transferência e histórico pedagógico será disponibilizada pela Secretaria Escolar em estrita observância aos prazos regimentais.
          </p>
          <p>
            <strong>Motivo declarado da rescisão:</strong> ${motivoResc}.
          </p>
          ${obsResc ? `<p><strong>Observações complementares:</strong> ${obsResc}</p>` : ''}
          <p>
            E, por estarem plenamente de acordo com todas as disposições, as partes firmam o presente termo em 2 (duas) vias de igual teor e forma.
          </p>
        </div>

        <div class="text-end my-4" style="font-size: 11pt;">
          <strong>${data.data_extenso}</strong>
        </div>

        <div class="print-footer mt-4 pt-3">
          <div class="row">
            <div class="col-6"><div class="print-signature">Contratante / Responsável Legal</div></div>
            <div class="col-6"><div class="print-signature">Centro Educacional Ateniense</div></div>
          </div>
        </div>
      `;
    }

    container.innerHTML = `
      <div class="print-document">
        ${headerHtml}
        ${corpoHtml}
      </div>
    `;
  },

  // ================= SECRETARIA: CONTRATOS E TERMOS OFICIAIS =================
  cacheContratoDados: null,
  contratosDBLista: [],
  alunoContratosAtuais: [],
  alunoSelecionadoContratos: null,

  async setupContratos() {
    try {
      // 1. Carrega turmas no select de filtro
      const dataTurmas = await this.api('/api/turmas');
      const selTurma = document.getElementById('contratoTurmaSelect');
      if (selTurma) {
        selTurma.innerHTML = '<option value="">Todas as Turmas...</option>' + 
          (dataTurmas.turmas || []).map(t => {
            const anoStr = t.ano_letivo ? ` (${t.ano_letivo})` : '';
            return `<option value="${t.id}">${t.nome_turma}${anoStr}</option>`;
          }).join('');
      }

      // 2. Carrega lista inicial de alunos no select
      await this.carregarAlunosParaContratos();

      // 3. Carrega lista de contratos do DB para o badge e tabela geral
      await this.carregarTabelaContratos();

    } catch (e) {
      console.error('Erro ao configurar tela de contratos:', e);
    }
  },

  alternarModoContratos(modo) {
    const btnDoc = document.getElementById('btnModoContratoDoc');
    const btnTab = document.getElementById('btnModoContratoTabela');
    const divDoc = document.getElementById('contratoDocViewMode');
    const divTab = document.getElementById('contratoTableViewMode');

    if (modo === 'doc') {
      btnDoc?.classList.add('active');
      btnTab?.classList.remove('active');
      divDoc?.classList.remove('d-none');
      divTab?.classList.add('d-none');
    } else {
      btnTab?.classList.add('active');
      btnDoc?.classList.remove('active');
      divTab?.classList.remove('d-none');
      divDoc?.classList.add('d-none');
      this.carregarTabelaContratos();
    }
  },

  async carregarAlunosParaContratos(turmaId = '') {
    try {
      const url = turmaId ? `/api/turmas/${encodeURIComponent(turmaId)}/alunos` : '/api/alunos?limit=350';
      const data = await this.api(url);
      const select = document.getElementById('contratoAlunoSelect');
      if (select) {
        const alunos = data.alunos || [];
        select.innerHTML = '<option value="">Ou selecione da lista...</option>' + 
          alunos.map(a => `<option value="${a.id}">${a.nome} (Matrícula #${a.id})</option>`).join('');
      }
    } catch (e) {
      console.error('Erro ao carregar alunos para contratos:', e);
    }
  },

  async filtrarAlunosContratos() {
    const turmaId = document.getElementById('contratoTurmaSelect')?.value || '';
    await this.carregarAlunosParaContratos(turmaId);
  },

  async consultarContratosPorAluno() {
    const termo = document.getElementById('inputBuscaAlunoContratos')?.value?.trim() || '';
    const containerResultados = document.getElementById('containerResultadosBuscaAlunos');
    const listaResultados = document.getElementById('listaAlunosResultadosBusca');
    const docContainer = document.getElementById('contratoDocumentContainer');

    if (!termo) {
      alert('Digite o nome ou a matrícula do aluno para consultar.');
      document.getElementById('inputBuscaAlunoContratos')?.focus();
      return;
    }

    try {
      if (docContainer) {
        docContainer.innerHTML = `
          <div class="text-center text-muted p-5 bg-white rounded border shadow-sm">
            <div class="spinner-border text-primary mb-3" role="status"></div>
            <p class="mb-0">Consultando aluno e buscando contratos vinculados no banco de dados...</p>
          </div>
        `;
      }

      const res = await this.api(`/api/documentos/alunos-busca?q=${encodeURIComponent(termo)}`);
      const alunos = res.alunos || [];

      if (alunos.length === 0) {
        containerResultados?.classList.add('d-none');
        document.getElementById('painelAlunoContratosVinculados')?.classList.add('d-none');
        if (docContainer) {
          docContainer.innerHTML = `
            <div class="alert alert-warning p-4 text-center">
              <i class="bi bi-person-x fs-3 mb-2 d-block"></i>
              <strong>Nenhum aluno encontrado para "${termo}".</strong>
              <p class="small text-muted mt-1 mb-0">Verifique a grafia do nome ou tente buscar pelo número de matrícula.</p>
            </div>
          `;
        }
        return;
      }

      if (alunos.length === 1) {
        containerResultados?.classList.add('d-none');
        await this.selecionarAlunoParaContratos(alunos[0].id);
      } else {
        // Exibe lista de múltiplos alunos encontrados
        if (listaResultados && containerResultados) {
          listaResultados.innerHTML = alunos.map(a => `
            <button type="button" class="list-group-item list-group-item-action d-flex justify-content-between align-items-center py-2" onclick="App.selecionarAlunoParaContratos(${a.id})">
              <div>
                <strong>${a.nome}</strong> <span class="badge bg-secondary ms-1">#${a.id}</span>
                <div class="small text-muted">
                  ${a.nome_turma || a.etapa || 'Turma não informada'} • Turno: ${a.turno || '-'} • Resp: ${a.resp_fin_nome || 'Não informado'}
                </div>
              </div>
              <span class="badge ${a.total_contratos > 0 ? 'bg-success' : 'bg-light text-dark border'} rounded-pill">
                ${a.total_contratos} contrato(s)
              </span>
            </button>
          `).join('');
          containerResultados.classList.remove('d-none');
        }

        // Abre automaticamente o primeiro aluno da lista
        await this.selecionarAlunoParaContratos(alunos[0].id);
      }

    } catch (e) {
      console.error('Erro na consulta por aluno:', e);
      if (docContainer) {
        docContainer.innerHTML = `
          <div class="alert alert-danger p-4 text-center">
            <strong>Falha na consulta:</strong> ${e.message}
          </div>
        `;
      }
    }
  },

  async onAlunoSelectDropdownChange() {
    const alunoId = document.getElementById('contratoAlunoSelect')?.value;
    if (alunoId) {
      await this.selecionarAlunoParaContratos(alunoId);
    }
  },

  async selecionarAlunoParaContratos(alunoId) {
    const containerResultados = document.getElementById('containerResultadosBuscaAlunos');
    const painelVinculados = document.getElementById('painelAlunoContratosVinculados');
    const gridContratos = document.getElementById('gridContratosVinculados');
    const selAluno = document.getElementById('contratoAlunoSelect');
    const selContrato = document.getElementById('contratoMensalidadeSelect');

    try {
      // 1. Busca dados do aluno
      const infoAluno = await this.api(`/api/documentos/dados?aluno_id=${encodeURIComponent(alunoId)}`);
      if (!infoAluno || !infoAluno.aluno) {
        alert('Aluno não encontrado.');
        return;
      }

      this.alunoSelecionadoContratos = infoAluno;
      const a = infoAluno.aluno;
      const rf = infoAluno.resp_fin || {};
      const ra = infoAluno.resp_acad || {};

      // Sincroniza campos de busca
      const inputBusca = document.getElementById('inputBuscaAlunoContratos');
      if (inputBusca) inputBusca.value = a.nome_aluno;
      if (selAluno) selAluno.value = a.ID_aluno;

      // 2. Busca todos os contratos vinculados a esse aluno
      const dataContratos = await this.api(`/api/documentos/contratos?aluno_id=${encodeURIComponent(alunoId)}`);
      const contratos = dataContratos.contratos || [];
      this.alunoContratosAtuais = contratos;

      // 3. Atualiza Banner do Aluno
      painelVinculados?.classList.remove('d-none');
      document.getElementById('bannerAlunoId').textContent = a.ID_aluno;
      document.getElementById('bannerAlunoNome').textContent = a.nome_aluno;
      document.getElementById('bannerAlunoDetalhes').innerHTML = `
        <strong>Turma:</strong> ${a.nome_turma || a.etapa || '-'} | 
        <strong>Turno:</strong> ${a.turno || '-'} | 
        <strong>Resp. Financeiro:</strong> ${rf.nome || 'Não informado'} ${rf.cpf ? '(' + rf.cpf + ')' : ''} | 
        <strong>Resp. Acadêmico:</strong> ${ra.nome || 'Não informado'}
      `;
      document.getElementById('badgeTotalContratosAluno').textContent = `${contratos.length} contrato(s) vinculado(s)`;

      // 4. Renderiza Grid de Contratos Vinculados
      if (gridContratos) {
        if (contratos.length === 0) {
          gridContratos.innerHTML = `
            <div class="col-12">
              <div class="alert alert-warning mb-0 p-3 d-flex align-items-center justify-content-between">
                <div>
                  <i class="bi bi-info-circle-fill me-2 fs-5"></i>
                  <strong>Nenhum contrato cadastrado no banco de dados para este(a) aluno(a).</strong>
                  <div class="small mt-1 text-dark">Você pode visualizar o Termo de Responsabilidade ou a Ficha Cadastral abaixo com base no cadastro do discente.</div>
                </div>
                <button class="btn btn-primary btn-sm" onclick="App.carregarContrato(${a.ID_aluno}, null, 'termo')">
                  <i class="bi bi-shield-check me-1"></i> Abrir Termo de Responsabilidade
                </button>
              </div>
            </div>
          `;
          if (selContrato) {
            selContrato.innerHTML = '<option value="">Sem contrato vinculado no DB (Emitir Padrão)</option>';
          }
          await this.carregarContrato(a.ID_aluno, null, 'termo');
          return;
        }

        gridContratos.innerHTML = contratos.map((c, idx) => {
          const pagas = c.parcelas_pagas || 0;
          const totalParc = c.n_parcelas || 12;
          const badgeColor = pagas >= totalParc ? 'bg-success' : (pagas > 0 ? 'bg-info text-dark' : 'bg-warning text-dark');
          
          let tipoSugerido = 'normal';
          const tUp = (c.contrato_turno || '').toUpperCase();
          if (String(c.ano_letivo) === '2027') {
            tipoSugerido = '2027';
          } else if (tUp.includes('INTEGRAL')) {
            tipoSugerido = 'integral';
          } else if (tUp.includes('M. PERIODO') || tUp.includes('MEIO')) {
            tipoSugerido = 'meio_periodo';
          }

          return `
            <div class="col-md-6 col-lg-4">
              <div class="card h-100 border shadow-sm ${idx === 0 ? 'border-primary' : ''}" id="cardContrato_${c.ID_mensalidade}">
                <div class="card-header bg-white py-2 d-flex justify-content-between align-items-center">
                  <span class="fw-bold text-dark"><i class="bi bi-file-earmark-ruled text-primary me-1"></i> Contrato #${c.ID_mensalidade}</span>
                  <span class="badge bg-primary fs-7">Ano ${c.ano_letivo}</span>
                </div>
                <div class="card-body p-3" style="font-size: 9pt;">
                  <div class="mb-1"><strong>Curso / Etapa:</strong> ${c.curso || c.aluno_etapa || '-'}</div>
                  <div class="mb-1"><strong>Turno:</strong> <span class="badge bg-light text-dark border">${c.contrato_turno || 'NORMAL'}</span></div>
                  <div class="mb-1"><strong>Plano:</strong> ${c.n_parcelas}x de <strong class="text-primary">${c.valor_parcela_fmt}</strong></div>
                  <div class="mb-1"><strong>Total:</strong> ${c.valor_total_fmt}</div>
                  <div class="mb-2"><strong>Situação:</strong> <span class="badge ${badgeColor}">${pagas}/${totalParc} pagas</span></div>
                  
                  <div class="d-flex flex-wrap gap-1 mt-2 pt-2 border-top">
                    <button class="btn btn-sm btn-primary flex-grow-1" onclick="App.ativarContratoVinculado(${c.ID_mensalidade}, '${tipoSugerido}')">
                      <i class="bi bi-file-earmark-text"></i> Contrato
                    </button>
                    <button class="btn btn-sm btn-outline-secondary" title="Termo" onclick="App.ativarContratoVinculado(${c.ID_mensalidade}, 'termo')">
                      <i class="bi bi-shield-check"></i> Termo
                    </button>
                    <button class="btn btn-sm btn-outline-success" title="Carnê" onclick="App.ativarContratoVinculado(${c.ID_mensalidade}, 'carne')">
                      <i class="bi bi-receipt"></i> Carnê
                    </button>
                    <button class="btn btn-sm btn-outline-info" title="Ficha" onclick="App.ativarContratoVinculado(${c.ID_mensalidade}, 'ficha')">
                      <i class="bi bi-person-vcard"></i> Ficha
                    </button>
                  </div>
                </div>
              </div>
            </div>
          `;
        }).join('');
      }

      // 5. Preenche select de Contrato Ativo
      if (selContrato) {
        selContrato.innerHTML = contratos.map(c => 
          `<option value="${c.ID_mensalidade}">Contrato #${c.ID_mensalidade} - Ano Letivo ${c.ano_letivo} (${c.contrato_turno || 'Normal'}) - ${c.valor_parcela_fmt}/mês</option>`
        ).join('');
      }

      // 6. Carrega o primeiro contrato (mais recente)
      const primeiro = contratos[0];
      let tipoSugerido = 'normal';
      const tUp = (primeiro.contrato_turno || '').toUpperCase();
      if (String(primeiro.ano_letivo) === '2027') {
        tipoSugerido = '2027';
      } else if (tUp.includes('INTEGRAL')) {
        tipoSugerido = 'integral';
      } else if (tUp.includes('M. PERIODO') || tUp.includes('MEIO')) {
        tipoSugerido = 'meio_periodo';
      }

      await this.ativarContratoVinculado(primeiro.ID_mensalidade, tipoSugerido, false);

    } catch (e) {
      console.error('Erro ao selecionar aluno para contratos:', e);
    }
  },

  tipoDocumentoAtivo: 'contrato',

  selecionarTipoDocumentoAtivo(tipoBase) {
    this.tipoDocumentoAtivo = tipoBase;

    // Atualiza botões superiores
    ['contrato', 'termo', 'carne', 'ficha'].forEach(t => {
      const btn = document.getElementById(`btnTipo_${t}`);
      if (btn) {
        if (t === tipoBase) {
          btn.classList.add('btn-primary', 'active');
          btn.classList.remove('btn-outline-primary');
        } else {
          btn.classList.remove('btn-primary', 'active');
          btn.classList.add('btn-outline-primary');
        }
      }
    });

    const mensalidadeId = document.getElementById('contratoMensalidadeSelect')?.value || '';
    const alunoId = this.alunoSelecionadoContratos?.aluno?.ID_aluno || document.getElementById('contratoAlunoSelect')?.value;

    let tipoFinal = tipoBase;
    if (tipoBase === 'contrato') {
      const contratoAtivo = this.alunoContratosAtuais.find(c => String(c.ID_mensalidade) === String(mensalidadeId)) || this.alunoContratosAtuais[0];
      if (contratoAtivo) {
        const tUp = (contratoAtivo.contrato_turno || '').toUpperCase();
        if (String(contratoAtivo.ano_letivo) === '2027') {
          tipoFinal = '2027';
        } else if (tUp.includes('INTEGRAL')) {
          tipoFinal = 'integral';
        } else if (tUp.includes('M. PERIODO') || tUp.includes('MEIO')) {
          tipoFinal = 'meio_periodo';
        } else {
          tipoFinal = 'normal';
        }
      } else {
        tipoFinal = 'normal';
      }
    }

    this.carregarContrato(alunoId, mensalidadeId, tipoFinal, true);
  },

  async ativarContratoVinculado(mensalidadeId, tipo, abrirModal = true) {
    const selContrato = document.getElementById('contratoMensalidadeSelect');
    if (selContrato) selContrato.value = mensalidadeId;

    let tipoBase = tipo;
    if (['normal', 'integral', 'meio_periodo', '2027'].includes(tipo)) {
      tipoBase = 'contrato';
    }
    this.tipoDocumentoAtivo = tipoBase;

    // Atualiza botões superiores
    ['contrato', 'termo', 'carne', 'ficha'].forEach(t => {
      const btn = document.getElementById(`btnTipo_${t}`);
      if (btn) {
        if (t === tipoBase) {
          btn.classList.add('btn-primary', 'active');
          btn.classList.remove('btn-outline-primary');
        } else {
          btn.classList.remove('btn-primary', 'active');
          btn.classList.add('btn-outline-primary');
        }
      }
    });

    // Destaca o card ativo
    document.querySelectorAll('[id^="cardContrato_"]').forEach(el => el.classList.remove('border-primary', 'bg-light'));
    const cardAtivo = document.getElementById(`cardContrato_${mensalidadeId}`);
    if (cardAtivo) {
      cardAtivo.classList.add('border-primary', 'bg-light');
    }

    const alunoId = this.alunoSelecionadoContratos?.aluno?.ID_aluno || document.getElementById('contratoAlunoSelect')?.value;
    await this.carregarContrato(alunoId, mensalidadeId, tipo, abrirModal);
  },

  onContratoMensalidadeChanged() {
    const mensalidadeId = document.getElementById('contratoMensalidadeSelect')?.value;
    const alunoId = this.alunoSelecionadoContratos?.aluno?.ID_aluno || document.getElementById('contratoAlunoSelect')?.value;
    if (mensalidadeId) {
      this.selecionarTipoDocumentoAtivo(this.tipoDocumentoAtivo || 'contrato');
    } else {
      this.carregarContrato(alunoId, null, this.tipoDocumentoAtivo || 'contrato', true);
    }
  },

  async carregarContrato(alunoIdForced = null, mensalidadeIdForced = null, tipoForced = null, abrirModal = true) {
    const alunoId = alunoIdForced || this.alunoSelecionadoContratos?.aluno?.ID_aluno || document.getElementById('contratoAlunoSelect')?.value;
    const mensalidadeId = mensalidadeIdForced || document.getElementById('contratoMensalidadeSelect')?.value || '';
    const tipo = tipoForced || this.tipoDocumentoAtivo || 'normal';
    const container = document.getElementById('contratoDocumentContainer');

    if (!alunoId && !mensalidadeId) {
      if (container) {
        container.innerHTML = `
          <div class="text-center text-muted p-5 bg-white rounded border shadow-sm">
            <i class="bi bi-person-search display-4 text-secondary mb-2 d-block"></i>
            <h5 class="fw-bold text-secondary">Nenhum Contrato Selecionado</h5>
            <p class="mt-2 text-muted">Consulte ou selecione um aluno para visualizar e imprimir o documento timbrado oficial.</p>
          </div>
        `;
      }
      return;
    }

    try {
      if (container) {
        container.innerHTML = `
          <div class="text-center text-muted p-4 bg-white rounded border shadow-sm">
            <div class="spinner-border spinner-border-sm text-primary mb-2" role="status"></div>
            <p class="mb-0 small">Buscando dados no sistema e gerando visualização oficial...</p>
          </div>
        `;
      }

      let url = `/api/documentos/contrato?tipo=${encodeURIComponent(tipo)}`;
      if (alunoId) url += `&aluno_id=${encodeURIComponent(alunoId)}`;
      if (mensalidadeId) url += `&mensalidade_id=${encodeURIComponent(mensalidadeId)}`;

      const data = await this.api(url);
      if (data.error) {
        if (container) {
          container.innerHTML = `
            <div class="alert alert-danger p-4 text-center">
              <i class="bi bi-exclamation-triangle-fill fs-3 mb-2 d-block"></i>
              <strong>Erro ao emitir documento:</strong> ${data.error}
            </div>
          `;
        }
        return;
      }

      this.cacheContratoDados = data;
      this.renderContrato(data, abrirModal);

    } catch (e) {
      console.error('Erro ao emitir documento de contrato:', e);
      if (container) {
        container.innerHTML = `
          <div class="alert alert-danger p-4 text-center">
            <strong>Falha de comunicação:</strong> ${e.message}
          </div>
        `;
      }
    }
  },

  async carregarTabelaContratos() {
    try {
      const busca = document.getElementById('inputBuscaContratosTabela')?.value || '';
      const ano = document.getElementById('selectAnoContratosTabela')?.value || '';
      const turno = document.getElementById('selectTurnoContratosTabela')?.value || '';

      let url = '/api/documentos/contratos?';
      if (ano) url += `ano=${encodeURIComponent(ano)}&`;
      if (turno) url += `turno=${encodeURIComponent(turno)}&`;
      if (busca) url += `busca=${encodeURIComponent(busca)}&`;

      const data = await this.api(url);
      const contratos = data.contratos || [];
      this.contratosDBLista = contratos;

      const badgeTop = document.getElementById('totalContratosBadge');
      const badgeTab = document.getElementById('tabelaContratosCount');
      if (badgeTop) badgeTop.textContent = `${data.total || contratos.length} contratos`;
      if (badgeTab) badgeTab.textContent = `${contratos.length} contrato(s) encontrado(s)`;

      const tbody = document.getElementById('tabelaContratosBody');
      if (!tbody) return;

      if (contratos.length === 0) {
        tbody.innerHTML = `
          <tr>
            <td colspan="10" class="text-center py-4 text-muted">
              Nenhum contrato encontrado para os filtros selecionados.
            </td>
          </tr>
        `;
        return;
      }

      tbody.innerHTML = contratos.map(c => {
        const pagas = c.parcelas_pagas || 0;
        const totalParc = c.n_parcelas || 12;
        const badgeColor = pagas >= totalParc ? 'bg-success' : (pagas > 0 ? 'bg-info text-dark' : 'bg-warning text-dark');
        
        // Define o tipo de contrato sugerido pelo turno e ano
        let tipoSugerido = 'normal';
        const tUp = (c.contrato_turno || '').toUpperCase();
        if (String(c.ano_letivo) === '2027') {
          tipoSugerido = '2027';
        } else if (tUp.includes('INTEGRAL')) {
          tipoSugerido = 'integral';
        } else if (tUp.includes('M. PERIODO') || tUp.includes('MEIO')) {
          tipoSugerido = 'meio_periodo';
        }

        return `
          <tr>
            <td class="ps-3 fw-bold text-muted">#${c.ID_mensalidade}</td>
            <td>
              <div class="fw-bold text-dark">${c.nome_aluno || 'Aluno sem nome'}</div>
              <small class="text-muted">Matrícula #${c.idaluno}</small>
            </td>
            <td>
              <div>${c.resp_nome || '<span class="text-muted fst-italic">Não informado</span>'}</div>
              <small class="text-muted">${c.resp_cpf ? 'CPF: ' + c.resp_cpf : ''}</small>
            </td>
            <td>${c.curso || c.aluno_etapa || c.nome_turma || '-'}</td>
            <td><span class="badge bg-light text-dark border">${c.contrato_turno || c.aluno_turno || 'NORMAL'}</span></td>
            <td class="text-center fw-bold">${c.ano_letivo}</td>
            <td class="text-end fw-bold text-primary">${c.valor_parcela_fmt}</td>
            <td class="text-end text-muted">${c.valor_total_fmt}</td>
            <td class="text-center">
              <span class="badge ${badgeColor}">${pagas}/${totalParc}</span>
            </td>
            <td class="pe-3 text-center">
              <div class="btn-group btn-group-sm" role="group">
                <button class="btn btn-outline-primary" title="Visualizar Contrato" onclick="App.visualizarContratoEspecifico(${c.ID_mensalidade}, ${c.idaluno}, '${tipoSugerido}')">
                  <i class="bi bi-file-earmark-text"></i> Contrato
                </button>
                <button class="btn btn-outline-secondary" title="Termo de Responsabilidade" onclick="App.visualizarContratoEspecifico(${c.ID_mensalidade}, ${c.idaluno}, 'termo')">
                  <i class="bi bi-shield-check"></i> Termo
                </button>
                <button class="btn btn-outline-success" title="Carnê Escolar" onclick="App.visualizarContratoEspecifico(${c.ID_mensalidade}, ${c.idaluno}, 'carne')">
                  <i class="bi bi-receipt"></i> Carnê
                </button>
                <button class="btn btn-outline-info" title="Ficha Individual" onclick="App.visualizarContratoEspecifico(${c.ID_mensalidade}, ${c.idaluno}, 'ficha')">
                  <i class="bi bi-person-vcard"></i> Ficha
                </button>
              </div>
            </td>
          </tr>
        `;
      }).join('');

    } catch (e) {
      console.error('Erro ao carregar tabela de contratos:', e);
    }
  },

  async visualizarContratoEspecifico(mensalidadeId, alunoId, tipo) {
    this.alternarModoContratos('doc');
    await this.selecionarAlunoParaContratos(alunoId);
    await this.ativarContratoVinculado(mensalidadeId, tipo, true);
  },

  renderContrato(data, abrirModal = true) {
    const container = document.getElementById('contratoDocumentContainer');
    const modalBody = document.getElementById('contratoModalBody');

    const tipo = data.tipo || 'normal';
    const a = data.aluno || {};
    const rf = data.resp_fin || {};
    const ra = data.resp_acad || {};
    const m = data.mensalidade || {};
    const c = data.contratada || {};

    let docHtml = '';
    let nomeTitulo = 'Contrato de Prestação de Serviços';

    const headerHtml = `
      <div class="print-header mb-2 pb-1" style="border-bottom: 2px solid #000 !important;">
        <div class="row align-items-center g-2">
          <div class="col-2 text-start">
            <img src="/static/img/LogoAteniense.png" class="print-logo" alt="Logo Ateniense" style="height: 50px;">
          </div>
          <div class="col-10 text-center pe-3">
            <h4 class="fw-bold mb-0 text-dark" style="letter-spacing: 0.5px; font-size: 13pt;">ESCOLA INFANTIL ATENIENSE</h4>
            <div class="fw-bold text-secondary" style="font-size: 8pt;">CENTRO EDUCACIONAL ATENIENSE | I. M. AZULAY ME</div>
            <div class="text-muted" style="font-size: 7.2pt; line-height: 1.2;">
              CNPJ: 35.062.987/0001-53 | Rua Rosalind Franklin, Nº 25 - Parque 10 de Novembro - Manaus/AM<br>
              Contato: (92) 98450-3988 | Email: ceateniensep10@hotmail.com
            </div>
          </div>
        </div>
      </div>
    `;

    // 1. CARNÊ ESCOLAR
    if (tipo === 'carne') {
      const parcelas = data.carne_parcelas || [];
      const respNome = rf.nome || ra.nome || 'Responsável Financeiro';
      const respCpf = rf.cpf || '-';
      const respEnd = `${rf.rua || a.rua || 'Rua'}, Nº ${rf.numero || a.numero || 'S/N'} - ${rf.bairro || a.bairro || 'Bairro'} - ${rf.cidade || a.cidade || 'Manaus'}/${rf.UF || a.UF || 'AM'}`;
      const cursoStr = m.curso || a.etapa || a.nome_turma || 'Educação Básica';
      const turnoStr = m.turno || a.turno || 'NORMAL';

      let slipsHtml = '';
      for (let i = 0; i < parcelas.length; i++) {
        const p = parcelas[i];
        slipsHtml += `
          <div class="carne-slip">
            <div class="row g-2">
              <!-- CANHOTO DA ESCOLA / RECIBO DO ALUNO (28%) -->
              <div class="col-3 carne-canhoto">
                <div class="text-center border-bottom pb-1 mb-1">
                  <strong style="font-size: 7.5pt; display: block;">ESCOLA ATENIENSE</strong>
                  <span style="font-size: 6.5pt; color: #555;">COMPROVANTE ESCOLAR</span>
                </div>
                <div class="carne-campo-box">
                  <span class="carne-campo-label">PARCELA</span>
                  <span class="carne-campo-valor text-primary">${p.parcela_str} (${data.ano_letivo})</span>
                </div>
                <div class="carne-campo-box">
                  <span class="carne-campo-label">VENCIMENTO</span>
                  <span class="carne-campo-valor">${p.vencimento_str}</span>
                </div>
                <div class="carne-campo-box">
                  <span class="carne-campo-label">VALOR DO DOCUMENTO</span>
                  <span class="carne-campo-valor text-success">${p.valor_fmt}</span>
                </div>
                <div class="carne-campo-box">
                  <span class="carne-campo-label">ALUNO(A)</span>
                  <span style="font-size: 7pt; font-weight: bold; display: block; overflow: hidden; text-overflow: ellipsis; white-space: nowrap;">${a.nome_aluno || '-'}</span>
                </div>
                <div class="carne-campo-box">
                  <span class="carne-campo-label">STATUS</span>
                  <span class="badge ${p.status === 'PAGO' ? 'bg-success' : 'bg-warning text-dark'}" style="font-size: 6.5pt;">${p.status}</span>
                </div>
                <div class="text-center mt-2 pt-1 border-top" style="font-size: 6.5pt; color: #777;">
                  Autenticação Mecânica / Visto
                </div>
              </div>

              <!-- FICHA DE COMPENSAÇÃO / RECIBO PRINCIPAL (72%) -->
              <div class="col-9 ps-2">
                <div class="d-flex justify-content-between align-items-center carne-header">
                  <div class="d-flex align-items-center gap-2">
                    <img src="/static/img/LogoAteniense.png" style="height: 24px;" alt="Logo">
                    <strong style="font-size: 8pt; color: #00005b;">CENTRO EDUCACIONAL ATENIENSE</strong>
                  </div>
                  <div class="carne-linha-digitavel">${p.codigo_referencia}</div>
                </div>

                <div class="row g-1 mb-1">
                  <div class="col-8">
                    <div class="carne-campo-box">
                      <span class="carne-campo-label">LOCAL DE PAGAMENTO</span>
                      <span style="font-size: 7.5pt; font-weight: bold;">SECRETARIA DA ESCOLA OU CHAVE PIX / CONTA BANCÁRIA OFICIAL</span>
                    </div>
                  </div>
                  <div class="col-4">
                    <div class="carne-campo-box bg-light">
                      <span class="carne-campo-label">VENCIMENTO</span>
                      <span class="carne-campo-valor text-danger">${p.vencimento_str}</span>
                    </div>
                  </div>
                </div>

                <div class="row g-1 mb-1">
                  <div class="col-5">
                    <div class="carne-campo-box">
                      <span class="carne-campo-label">BENEFICIÁRIO / CEDENTE</span>
                      <span style="font-size: 7pt; font-weight: bold;">I. M. AZULAY ME (CNPJ 35.062.987/0001-53)</span>
                    </div>
                  </div>
                  <div class="col-3">
                    <div class="carne-campo-box">
                      <span class="carne-campo-label">AGÊNCIA / CÓDIGO</span>
                      <span style="font-size: 7pt;">0001 / 35062-9</span>
                    </div>
                  </div>
                  <div class="col-2">
                    <div class="carne-campo-box">
                      <span class="carne-campo-label">PARCELA</span>
                      <span class="carne-campo-valor">${p.parcela_str}</span>
                    </div>
                  </div>
                  <div class="col-2">
                    <div class="carne-campo-box bg-light">
                      <span class="carne-campo-label">VALOR DO DOC.</span>
                      <span class="carne-campo-valor text-success">${p.valor_fmt}</span>
                    </div>
                  </div>
                </div>

                <div class="carne-campo-box mb-1" style="min-height: 38px;">
                  <span class="carne-campo-label">INSTRUÇÕES DE PAGAMENTO / ENCARGOS</span>
                  <div style="font-size: 6.8pt; line-height: 1.25; color: #222;">
                    • Sr. Caixa, cobrar até o 5º dia útil do mês de vencimento.<br>
                    • Após o vencimento, cobrar juros de mora de 1% a.m. e multa contratual de 2%.<br>
                    • Aluno(a): <strong>${a.nome_aluno || '-'}</strong> (Matrícula #${a.ID_aluno}) - Turma/Curso: <strong>${cursoStr} (${turnoStr})</strong>.
                  </div>
                </div>

                <div class="row g-1">
                  <div class="col-12">
                    <div class="carne-campo-box">
                      <span class="carne-campo-label">PAGADOR / RESPONSÁVEL FINANCEIRO</span>
                      <div style="font-size: 7.2pt;">
                        <strong>${respNome}</strong> - CPF: <strong>${respCpf}</strong><br>
                        Endereço: ${respEnd}
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        `;
      }

      nomeTitulo = 'Carnê de Pagamento Escolar';
      docHtml = `
        <div class="print-document">
          ${headerHtml}
          <div class="print-title mt-2 mb-3">CARNÊ DE PAGAMENTO DE MENSALIDADES ESCOLARES (${data.ano_letivo})</div>
          <div class="p-2 mb-3 bg-light rounded border text-muted" style="font-size: 8.5pt;">
            <strong>ALUNO(A):</strong> ${a.nome_aluno || '-'} | <strong>RESPONSÁVEL:</strong> ${respNome} (CPF: ${respCpf}) | <strong>ANO:</strong> ${data.ano_letivo} | <strong>CONTRATO:</strong> #${m.ID_mensalidade || '-'}
          </div>
          ${slipsHtml}
          <div class="text-center mt-3 text-muted small">
            <em>Centro Educacional Ateniense - Carnê Escolar Oficial emitido em ${data.hoje_formatado}.</em>
          </div>
        </div>
      `;
    } else if (tipo === 'termo') {
      const respNome = ra.nome || rf.nome || a.mae || a.pai || 'Responsável Legal';
      const respCpf = ra.cpf || rf.cpf || '-';
      const respRg = ra.rg || rf.rg || '-';
      const respTel = ra.telefone || rf.telefone || '-';
      const respPar = ra.parentesco || rf.parentesco || 'Responsável';

      nomeTitulo = 'Termo de Responsabilidade e Matrícula';
      docHtml = `
        <div class="print-document">
          ${headerHtml}
          <div class="print-title mt-3 mb-2">TERMO DE RESPONSABILIDADE E COMPROMISSO DE MATRÍCULA</div>
          <p class="text-center text-muted small mb-4">ANO LETIVO DE ${data.ano_letivo}</p>

          <div class="p-3 bg-light rounded border mb-3 font-monospace" style="font-size: 10pt; line-height: 1.6;">
            <div class="row g-2">
              <div class="col-8"><strong>ALUNO(A):</strong> ${a.nome_aluno || '-'}</div>
              <div class="col-4"><strong>MATRÍCULA:</strong> #${a.ID_aluno}</div>
              <div class="col-6"><strong>DATA NASC.:</strong> ${a.datanasc_formatada || '-'}</div>
              <div class="col-6"><strong>NATURALIDADE:</strong> ${a.cidade || 'Manaus'}/${a.UF || 'AM'}</div>
              <div class="col-6"><strong>SÉRIE / ETAPA:</strong> ${m.curso || a.etapa || a.nome_turma || '-'}</div>
              <div class="col-6"><strong>TURNO:</strong> ${m.turno || a.turno || '-'}</div>
              <div class="col-12"><strong>FILIAÇÃO:</strong> Mãe: ${a.mae || '-'} | Pai: ${a.pai || '-'}</div>
              <div class="col-8"><strong>RESPONSÁVEL ACADÊMICO:</strong> ${respNome} (${respPar})</div>
              <div class="col-4"><strong>CPF:</strong> ${respCpf}</div>
              <div class="col-6"><strong>RG:</strong> ${respRg}</div>
              <div class="col-6"><strong>TELEFONE:</strong> ${respTel}</div>
            </div>
          </div>

          <div class="print-body" style="font-size: 11.5pt; line-height: 1.8; text-align: justify;">
            <p>
              Por este instrumento particular, eu, <strong>${respNome}</strong>, acima qualificado(a), na qualidade de responsável pelo(a) estudante 
              <strong>${a.nome_aluno || '-'}</strong>, declaro para os devidos fins de direito perante o <strong>CENTRO EDUCACIONAL ATENIENSE</strong> que:
            </p>
            <p>
              <strong>1. COMPROMISSO PEDAGÓGICO E REGIMENTAL:</strong> Assumo integral responsabilidade pelo acompanhamento pedagógico, disciplinar 
              e moral do(a) discente, declarando pleno conhecimento e expressa adesão às normas contidas no Regimento Escolar Interno da Instituição.
            </p>
            <p>
              <strong>2. PONTUALIDADE E HORÁRIOS:</strong> Comprometo-me a zelar pela assiduidade e pontualidade, respeitando rigorosamente os 
              horários de entrada e saída das aulas. Estou ciente de que a tolerância máxima após o término do turno é de 45 (quarenta e cinco) minutos, 
              sendo devida a taxa regimental de permanência após esse período para cobertura dos custos de supervisão e monitoria.
            </p>
            <p>
              <strong>3. UNIFORME ESCOLAR OBRIGATÓRIO:</strong> Reconheço a obrigatoriedade incondicional do uso do uniforme escolar completo e 
              padronizado nas dependências do colégio e em atividades externas orientadas.
            </p>
            <p>
              <strong>4. MATERIAL ESCOLAR E SAÚDE:</strong> Garanto o fornecimento tempestivo dos materiais didáticos individuais solicitados na 
              lista pedagógica e obrigo-me a comunicar imediatamente à coordenação quaisquer intercorrências de saúde, alergias, medicações de uso 
              contínuo ou alterações cadastrais/telefônicas.
            </p>
            <p>
              <strong>5. COMUNICAÇÃO ESCOLAR:</strong> Comprometo-me a comparecer às reuniões de pais e mestres, convocatórias da direção escolar e a 
              manter canal ativo de comunicação com a Secretaria através dos telefones e e-mails oficiais fornecidos.
            </p>
            <p>
              E, por ser a expressão fiel da verdade e do compromisso assumido, assino o presente Termo para que surta seus jurídicos e legais efeitos.
            </p>
          </div>

          <div class="text-end my-4" style="font-size: 11.5pt;">
            <strong>${data.data_extenso}</strong>
          </div>

          <div class="print-footer mt-5 pt-4">
            <div class="row">
              <div class="col-6"><div class="print-signature">${respNome}<br><span class="small text-muted">Responsável Legal</span></div></div>
              <div class="col-6"><div class="print-signature">Coordenação Pedagógica / Direção<br><span class="small text-muted">Centro Educacional Ateniense</span></div></div>
            </div>
          </div>
        </div>
      `;
    } else if (tipo === 'ficha') {
      const respFinNome = rf.nome || '-';
      const respAcadNome = ra.nome || '-';

      nomeTitulo = 'Ficha Individual e Cadastral do Aluno';
      docHtml = `
        <div class="print-document">
          ${headerHtml}
          <div class="print-title mt-3 mb-2">FICHA INDIVIDUAL E CADASTRAL DO(A) ESTUDANTE</div>
          <p class="text-center text-muted small mb-3">HISTÓRICO INSTITUCIONAL E DADOS DE MATRÍCULA - ANO LETIVO ${data.ano_letivo}</p>

          <div class="card border mb-3">
            <div class="card-header bg-light py-1 fw-bold small text-uppercase">1. Identificação do(a) Aluno(a)</div>
            <div class="card-body p-2" style="font-size: 9.5pt; line-height: 1.6;">
              <div class="row">
                <div class="col-8"><strong>Nome Completo:</strong> ${a.nome_aluno || '-'}</div>
                <div class="col-4"><strong>Nº Matrícula:</strong> #${a.ID_aluno}</div>
                <div class="col-4"><strong>Data de Nascimento:</strong> ${a.datanasc_formatada || '-'}</div>
                <div class="col-4"><strong>Sexo:</strong> ${a.sexo || '-'}</div>
                <div class="col-4"><strong>Cor / Raça:</strong> ${a.cor || '-'}</div>
                <div class="col-6"><strong>Naturalidade / UF:</strong> ${a.cidade || 'Manaus'} - ${a.UF || 'AM'}</div>
                <div class="col-6"><strong>Nacionalidade:</strong> ${a.nacionalidade || 'Brasileira'}</div>
                <div class="col-12"><strong>Endereço Residencial:</strong> ${a.rua || '-'}, Nº ${a.numero || 'S/N'} - Bairro: ${a.bairro || '-'} - CEP: ${a.cep || '-'}</div>
              </div>
            </div>
          </div>

          <div class="card border mb-3">
            <div class="card-header bg-light py-1 fw-bold small text-uppercase">2. Filiação e Dados Familiares</div>
            <div class="card-body p-2" style="font-size: 9.5pt; line-height: 1.6;">
              <div class="row">
                <div class="col-12 mb-1"><strong>Nome da Mãe:</strong> ${a.mae || 'Não informado'}</div>
                <div class="col-12"><strong>Nome do Pai:</strong> ${a.pai || 'Não informado'}</div>
              </div>
            </div>
          </div>

          <div class="row g-2 mb-3">
            <div class="col-6">
              <div class="card border h-100">
                <div class="card-header bg-light py-1 fw-bold small text-uppercase">3. Responsável Acadêmico</div>
                <div class="card-body p-2" style="font-size: 9pt; line-height: 1.5;">
                  <div><strong>Nome:</strong> ${respAcadNome}</div>
                  <div><strong>Parentesco:</strong> ${ra.parentesco || '-'}</div>
                  <div><strong>CPF:</strong> ${ra.cpf || '-'} | <strong>RG:</strong> ${ra.rg || '-'}</div>
                  <div><strong>Telefone:</strong> ${ra.telefone || '-'}</div>
                  <div><strong>Profissão:</strong> ${ra.profissao || '-'}</div>
                  <div><strong>Email:</strong> ${ra.email || '-'}</div>
                </div>
              </div>
            </div>
            <div class="col-6">
              <div class="card border h-100">
                <div class="card-header bg-light py-1 fw-bold small text-uppercase">4. Responsável Financeiro</div>
                <div class="card-body p-2" style="font-size: 9pt; line-height: 1.5;">
                  <div><strong>Nome:</strong> ${respFinNome}</div>
                  <div><strong>Parentesco:</strong> ${rf.parentesco || '-'}</div>
                  <div><strong>CPF:</strong> ${rf.cpf || '-'} | <strong>RG:</strong> ${rf.rg || '-'}</div>
                  <div><strong>Telefone:</strong> ${rf.telefone || '-'}</div>
                  <div><strong>Profissão:</strong> ${rf.profissao || '-'}</div>
                  <div><strong>Endereço:</strong> ${rf.rua || '-'}, Nº ${rf.numero || '-'} - ${rf.bairro || '-'}</div>
                </div>
              </div>
            </div>
          </div>

          <div class="card border mb-4">
            <div class="card-header bg-light py-1 fw-bold small text-uppercase">5. Dados Contratuais e Acadêmicos</div>
            <div class="card-body p-2" style="font-size: 9.5pt; line-height: 1.6;">
              <div class="row">
                <div class="col-4"><strong>Série / Etapa:</strong> ${m.curso || a.etapa || a.nome_turma || '-'}</div>
                <div class="col-4"><strong>Turno Contratado:</strong> ${m.turno || a.turno || '-'}</div>
                <div class="col-4"><strong>Ano Letivo:</strong> ${data.ano_letivo}</div>
                <div class="col-4"><strong>Contrato Nº:</strong> #${m.ID_mensalidade || '-'}</div>
                <div class="col-4"><strong>Plano:</strong> ${m.n_parcelas} parcelas de ${m.valor_parcela_fmt}</div>
                <div class="col-4"><strong>Total Anual:</strong> ${m.valor_total_fmt}</div>
              </div>
            </div>
          </div>

          <div class="text-end my-3" style="font-size: 11pt;">
            <strong>${data.data_extenso}</strong>
          </div>

          <div class="print-footer mt-4 pt-3">
            <div class="row">
              <div class="col-6"><div class="print-signature">Responsável Legal do Aluno</div></div>
              <div class="col-6"><div class="print-signature">Secretaria Geral / Matrículas</div></div>
            </div>
          </div>
        </div>
      `;
    } else {
      // 4. CONTRATOS DE PRESTAÇÃO DE SERVIÇOS (NORMAL, INTEGRAL, MEIO PERÍODO, 2027)
      let tituloContrato = `CONTRATO DE PRESTAÇÃO DE SERVIÇOS EDUCACIONAIS - PERÍODO NORMAL (${data.ano_letivo})`;
      nomeTitulo = 'Contrato de Ensino - Período Normal';
      if (tipo === 'integral') {
        tituloContrato = `CONTRATO DE PRESTAÇÃO DE SERVIÇOS EDUCACIONAIS - PERÍODO INTEGRAL (${data.ano_letivo})`;
        nomeTitulo = 'Contrato de Ensino - Período Integral';
      } else if (tipo === 'meio_periodo') {
        tituloContrato = `CONTRATO DE PRESTAÇÃO DE SERVIÇOS EDUCACIONAIS - MEIO PERÍODO (${data.ano_letivo})`;
        nomeTitulo = 'Contrato de Ensino - Meio Período';
      } else if (tipo === '2027') {
        tituloContrato = `CONTRATO DE PRESTAÇÃO DE SERVIÇOS EDUCACIONAIS - ANO LETIVO 2027`;
        nomeTitulo = 'Contrato de Ensino - Ano Letivo 2027';
      }

      const respNome = rf.nome || ra.nome || 'Responsável Legal';
      const respCpf = rf.cpf || '-';
      const respRg = rf.rg || '-';
      const respOrgao = rf.orgao_emissor || 'SSP/AM';
      const respEnd = `${rf.rua || a.rua || '-'}, Nº ${rf.numero || a.numero || 'S/N'} - Bairro: ${rf.bairro || a.bairro || '-'}, CEP: ${rf.cep || a.cep || '-'}`;
      const cursoStr = (m.curso || a.etapa || a.nome_turma || 'Educação Básica').toUpperCase();
      const turnoStr = (m.turno || a.turno || 'NORMAL').toUpperCase();

      docHtml = `
      <!-- PÁGINA 1 (FOLHA 1/2) -->
      <div class="print-page">
        ${headerHtml}
        <div class="print-title my-1 text-center" style="font-size: 10.5pt; border-top: 1px solid #000; border-bottom: 1px solid #000; padding: 2px 0;">
          ${tituloContrato}
        </div>

        <table class="table table-bordered table-sm mb-2" style="font-size: 7.5pt; line-height: 1.25;">
          <tbody>
            <tr>
              <td style="width: 50%; vertical-align: top;" class="p-1">
                <strong class="d-block text-uppercase border-bottom pb-1 mb-1 bg-light px-1">CONTRATADA</strong>
                <strong>${c.razao_social || 'I. M. AZULAY ME'}</strong> (${c.nome_fantasia || 'Centro Educacional Ateniense'})<br>
                CNPJ: ${c.cnpj || '35.062.987/0001-53'} | Inscrição Estadual: Isento<br>
                Endereço: ${c.endereco}
              </td>
              <td style="width: 50%; vertical-align: top;" class="p-1">
                <strong class="d-block text-uppercase border-bottom pb-1 mb-1 bg-light px-1">CONTRATANTE / RESPONSÁVEL</strong>
                <strong>${respNome}</strong> | CPF: ${respCpf} | RG: ${respRg} (${respOrgao})<br>
                Endereço: ${respEnd}<br>
                Aluno(a): <strong>${a.nome_aluno || '-'}</strong> (Matrícula #${a.ID_aluno}) | ${cursoStr} - Turno: ${turnoStr} (${data.ano_letivo})
              </td>
            </tr>
          </tbody>
        </table>

        <div style="font-size: 7.8pt; line-height: 1.25; text-align: justify;">
          <p class="mb-1">
            Têm como certo e ajustada a prestação de serviços educacionais, mediante as condições e cláusulas a seguir alinhadas:
          </p>
          <p class="mb-1">
            <strong>CLÁUSULA 1 -</strong> O presente Contrato é celebrado sob a égide dos artigos 1º, inciso IV, 5º, inciso II; 173 parágrafo IV; 206, incisos II e III, da Constituição Federal; Lei nº 8.069/90 (Estatuto da Criança e do Adolescente), da Lei nº 8.078/90 (Código do Consumidor), preventemente (Art. 62, infine, da Constituição Federal) e Medida Provisória nº 1.477-28, de 26 de setembro de 1996.
          </p>
          <p class="mb-1">
            <strong>CLÁUSULA 2 -</strong> Este contrato tem como objeto a prestação anual de serviços educacionais de ensino infantil e fundamental, oferecidos e ministrados pela <strong>CONTRATADA</strong>, e demais atividades acadêmicas, devendo o plano de estudos, programas, currículo e calendário estarem em conformidade com o disposto na legislação em vigor.<br>
            <em>Parágrafo Primeiro:</em> As aulas presenciais serão ministradas nas salas ou locais em que a <strong>CONTRATADA</strong> indicar, tendo em vista a natureza do conteúdo e da técnica pedagógica que se fizer necessária.
          </p>
          <p class="mb-1">
            <strong>CLÁUSULA 3 -</strong> O presente Contrato é de natureza adesiva, adotado sem distinção para todos os discentes, sendo proibida e nula a alteração de seu texto para caso específico, conforme previsão contida no art. 54, da Lei 8.078, de 11/09/1990.<br>
            <em>Parágrafo Primeiro:</em> A configuração formal do ato da matrícula/rematrícula se dá mediante: I. o deferimento da matrícula; II. o pagamento da primeira parcela da semestralidade/anuidade; III. o aceite do presente contrato pelo <strong>CONTRATANTE</strong>.<br>
            <em>Parágrafo Segundo:</em> Os procedimentos acima referidos configuram-se como condições suspensivas para o início da vigência deste pacto, nos termos dos artigos 125 e 332 do Código Civil.<br>
            <em>Parágrafo Terceiro:</em> A partir da matrícula, ainda que antes do início das aulas, a <strong>CONTRATADA</strong> já presta serviços preparatórios ao <strong>CONTRATANTE</strong>: preparação da acolhida, organização de salas, diários e quadro docente.<br>
            <em>Parágrafo Quarto:</em> Para adesão a este Contrato, o <strong>CONTRATANTE</strong> não deve estar inadimplente com a <strong>CONTRATADA</strong>.
          </p>
          <p class="mb-1">
            <strong>CLÁUSULA 4 -</strong> O valor da anuidade será pago pelo <strong>CONTRATANTE</strong> pelos serviços educacionais lhe proporcionados, apurado de acordo com a Lei nº 9.870/1999, e será de <strong>${m.valor_total_fmt} (${m.valor_total_extenso})</strong>.<br>
            <em>Parágrafo Primeiro:</em> O valor da anuidade será reajustado sempre no início do ano civil e será comunicado pela direção da <strong>CONTRATADA</strong>.<br>
            <em>Parágrafo Segundo:</em> O valor do contrato anual poderá ser pago à vista ou dividido em <strong>${m.n_parcelas} (${m.n_parcelas_extenso}) parcelas mensais</strong>, no valor de <strong>${m.valor_parcela_fmt} (${m.valor_parcela_extenso})</strong>.<br>
            <em>Parágrafo Terceiro:</em> A primeira parcela terá vencimento no ato da matrícula, sendo imprescindível sua quitação para celebração deste contrato.<br>
            <em>Parágrafo Quarto:</em> O pagamento das parcelas subsequentes obedecerá à data do <strong>5º dia útil</strong> (ou dia 30 de cada mês), excetuando fevereiro (dia 28) e dezembro (dia 29).<br>
            <em>Parágrafo Quinto:</em> As datas acordadas expressam a vontade mútua de ambas as partes.<br>
            <em>Parágrafo Sexto:</em> As parcelas somente poderão ser pagas na Tesouraria da <strong>CONTRATADA</strong> ou através de Cobrança Bancária / PIX autorizado.
          </p>
          <p class="mb-1">
            <strong>CLÁUSULA 5 -</strong> Obriga-se o <strong>CONTRATANTE</strong>, durante o respectivo ano letivo, a pagar o valor da anuidade acadêmica nas condições pactuadas.<br>
            <em>Parágrafo Primeiro:</em> A falta do pagamento de qualquer parcela após o 5º dia útil do vencimento constituirá em mora de pleno direito o <strong>CONTRATANTE</strong>, implicando acréscimo de juros moratórios legais (art. 406 do CC) e multa moratória de 2% (dois por cento) sobre o débito.<br>
            <em>Parágrafo Segundo:</em> O <strong>CONTRATANTE</strong> responderá pelas despesas, custas e honorários advocatícios à base de 20% (vinte por cento) sobre o valor total do débito exigido com a cobrança judicial ou extrajudicial (art. 389 do Código Civil), no caso de parcelas com atraso superior a 90 dias.<br>
            <em>Parágrafo Terceiro:</em> Independentemente do disposto no parágrafo anterior, quando o atraso de parcela for superior a 90 (noventa) dias, a <strong>CONTRATADA</strong> poderá acionar a competente Execução de Título Extrajudicial (artigos 205, 465 a 467 do Código Civil e art. 6º da Lei 9.870/99).<br>
            <em>Parágrafo Quarto:</em> O não comparecimento do ALUNO às aulas não confere direito à recusa de pagamento das mensalidades contratadas.
          </p>
          <p class="mb-0">
            <strong>CLÁUSULA 6 -</strong> Havendo atraso do pagamento superior a 90 (noventa) dias, o <strong>CONTRATANTE</strong> autoriza a <strong>CONTRATADA</strong> a: I. negativar o devedor em cadastros ou serviços de proteção ao crédito (SPC, Serasa e afins); II. promover o protesto do título em cartório competente; III. promover cobrança extrajudicial especializada; IV. promover cobrança e execução judicial; V. não renovar a matrícula do aluno para o período seguinte (art. 5º da Lei 9.870/99).
          </p>
        </div>

        <div class="d-flex justify-content-between align-items-center border-top mt-2 pt-1 text-muted" style="font-size: 7pt;">
          <span>Centro Educacional Ateniense - Contrato de Prestação de Serviços</span>
          <span>Rubricas: CONTRATANTE: ___________ / CONTRATADA: ___________ | <strong>Folha 1/2</strong></span>
        </div>
      </div>

      <!-- PÁGINA 2 (FOLHA 2/2) -->
      <div class="print-page">
        <div class="d-flex justify-content-between align-items-center border-bottom pb-1 mb-2 text-muted" style="font-size: 7.5pt;">
          <span><strong class="text-dark">ESCOLA INFANTIL ATENIENSE</strong> | Contrato de Prestação de Serviços Educacionais</span>
          <span>Aluno(a): <strong>${a.nome_aluno || '-'}</strong> (Matr. #${a.ID_aluno}) - Ano ${data.ano_letivo} | <strong>Folha 2/2</strong></span>
        </div>

        <div style="font-size: 7.8pt; line-height: 1.25; text-align: justify;">
          <p class="mb-1">
            <strong>CLÁUSULA 7 -</strong> A guarda de documentos pela <strong>CONTRATADA</strong> obedecerá ao prazo de 2 (dois) anos após o término do contrato, findo o qual os documentos poderão ser devidamente descartados, conforme os ditames previstos na Lei Geral de Proteção de Dados Pessoais (LGPD - Lei 13.709/2018).
          </p>
          <p class="mb-1">
            <strong>CLÁUSULA 8 -</strong> É de exclusiva responsabilidade do <strong>CONTRATANTE</strong> a aquisição do Material Escolar individual constante na Lista de Materiais entregue na matrícula, não se confundindo este com o valor da anuidade.<br>
            <em>Parágrafo Único:</em> No que tange à taxa de papelaria, em caso de desistência formal prévia haverá devolução máxima de 20% do valor pago a este título.
          </p>
          <p class="mb-1">
            <strong>CLÁUSULA 9 -</strong> Ao firmar o presente, o <strong>CONTRATANTE</strong> submete-se ao Regimento Escolar e às obrigações decorrentes da legislação aplicável à área educacional.
          </p>
          <p class="mb-1">
            <strong>CLÁUSULA 10 -</strong> Os valores acordados referem-se à carga horária curricular obrigatória aprovada pelos órgãos de ensino.<br>
            <em>Parágrafo Único:</em> Serviços extraordinários efetivamente prestados terão cobrança conforme tabela regimental: Segunda chamada de provas, exames, segunda via de boletins e declarações (taxa de R$ 50,00); Segunda via de histórico escolar e transferência (taxa de R$ 50,00). A permanência do aluno na escola após o horário e tolerância regular (45 minutos) acarretará taxa de R$ 50,00 por hora excedente. Fica terminantemente proibido o aluno portar dinheiro ou utilizar telefone celular na escola.
          </p>
          <p class="mb-1">
            <strong>CLÁUSULA 11 -</strong> A <strong>CONTRATADA</strong> não se responsabiliza por objetos de uso pessoal (aparelhos móveis, celulares, joias, relógios, quantias em dinheiro ou materiais) perdidos nas dependências da escola, estacionamento ou imediações.
          </p>
          <p class="mb-1">
            <strong>CLÁUSULA 12 -</strong> O presente Contrato tem duração até o final do Ano Letivo contratado, salvo se rescindido nas seguintes hipóteses:<br>
            1) Pela Escola: a) Por desligamento regimental; b) Por ausência injustificada por mais de 90 dias consecutivos.<br>
            2) Pelo Responsável: a) Por desistência formal expressa por escrito; b) Por pedido formal de transferência escolar.<br>
            <em>Parágrafo Primeiro:</em> Em caso de rescisão, não haverá devolução das parcelas já vencidas e pagas, permanecendo o CONTRATANTE responsável pelos valores devidos até a data formal do distrato.<br>
            <em>Parágrafo Segundo:</em> Em caso de rescisão antecipada por solicitação do CONTRATANTE, este obriga-se a pagar multa rescisória no importe de 10% (dez por cento) sobre o saldo de mensalidades residuais vincendas.<br>
            <em>Parágrafo Terceiro:</em> Em cancelamento antes do início efetivo das aulas, a CONTRATADA reterá 50% do valor da matrícula para custeio das despesas administrativas e preparatórias.<br>
            <em>Parágrafo Quarto:</em> Não será admitida a rescisão contratual quando restar pendente apenas a última parcela do ano letivo.
          </p>
          <p class="mb-1">
            <strong>CLÁUSULA 13 -</strong> O <strong>CONTRATANTE</strong> concede à <strong>CONTRATADA</strong> o direito gratuito de utilização da imagem e voz do estudante exclusivamente para fins institucionais e pedagógicos em redes sociais, folders, murais e divulgação institucional da Escola.
          </p>
          <p class="mb-1">
            <strong>CLÁUSULA 14 -</strong> Para segurança de toda a comunidade escolar, funcionam câmeras de monitoramento em circuito fechado nas dependências da Instituição.
          </p>
          <p class="mb-1">
            <strong>CLÁUSULA 15 -</strong> Obriga-se o <strong>CONTRATANTE</strong> a zelar pelo cumprimento do Calendário e o uso diário obrigatório do uniforme escolar completo (calça/bermuda/short-saia, camiseta da escola e tênis preto, azul ou branco).
          </p>
          <p class="mb-1">
            <strong>CLÁUSULA 16 -</strong> O <strong>CONTRATANTE</strong> declara verdadeiras todas as informações e documentos fornecidos no ato da matrícula.
          </p>
          <p class="mb-2">
            <strong>CLÁUSULA 17 -</strong> Para dirimir quaisquer litígios oriundos deste Contrato, fica eleito o Foro da Comarca da Cidade de Manaus/AM, com renúncia de qualquer outro.
          </p>
        </div>

        <div class="text-end my-2" style="font-size: 8.5pt;">
          <strong>${data.data_extenso}</strong>
        </div>

        <div class="print-footer mt-2 pt-2">
          <div class="row g-3 mb-2 text-center">
            <div class="col-6">
              <div class="print-signature" style="padding-top: 3px; font-size: 8pt;">
                <strong>${respNome}</strong><br>
                <span class="small text-muted">CONTRATANTE (CPF: ${respCpf})</span>
              </div>
            </div>
            <div class="col-6">
              <div class="print-signature" style="padding-top: 3px; font-size: 8pt;">
                <strong>CENTRO EDUCACIONAL ATENIENSE</strong><br>
                <span class="small text-muted">CONTRATADA (I. M. AZULAY ME)</span>
              </div>
            </div>
          </div>
          <div class="row g-3 mt-1 text-center">
            <div class="col-6">
              <div class="print-signature" style="padding-top: 3px; font-size: 7.5pt;">
                TESTEMUNHA 1: ____________________________<br>
                <span class="small text-muted">CPF: ____________________________________</span>
              </div>
            </div>
            <div class="col-6">
              <div class="print-signature" style="padding-top: 3px; font-size: 7.5pt;">
                TESTEMUNHA 2: ____________________________<br>
                <span class="small text-muted">CPF: ____________________________________</span>
              </div>
            </div>
          </div>
        </div>

        <div class="text-center text-muted mt-2 pt-1 border-top" style="font-size: 6.8pt;">
          Centro Educacional Ateniense - Documento oficial timbrado gerado eletronicamente em ${data.hoje_formatado}.
        </div>
      </div>
    `;
    }

    // 1. Injeta o documento gerado dentro do Modal Popup
    if (modalBody) {
      modalBody.innerHTML = docHtml;
    }

    // 2. Atualiza títulos do Modal Popup
    const titleElem = document.getElementById('modalContratoViewerTitle');
    const subElem = document.getElementById('modalContratoViewerSubtitle');
    if (titleElem) {
      titleElem.textContent = `${nomeTitulo} - ${a.nome_aluno || 'Estudante'}`;
    }
    if (subElem) {
      subElem.textContent = `Matrícula #${a.ID_aluno || '-'} • Ano Letivo ${data.ano_letivo || '-'} • Contrato #${m.ID_mensalidade || '-'}`;
    }

    // 3. Atualiza container da página com resumo e botões de ação limpos
    if (container) {
      container.innerHTML = `
        <div class="card border-0 shadow-sm p-4 text-center bg-white rounded no-print">
          <div class="d-flex flex-column align-items-center">
            <div class="rounded-circle bg-primary-subtle text-primary p-3 mb-2">
              <i class="bi bi-window-fullscreen fs-2"></i>
            </div>
            <h5 class="fw-bold text-dark mb-1">${nomeTitulo}</h5>
            <p class="text-muted small mb-3">
              Aluno: <strong>${a.nome_aluno || '-'}</strong> (Matrícula #${a.ID_aluno || '-'}) • Ano Letivo ${data.ano_letivo || '-'} • Contrato #${m.ID_mensalidade || '-'}
            </p>
            <div class="d-flex gap-2">
              <button class="btn btn-primary fw-bold px-4" onclick="App.reabrirModalContrato()">
                <i class="bi bi-window-stack me-1"></i> Abrir Documento em Popup
              </button>
              <button class="btn btn-success fw-bold px-4" onclick="App.imprimirDocumentoModal()">
                <i class="bi bi-printer me-1"></i> Imprimir (A4)
              </button>
            </div>
          </div>
        </div>
      `;
    }

    // 4. Abre o popup modal
    if (abrirModal) {
      const modalElem = document.getElementById('modalContratoViewer');
      if (modalElem) {
        const modal = bootstrap.Modal.getOrCreateInstance(modalElem);
        modal.show();
      }
    }
  },

  reabrirModalContrato() {
    const modalElem = document.getElementById('modalContratoViewer');
    if (modalElem) {
      const modal = bootstrap.Modal.getOrCreateInstance(modalElem);
      modal.show();
    }
  },

  imprimirDocumentoModal() {
    window.print();
  },

  imprimirContratoAtivo() {
    const modalElem = document.getElementById('modalContratoViewer');
    if (modalElem) {
      if (!modalElem.classList.contains('show')) {
        const modal = bootstrap.Modal.getOrCreateInstance(modalElem);
        modal.show();
        setTimeout(() => {
          window.print();
        }, 350);
      } else {
        window.print();
      }
    } else {
      window.print();
    }
  },

  async setupBoletim() {
    try {
      // Carrega turmas no select de filtro
      const dataTurmas = await this.api('/api/turmas');
      const selTurma = document.getElementById('boletimTurmaSelect');
      const selAluno = document.getElementById('boletimAlunoSelect');

      if (selTurma) {
        selTurma.innerHTML = '<option value="">-- Selecione a Turma --</option>' + 
          (dataTurmas.turmas || []).map(t => {
            const anoStr = t.ano_letivo ? ` (${t.ano_letivo})` : '';
            return `<option value="${t.id}">${t.nome_turma}${anoStr}</option>`;
          }).join('');
      }

      if (selAluno) {
        selAluno.innerHTML = '<option value="">Selecione uma turma primeiro...</option>';
        selAluno.disabled = true;
      }

      const container = document.getElementById('boletimDocumentContainer');
      if (container) {
        container.innerHTML = `
          <div class="text-center text-muted p-5 bg-white rounded border shadow-sm">
            <i class="bi bi-people display-4 text-secondary mb-2 d-block"></i>
            <h5 class="fw-bold text-secondary">Nenhuma Turma Selecionada</h5>
            <p class="mt-2 text-muted">Por favor, selecione uma turma no campo acima para carregar somente os alunos desta classe e emitir o boletim escolar.</p>
          </div>
        `;
      }
    } catch (e) {
      console.error('Erro ao configurar tela de boletim:', e);
    }
  },

  async filtrarAlunosBoletim() {
    const selTurma = document.getElementById('boletimTurmaSelect');
    const turmaId = selTurma?.value || '';
    const selAluno = document.getElementById('boletimAlunoSelect');
    const container = document.getElementById('boletimDocumentContainer');

    if (!turmaId) {
      if (selAluno) {
        selAluno.innerHTML = '<option value="">Selecione uma turma primeiro...</option>';
        selAluno.disabled = true;
      }
      if (container) {
        container.innerHTML = `
          <div class="text-center text-muted p-5 bg-white rounded border shadow-sm">
            <i class="bi bi-people display-4 text-secondary mb-2 d-block"></i>
            <h5 class="fw-bold text-secondary">Nenhuma Turma Selecionada</h5>
            <p class="mt-2 text-muted">Por favor, selecione uma turma no campo acima para carregar somente os alunos desta classe e emitir o boletim escolar.</p>
          </div>
        `;
      }
      return;
    }

    if (selAluno) {
      selAluno.disabled = false;
      selAluno.innerHTML = '<option value="">Carregando alunos da turma...</option>';
    }

    try {
      const data = await this.api(`/api/turmas/${encodeURIComponent(turmaId)}/alunos`);
      const alunos = data.alunos || [];

      if (!selAluno) return;

      if (alunos.length === 0) {
        selAluno.innerHTML = '<option value="">Nenhum aluno nesta turma</option>';
        selAluno.disabled = true;
        if (container) {
          container.innerHTML = `
            <div class="alert alert-warning text-center p-4 m-3 shadow-sm border-0">
              <i class="bi bi-exclamation-triangle-fill fs-3 text-warning mb-2 d-block"></i>
              <h6 class="fw-bold">Nenhum aluno enturmado nesta turma</h6>
              <p class="small mb-0 text-muted">Não foram encontrados alunos cadastrados nesta turma no momento.</p>
            </div>
          `;
        }
        return;
      }

      selAluno.disabled = false;
      selAluno.innerHTML = `<option value="">Selecione o aluno (${alunos.length} alunos)...</option>` + 
        alunos.map(a => `<option value="${a.id}">${a.nome} (Matrícula #${a.id})</option>`).join('');

      // Seleciona o primeiro aluno da turma e emite o boletim automaticamente
      selAluno.value = alunos[0].id;
      this.verBoletim(alunos[0].id);

    } catch (e) {
      console.error('Erro ao buscar alunos da turma:', e);
      if (selAluno) selAluno.innerHTML = '<option value="">Erro ao carregar alunos</option>';
    }
  },

  async carregarBoletimAluno() {
    const alunoId = document.getElementById('boletimAlunoSelect')?.value;
    if (!alunoId) return;
    this.verBoletim(alunoId);
  },

  async verBoletim(alunoId) {
    try {
      const data = await this.api(`/api/boletim/${alunoId}`);
      if (!data || !data.aluno) {
        alert('Dados do boletim não encontrados');
        return;
      }
      const container = document.getElementById('boletimDocumentContainer');
      const a = data.aluno;
      const t = data.turma || {};

      container.innerHTML = `
        <div class="print-document">
          <div class="print-header">
            <img src="/static/img/LogoAteniense.png" alt="Colégio Ateniense" />
            <h4 class="m-0 fw-bold">CENTRO EDUCACIONAL ATENIENSE</h4>
            <p class="m-0 text-muted">Educação Infantil e Ensino Fundamental</p>
            <div class="print-title">BOLETIM ESCOLAR - ANO LETIVO ${data.ano}</div>
          </div>
          <div class="row mb-3 font-monospace" style="font-size: 11pt;">
            <div class="col-8"><strong>ALUNO:</strong> ${a.nome_aluno}</div>
            <div class="col-4"><strong>MATRÍCULA:</strong> #${alunoId}</div>
            <div class="col-6"><strong>TURMA:</strong> ${t.nome_turma || a.etapa || '-'}</div>
            <div class="col-6"><strong>TURNO:</strong> ${t.turno || a.turno || '-'}</div>
          </div>
          <table class="table table-bordered text-center align-middle" style="font-size: 11pt;">
            <thead class="table-light">
              <tr>
                <th class="text-start">DISCIPLINA</th>
                <th>1º BIM</th>
                <th>2º BIM</th>
                <th>3º BIM</th>
                <th>4º BIM</th>
                <th>MÉDIA</th>
                <th>SITUAÇÃO</th>
              </tr>
            </thead>
            <tbody>
              ${(data.materias || []).map(m => `
                <tr>
                  <td class="text-start fw-bold">${m.materia}</td>
                  <td>${m.b1}</td>
                  <td>${m.b2}</td>
                  <td>${m.b3}</td>
                  <td>${m.b4}</td>
                  <td class="fw-bold">${m.media}</td>
                  <td><span class="badge ${m.situacao === 'Aprovado' ? 'bg-success' : (m.situacao === 'Recuperação' ? 'bg-danger' : 'bg-secondary')}">${m.situacao}</span></td>
                </tr>
              `).join('')}
            </tbody>
          </table>
          <div class="d-flex justify-content-between mt-3 font-monospace">
            <div><strong>TOTAL DE FALTAS NO ANO:</strong> ${data.total_faltas}</div>
            <div><strong>DATA DE EMISSÃO:</strong> ${new Date().toLocaleDateString('pt-BR')}</div>
          </div>
          <div class="print-footer mt-5 pt-4">
            <div class="row">
              <div class="col-6"><div class="print-signature">Secretaria Escolar</div></div>
              <div class="col-6"><div class="print-signature">Direção Pedagógica</div></div>
            </div>
          </div>
        </div>
      `;

      // Atualiza select caso tenha sido acionado externamente
      const sel = document.getElementById('boletimAlunoSelect');
      if (sel && sel.value != alunoId) sel.value = alunoId;

      // Se a view atual não for academico-boletim, exibe-a sem resetar os seletores
      if (this.currentView !== 'academico-boletim') {
        document.querySelectorAll('.view-content').forEach(el => el.classList.add('d-none'));
        document.getElementById('view-academico-boletim')?.classList.remove('d-none');
        this.currentView = 'academico-boletim';
      }
    } catch (e) {
      alert('Erro ao gerar boletim: ' + e.message);
    }
  },

  async abrirModalLancarNota() {
    try {
      // Carrega alunos no select (prioriza turma selecionada no filtro)
      const atualTurmaId = document.getElementById('boletimTurmaSelect')?.value;
      const url = atualTurmaId ? `/api/turmas/${atualTurmaId}/alunos` : '/api/alunos?limit=150';
      const dataAlunos = await this.api(url);
      const selAluno = document.getElementById('notaAlunoSelect');
      const atualAlunoId = document.getElementById('boletimAlunoSelect')?.value;
      if (selAluno) {
        selAluno.innerHTML = (dataAlunos.alunos || []).map(a => 
          `<option value="${a.id}" ${a.id == atualAlunoId ? 'selected' : ''}>${a.nome} (#${a.id})</option>`
        ).join('');
      }

      // Carrega matérias
      const dataMat = await this.api('/api/materias');
      const selMat = document.getElementById('notaMateriaSelect');
      if (selMat) {
        selMat.innerHTML = (dataMat.materias || []).map(m => 
          `<option value="${m.id}">${m.materia}</option>`
        ).join('');
      }

      document.getElementById('notaValorInput').value = '';
      const modal = new bootstrap.Modal(document.getElementById('modalLancarNota'));
      modal.show();
    } catch (e) {
      console.error(e);
    }
  },

  async salvarNota() {
    const alunoId = document.getElementById('notaAlunoSelect')?.value;
    const materiaId = document.getElementById('notaMateriaSelect')?.value;
    const bimestre = document.getElementById('notaBimestreSelect')?.value || '1';
    const nota = parseFloat(document.getElementById('notaValorInput')?.value || 0);

    if (!alunoId || !materiaId) {
      alert('Selecione o aluno e a matéria.');
      return;
    }
    if (isNaN(nota) || nota < 0 || nota > 10) {
      alert('Informe uma nota válida entre 0.0 e 10.0.');
      return;
    }

    try {
      await this.api('/api/notas', 'POST', {
        aluno_id: alunoId,
        materia_id: materiaId,
        bimestre: bimestre,
        nota: nota.toFixed(1),
        ano_letivo: 2026
      });
      alert('Nota gravada com sucesso!');
      bootstrap.Modal.getInstance(document.getElementById('modalLancarNota')).hide();
      this.verBoletim(alunoId);
    } catch (e) {
      alert('Erro ao salvar nota: ' + e.message);
    }
  },

  // 4.2 ACADÊMICO - DIÁRIO ONLINE DE CLASSE
  cacheDiario: [],

  async loadDiario(turmaId = '', busca = '') {
    try {
      // Carrega turmas no select de filtro se ainda não carregado
      const selTurma = document.getElementById('filtroDiarioTurma');
      if (selTurma && selTurma.options.length <= 1) {
        const dataTurmas = await this.api('/api/turmas');
        selTurma.innerHTML = '<option value="">Todas as Turmas / Salas</option>' + 
          (dataTurmas.turmas || []).map(t => `<option value="${t.id}">${t.nome_turma}</option>`).join('');
      }

      let url = '/api/diario?limit=100';
      if (turmaId) url += `&turma_id=${encodeURIComponent(turmaId)}`;
      if (busca) url += `&busca=${encodeURIComponent(busca)}`;

      const data = await this.api(url);
      const registros = data.diario || [];
      this.cacheDiario = registros;

      const countEl = document.getElementById('totalDiarioCount');
      if (countEl) countEl.innerText = `${registros.length} registros encontrados`;

      const tbody = document.getElementById('tableDiario');
      if (tbody) {
        if (registros.length === 0) {
          tbody.innerHTML = '<tr><td colspan="6" class="text-center py-4 text-muted">Nenhum registro de diário encontrado.</td></tr>';
        } else {
          tbody.innerHTML = registros.map(d => `
            <tr>
              <td><span class="badge bg-light text-dark border font-monospace">${d.data_diario || '-'}</span></td>
              <td><strong class="text-dark"><i class="bi bi-person me-1"></i>${d.nome_professor || '-'}</strong></td>
              <td><span class="badge bg-primary">${d.nome_turma || d.serie || '-'}</span></td>
              <td><span class="fw-semibold text-secondary">${d.comp_curricular || '-'}</span></td>
              <td>
                <div class="small text-truncate" style="max-width: 320px;" title="${d.conteudos || ''}">
                  <strong>${d.conteudos || '-'}</strong>
                </div>
                ${d.objetivos ? `<div class="small text-muted text-truncate" style="max-width: 320px;">${d.objetivos}</div>` : ''}
              </td>
              <td class="text-end">
                <button class="btn btn-sm btn-outline-primary fw-bold" onclick="App.verDetalhesDiario(${d.id})">
                  <i class="bi bi-eye me-1"></i> Detalhes
                </button>
              </td>
            </tr>
          `).join('');
        }
      }
    } catch (e) {
      console.error('Erro ao carregar diário:', e);
    }
  },

  filtrarDiario() {
    const busca = (document.getElementById('inputBuscaDiario')?.value || '').trim();
    const turma = document.getElementById('filtroDiarioTurma')?.value || '';
    this.loadDiario(turma, busca);
  },

  async abrirModalNovoDiario() {
    try {
      // Carrega Professores
      const dataProfs = await this.api('/api/professores');
      const selProf = document.getElementById('inputDiarioProfessor');
      if (selProf) {
        selProf.innerHTML = (dataProfs.professores || []).map(p => `<option value="${p.nome}">${p.nome}</option>`).join('');
      }

      // Carrega Turmas
      const dataTurmas = await this.api('/api/turmas');
      const selTurma = document.getElementById('inputDiarioTurma');
      if (selTurma) {
        selTurma.innerHTML = (dataTurmas.turmas || []).map(t => 
          `<option value="${t.id}" data-serie="${t.serie || ''}">${t.nome_turma}</option>`
        ).join('');
      }

      this.onDiarioTurmaChange();

      document.getElementById('inputDiarioData').value = new Date().toISOString().split('T')[0];
      document.getElementById('inputDiarioMateria').value = '';
      document.getElementById('inputDiarioConteudos').value = '';
      document.getElementById('inputDiarioObjetivos').value = '';
      document.getElementById('inputDiarioDesenvolvimento').value = '';
      document.getElementById('inputDiarioAtivSala').value = '';
      document.getElementById('inputDiarioAtivCasa').value = '';
      document.getElementById('inputDiarioRecursos').value = '';
      document.getElementById('inputDiarioAvaliacao').value = 'Participação e fixação de conteúdo em sala';

      const modal = new bootstrap.Modal(document.getElementById('modalNovoDiario'));
      modal.show();
    } catch (e) {
      console.error(e);
    }
  },

  onDiarioTurmaChange() {
    const sel = document.getElementById('inputDiarioTurma');
    const opt = sel ? sel.options[sel.selectedIndex] : null;
    const serie = opt ? opt.getAttribute('data-serie') : '';
    const serieInput = document.getElementById('inputDiarioSerie');
    if (serieInput) serieInput.value = serie || '';
  },

  async salvarNovoDiario() {
    const professor = document.getElementById('inputDiarioProfessor')?.value;
    const turma = document.getElementById('inputDiarioTurma')?.value;
    const serie = document.getElementById('inputDiarioSerie')?.value;
    const data = document.getElementById('inputDiarioData')?.value;
    const materia = (document.getElementById('inputDiarioMateria')?.value || '').trim();
    const conteudos = (document.getElementById('inputDiarioConteudos')?.value || '').trim();

    if (!materia || !conteudos || !data) {
      alert('Por favor, preencha os campos obrigatórios (Data, Matéria e Conteúdos).');
      return;
    }

    const payload = {
      nome_professor: professor,
      turma: turma,
      serie: serie,
      data_diario: data,
      comp_curricular: materia,
      conteudos: conteudos,
      objetivos: document.getElementById('inputDiarioObjetivos')?.value || '',
      desenvolvimento: document.getElementById('inputDiarioDesenvolvimento')?.value || '',
      atividade_sala: document.getElementById('inputDiarioAtivSala')?.value || '',
      atividade_casa: document.getElementById('inputDiarioAtivCasa')?.value || '',
      recursos: document.getElementById('inputDiarioRecursos')?.value || '',
      avaliacao: document.getElementById('inputDiarioAvaliacao')?.value || '',
      ano_letivo: 2026
    };

    try {
      const res = await this.api('/api/diario', 'POST', payload);
      alert(res.message || 'Registro de diário salvo com sucesso!');
      bootstrap.Modal.getInstance(document.getElementById('modalNovoDiario')).hide();
      this.loadDiario();
    } catch (e) {
      alert('Erro ao salvar diário: ' + e.message);
    }
  },

  verDetalhesDiario(id) {
    const d = this.cacheDiario.find(item => item.id == id);
    if (!d) return;

    const body = document.getElementById('diarioDetalhesBody');
    body.innerHTML = `
      <div class="row g-3 mb-3 pb-3 border-bottom">
        <div class="col-md-6">
          <small class="text-muted fw-bold d-block text-uppercase">Professor(a)</small>
          <h6 class="fw-bold text-dark m-0"><i class="bi bi-person-fill text-primary me-1"></i>${d.nome_professor}</h6>
        </div>
        <div class="col-md-3">
          <small class="text-muted fw-bold d-block text-uppercase">Data da Aula</small>
          <span class="badge bg-light text-dark border font-monospace fs-6">${d.data_diario}</span>
        </div>
        <div class="col-md-3">
          <small class="text-muted fw-bold d-block text-uppercase">Turma / Sala</small>
          <span class="badge bg-primary fs-6">${d.nome_turma || d.serie}</span>
        </div>
      </div>

      <div class="mb-3">
        <small class="text-muted fw-bold d-block text-uppercase">Componente Curricular (Matéria)</small>
        <div class="p-2 bg-light rounded border fw-bold text-primary">${d.comp_curricular}</div>
      </div>

      <div class="mb-3">
        <small class="text-muted fw-bold d-block text-uppercase">Conteúdos Ministrados</small>
        <div class="p-3 bg-light rounded border">${d.conteudos || '-'}</div>
      </div>

      ${d.objetivos ? `
        <div class="mb-3">
          <small class="text-muted fw-bold d-block text-uppercase">Objetivos / Habilidades BNCC</small>
          <div class="p-3 bg-light rounded border small">${d.objetivos}</div>
        </div>
      ` : ''}

      ${d.desenvolvimento ? `
        <div class="mb-3">
          <small class="text-muted fw-bold d-block text-uppercase">Metodologia e Desenvolvimento da Aula</small>
          <div class="p-3 bg-light rounded border small">${d.desenvolvimento}</div>
        </div>
      ` : ''}

      <div class="row g-2 mb-3">
        <div class="col-md-6">
          <small class="text-muted fw-bold d-block text-uppercase">Atividade em Sala</small>
          <div class="p-2 bg-light rounded border small">${d.atividade_sala || '-'}</div>
        </div>
        <div class="col-md-6">
          <small class="text-muted fw-bold d-block text-uppercase">Atividade para Casa</small>
          <div class="p-2 bg-light rounded border small">${d.atividade_casa || '-'}</div>
        </div>
      </div>

      <div class="row g-2">
        <div class="col-md-6">
          <small class="text-muted fw-bold d-block text-uppercase">Recursos Didáticos</small>
          <div class="p-2 bg-light rounded border small">${d.recursos || '-'}</div>
        </div>
        <div class="col-md-6">
          <small class="text-muted fw-bold d-block text-uppercase">Avaliação</small>
          <div class="p-2 bg-light rounded border small">${d.avaliacao || '-'}</div>
        </div>
      </div>
    `;

    const modal = new bootstrap.Modal(document.getElementById('modalVerDiarioDetalhes'));
    modal.show();
  },

  // 4.3 ACADÊMICO - DEFINIÇÃO DE BIMESTRES
  async loadBimestres() {
    try {
      const data = await this.api('/api/bimestres');
      const bimestres = data.bimestres || [];

      // Renderiza Cards dos Bimestres
      const cardsContainer = document.getElementById('cardsBimestresContainer');
      if (cardsContainer) {
        cardsContainer.innerHTML = bimestres.map(b => `
          <div class="col-12 col-sm-6 col-lg-3">
            <div class="stat-card">
              <div class="d-flex justify-content-between align-items-center mb-2">
                <span class="badge ${b.status_badge}">${b.status}</span>
                <button class="btn btn-sm btn-outline-primary py-0 px-2" onclick="App.abrirModalEditarBimestre(${b.id}, '${b.nome}', '${b.data_inicio}', '${b.data_fim}')" title="Editar Período">
                  <i class="bi bi-pencil"></i>
                </button>
              </div>
              <h5 class="fw-bold text-dark mb-1"><i class="bi bi-calendar-check text-primary me-1"></i>${b.nome}</h5>
              <div class="small text-muted mt-2">
                <div><strong>Início:</strong> ${b.data_inicio ? b.data_inicio.split('-').reverse().join('/') : '-'}</div>
                <div><strong>Término:</strong> ${b.data_fim ? b.data_fim.split('-').reverse().join('/') : '-'}</div>
              </div>
            </div>
          </div>
        `).join('');
      }

      // Renderiza Tabela
      const tbody = document.getElementById('tableBimestres');
      if (tbody) {
        tbody.innerHTML = bimestres.map(b => `
          <tr>
            <td><strong class="text-primary fs-6">${b.nome}</strong></td>
            <td><span class="badge bg-light text-dark border font-monospace fs-6">${b.data_inicio ? b.data_inicio.split('-').reverse().join('/') : '-'}</span></td>
            <td><span class="badge bg-light text-dark border font-monospace fs-6">${b.data_fim ? b.data_fim.split('-').reverse().join('/') : '-'}</span></td>
            <td><span class="badge ${b.status_badge} fs-6">${b.status}</span></td>
            <td class="text-end">
              <button class="btn btn-sm btn-outline-primary fw-bold" onclick="App.abrirModalEditarBimestre(${b.id}, '${b.nome}', '${b.data_inicio}', '${b.data_fim}')">
                <i class="bi bi-pencil me-1"></i> Editar Período
              </button>
            </td>
          </tr>
        `).join('');
      }
    } catch (e) {
      console.error('Erro ao carregar bimestres:', e);
    }
  },

  abrirModalEditarBimestre(id, nome, inicio, fim) {
    document.getElementById('editBimestreId').value = id;
    document.getElementById('editBimestreTitulo').innerText = `${nome} - Calendário Letivo 2026`;
    document.getElementById('editBimestreInicio').value = inicio || '';
    document.getElementById('editBimestreFim').value = fim || '';
    const modal = new bootstrap.Modal(document.getElementById('modalEditarBimestre'));
    modal.show();
  },

  async salvarEdicaoBimestre() {
    const id = document.getElementById('editBimestreId').value;
    const inicio = document.getElementById('editBimestreInicio').value;
    const fim = document.getElementById('editBimestreFim').value;

    if (!inicio || !fim) {
      alert('Por favor, informe as datas de início e término.');
      return;
    }

    try {
      const res = await this.api(`/api/bimestres/${id}`, 'PUT', {
        data_inicio: inicio,
        data_fim: fim
      });
      alert(res.message || 'Período atualizado com sucesso!');
      bootstrap.Modal.getInstance(document.getElementById('modalEditarBimestre')).hide();
      this.loadBimestres();
    } catch (e) {
      alert('Erro ao atualizar bimestre: ' + e.message);
    }
  },

  // 5. DOCUMENTOS, CONTRATOS E DECLARAÇÕES
  async imprimirDocumento(tipo, alunoId) {
    try {
      const data = await this.api(`/api/documentos/dados?aluno_id=${alunoId}`);
      const a = data.aluno;
      const ra = data.resp_acad || {};
      const rf = data.resp_fin || {};
      const container = document.getElementById('documentoModalBody');

      let titulo = '';
      let corpo = '';

      if (tipo === 'matricula') {
        titulo = 'DECLARAÇÃO DE MATRÍCULA';
        corpo = `
          Declaramos para os devidos fins de direito que o(a) aluno(a) <strong>${a.nome_aluno}</strong>, 
          filho(a) de <strong>${a.mae || ra.nome || '---'}</strong> e <strong>${a.pai || rf.nome || '---'}</strong>, 
          nascido(a) em <strong>${a.datanasc || '---'}</strong> na cidade de <strong>${a.cidade || 'Manaus'} / ${a.UF || 'AM'}</strong>, 
          encontra-se regularmente matriculado(a) e com frequência ativa nesta instituição de ensino no ano letivo de 
          <strong>${a.ano_letivo || new Date().getFullYear()}</strong>, cursando o(a) <strong>${a.etapa || a.nome_turma || 'Ensino Regular'}</strong>, 
          no turno <strong>${a.turno || 'Matutino'}</strong>.<br/><br/>
          Por ser verdade e a pedido do interessado, firmamos a presente declaração.
        `;
      } else if (tipo === 'quitacao') {
        titulo = 'DECLARAÇÃO DE QUITAÇÃO DE DÉBITOS';
        corpo = `
          Declaramos para os devidos fins que o(a) aluno(a) <strong>${a.nome_aluno}</strong>, 
          sob responsabilidade financeira de <strong>${rf.nome || a.pai || '---'}</strong>, portador(a) do CPF nº <strong>${rf.CPF || '---'}</strong>, 
          encontra-se com suas obrigações financeiras e mensalidades escolares plenamente <strong>QUITADAS</strong> 
          perante esta Instituição de Ensino até a presente data, nada constando contra o mesmo referente ao ano letivo em exercício.
        `;
      } else if (tipo === 'comparecimento') {
        titulo = 'DECLARAÇÃO DE COMPARECIMENTO';
        corpo = `
          Declaramos para os devidos fins que o(a) Sr(a). <strong>${rf.nome || ra.nome || a.mae || '---'}</strong>, 
          responsável pelo(a) aluno(a) <strong>${a.nome_aluno}</strong>, compareceu a esta instituição de ensino na presente data 
          para tratar de assuntos de interesse pedagógico e administrativo referentes à vida escolar do seu dependente.
        `;
      } else if (tipo === 'frequencia') {
        titulo = 'DECLARAÇÃO DE FREQUÊNCIA ESCOLAR';
        corpo = `
          Declaramos que o(a) aluno(a) <strong>${a.nome_aluno}</strong>, regularmente matriculado(a) no 
          <strong>${a.etapa || 'Ensino Regular'}</strong>, turno <strong>${a.turno || 'Manhã'}</strong>, apresenta frequência 
          regular às aulas e atividades pedagógicas curriculares desenvolvidas durante o corrente ano letivo.
        `;
      } else if (tipo === 'transferencia') {
        titulo = 'GUIA DE TRANSFERÊNCIA ESCOLAR';
        corpo = `
          Declaramos que foi solicitada e expedida a presente Guia de Transferência do(a) aluno(a) <strong>${a.nome_aluno}</strong>, 
          regularmente matriculado(a) até a presente data no <strong>${a.etapa || 'Ensino Regular'}</strong>, facultando-lhe 
          a continuidade de seus estudos na instituição de destino.
        `;
      } else if (tipo === 'contrato_normal') {
        titulo = 'CONTRATO DE PRESTAÇÃO DE SERVIÇOS EDUCACIONAIS';
        corpo = `
          Pelo presente instrumento particular, de um lado <strong>CENTRO EDUCACIONAL ATENIENSE</strong>, e de outro lado 
          como CONTRATANTE e RESPONSÁVEL FINANCEIRO: <strong>${rf.nome || '---'}</strong>, portador(a) do CPF <strong>${rf.CPF || '---'}</strong>, 
          residente à ${rf.rua || a.rua || '---'}, nº ${rf.numero || a.numero || 'S/N'}, bairro ${rf.bairro || a.bairro || '---'}, Manaus/AM.<br/><br/>
          BENEFICIÁRIO DOS SERVIÇOS (ALUNO): <strong>${a.nome_aluno}</strong>, matriculado no <strong>${a.etapa || 'Ensino Regular'}</strong>, 
          turno <strong>${a.turno || 'Manhã'}</strong>.<br/><br/>
          <strong>CLÁUSULA PRIMEIRA:</strong> O presente contrato tem por objeto a prestação de serviços educacionais correspondentes ao ano letivo de 
          ${a.ano_letivo || new Date().getFullYear()}, ministrado em conformidade com o plano escolar e a legislação vigente.<br/><br/>
          <strong>CLÁUSULA SEGUNDA:</strong> Pelos serviços contratados, o CONTRATANTE pagará à CONTRATADA o valor anual dividido nas mensalidades estipuladas, 
          com vencimento mensal até o 5º dia útil.<br/><br/>
          E por estarem de pleno acordo, firmam o presente em 02 (duas) vias de igual teor.
        `;
      } else if (tipo === 'termo') {
        titulo = 'TERMO DE RESPONSABILIDADE ESCOLAR';
        corpo = `
          Pelo presente termo, eu <strong>${rf.nome || ra.nome || '---'}</strong>, CPF <strong>${rf.CPF || ra.CPF || '---'}</strong>, 
          responsável legal pelo(a) aluno(a) <strong>${a.nome_aluno}</strong>, declaro ter ciência e estar plenamente de acordo com 
          as normas regimentais, regulamento interno e compromissos pedagógicos e disciplinares do Centro Educacional Ateniense.
        `;
      }

      container.innerHTML = `
        <div class="print-document">
          <div class="print-header">
            <img src="/static/img/LogoAteniense.png" alt="Colégio Ateniense" />
            <h4 class="m-0 fw-bold">CENTRO EDUCACIONAL ATENIENSE</h4>
            <p class="m-0 text-muted">Tradição e Excelência no Ensino</p>
            <div class="print-title">${titulo}</div>
          </div>
          <div class="print-body my-4">
            ${corpo}
          </div>
          <div class="print-footer">
            <p class="text-end font-monospace mb-5">${data.data_extenso}</p>
            <div class="row">
              <div class="col-6"><div class="print-signature">Centro Educacional Ateniense</div></div>
              <div class="col-6"><div class="print-signature">Assinatura do Responsável</div></div>
            </div>
          </div>
        </div>
      `;

      const modal = new bootstrap.Modal(document.getElementById('modalDocumentoViewer'));
      modal.show();
    } catch (e) {
      alert('Erro ao gerar documento');
    }
  },

  // 6. RECIBOS DE CAIXA (2ª VIA)
  async imprimirRecibo(caixaId) {
    try {
      const data = await this.api(`/api/documentos/recibo?caixa_id=${caixaId}`);
      const c = data.caixa;
      const a = data.aluno;
      const container = document.getElementById('documentoModalBody');

      container.innerHTML = `
        <div class="print-document" style="min-height: auto; padding: 15mm;">
          <div class="print-header">
            <img src="/static/img/LogoAteniense.png" alt="Colégio Ateniense" style="height: 50px;" />
            <h5 class="m-0 fw-bold">CENTRO EDUCACIONAL ATENIENSE</h5>
            <div class="print-title" style="font-size: 14pt;">RECIBO DE PAGAMENTO #${c.ID_caixa} (2ª VIA)</div>
          </div>
          <div class="print-body my-3">
            <p>Recebemos de <strong>${c.nome || 'CLIENTE'}</strong> a quantia de <strong>R$ ${parseFloat(c.valor_total || 0).toFixed(2)}</strong> (${c.forma || 'DINHEIRO'}).</p>
            <p><strong>Referente a:</strong> ${c.descricao || '-'}</p>
            ${a ? `<p><strong>Aluno:</strong> ${a.nome_aluno} - ${a.etapa || ''}</p>` : ''}
            <p><strong>Observações:</strong> ${c.observacao || 'Nenhuma'}</p>
          </div>
          <div class="print-footer mt-4">
            <div class="d-flex justify-content-between align-items-center">
              <div><small>Operador: ${c.usuario} | ${c.data} ${c.horario || ''}</small></div>
              <div class="print-signature" style="width: 200px; margin-top: 10px;">Tesouraria / Caixa</div>
            </div>
          </div>
        </div>
      `;

      const modal = new bootstrap.Modal(document.getElementById('modalDocumentoViewer'));
      modal.show();
    } catch (e) {
      alert('Erro ao emitir recibo');
    }
  },

  // 7. CARNÊ ESCOLAR
  async imprimirCarne(alunoId) {
    try {
      const data = await this.api(`/api/mensalidades/carne/${alunoId}`);
      const a = data.aluno;
      const m = data.mensalidade;
      if (!m) {
        alert('Nenhuma mensalidade/carnê gerado para este aluno.');
        return;
      }
      const container = document.getElementById('documentoModalBody');
      const nParcelas = parseInt(m.n_parcelas || 12);
      const valorParcela = parseFloat(m.valor_parcela || 0).toFixed(2);

      let parcelasHtml = '';
      for (let i = 1; i <= nParcelas; i++) {
        parcelasHtml += `
          <div class="border p-2 mb-3 rounded" style="background-color: #fafafa; font-size: 10pt;">
            <div class="d-flex justify-content-between border-bottom pb-1 mb-2">
              <strong>CENTRO EDUCACIONAL ATENIENSE - CARNÊ ESCOLAR</strong>
              <span class="badge bg-primary">PARCELA ${i} / ${nParcelas}</span>
            </div>
            <div class="row">
              <div class="col-8">
                <div><strong>Aluno:</strong> ${a.nome_aluno} (Matrícula #${a.ID_aluno})</div>
                <div><strong>Resp. Financeiro:</strong> ${a.resp_nome || '-'} (CPF: ${a.resp_cpf || '-'})</div>
                <div><strong>Ano Letivo:</strong> ${m.ano_letivo || '2026'} | ${m.curso || 'Ensino Regular'}</div>
              </div>
              <div class="col-4 text-end">
                <div><strong>VALOR:</strong> R$ ${valorParcela}</div>
                <small class="text-muted">Vencimento: Dia 05 de cada mês</small>
              </div>
            </div>
          </div>
        `;
      }

      container.innerHTML = `
        <div class="print-document">
          <div class="print-header">
            <img src="/static/img/LogoAteniense.png" alt="Colégio Ateniense" />
            <h4 class="m-0 fw-bold">CENTRO EDUCACIONAL ATENIENSE</h4>
            <div class="print-title">CARNÊ DE PAGAMENTO - ANO ${m.ano_letivo || '2026'}</div>
          </div>
          <div class="my-3">
            ${parcelasHtml}
          </div>
        </div>
      `;

      const modal = new bootstrap.Modal(document.getElementById('modalDocumentoViewer'));
      modal.show();
    } catch (e) {
      alert('Erro ao gerar carnê');
    }
  },

  // 8. PDV - VENDAS
  async setupPDV() {
    const data = await this.api('/api/produtos');
    const select = document.getElementById('pdvProdutoSelect');
    if (select) {
      select.innerHTML = '<option value="">Selecione o produto...</option>' + 
        (data.produtos || []).map(p => `<option value="${p.id}" data-preco="${p.valor_venda}" data-estoque="${p.estoque}" data-nome="${p.produto}">${p.produto} - R$ ${parseFloat(p.valor_venda).toFixed(2)} (Estoque: ${p.estoque})</option>`).join('');
    }
    this.cart = [];
    this.renderCart();
  },

  adicionarItemPDV() {
    const select = document.getElementById('pdvProdutoSelect');
    const opt = select.selectedOptions[0];
    if (!opt || !opt.value) return;

    const id = parseInt(opt.value);
    const nome = opt.getAttribute('data-nome');
    const preco = parseFloat(opt.getAttribute('data-preco'));
    const qtd = parseInt(document.getElementById('pdvQtd').value || 1);

    const existente = this.cart.find(item => item.id === id);
    if (existente) {
      existente.quantidade += qtd;
    } else {
      this.cart.push({ id, produto: nome, valor_venda: preco, quantidade: qtd });
    }

    this.renderCart();
  },

  renderCart() {
    const tbody = document.getElementById('tablePDVItens');
    let total = 0.0;
    if (tbody) {
      tbody.innerHTML = this.cart.map((item, idx) => {
        const sub = item.valor_venda * item.quantidade;
        total += sub;
        return `
          <tr>
            <td>${item.produto}</td>
            <td>R$ ${item.valor_venda.toFixed(2)}</td>
            <td>${item.quantidade}</td>
            <td><strong>R$ ${sub.toFixed(2)}</strong></td>
            <td><button class="btn btn-sm btn-outline-danger" onclick="App.removerItemCart(${idx})">&times;</button></td>
          </tr>
        `;
      }).join('');
    }
    document.getElementById('pdvTotalGeral').innerText = `R$ ${total.toFixed(2)}`;
  },

  removerItemCart(idx) {
    this.cart.splice(idx, 1);
    this.renderCart();
  },

  async finalizarVendaPDV() {
    if (this.cart.length === 0) {
      alert('Adicione produtos ao carrinho.');
      return;
    }
    const cliente = document.getElementById('pdvClienteNome').value || 'CONSUMIDOR';
    const forma = document.getElementById('pdvFormaPagamento').value;

    try {
      const res = await this.api('/api/vendas', 'POST', {
        cliente_nome: cliente,
        forma_pagamento: forma,
        itens: this.cart
      });
      alert(`Venda #${res.codigo_venda} finalizada com sucesso! Total: R$ ${res.total.toFixed(2)}`);
      this.cart = [];
      this.renderCart();
      if (res.caixa_id) {
        this.imprimirRecibo(res.caixa_id);
      }
    } catch (e) {
      alert('Erro ao finalizar venda');
    }
  },

  // 9. DRE GERENCIAL
  async loadDRE(ano = '2026') {
    try {
      const data = await this.api(`/api/dre?ano=${ano}`);
      document.getElementById('dreReceitasAno').innerText = `R$ ${(data.total_receitas || 0).toLocaleString('pt-BR', {minimumFractionDigits: 2})}`;
      document.getElementById('dreDespesasAno').innerText = `R$ ${(data.total_despesas || 0).toLocaleString('pt-BR', {minimumFractionDigits: 2})}`;
      document.getElementById('dreResultadoAno').innerText = `R$ ${(data.resultado_liquido || 0).toLocaleString('pt-BR', {minimumFractionDigits: 2})}`;

      const tbody = document.getElementById('tableDRE');
      if (tbody) {
        tbody.innerHTML = (data.meses || []).map(m => `
          <tr>
            <td><strong>${m.mes_nome}</strong></td>
            <td class="text-success fw-bold">R$ ${m.receitas.toFixed(2)}</td>
            <td class="text-danger fw-bold">R$ ${m.despesas.toFixed(2)}</td>
            <td class="${m.resultado >= 0 ? 'text-primary' : 'text-danger'} fw-bold">R$ ${m.resultado.toFixed(2)}</td>
          </tr>
        `).join('');
      }
    } catch (e) {
      console.error(e);
    }
  },

  // 10. REIMPORTAR / RESTAURAR BANCO DE DADOS
  selectedSqlFile: null,

  abrirModalReimportar() {
    this.selectedSqlFile = null;
    const filePicker = document.getElementById('inputSqlFilePicker');
    if (filePicker) filePicker.value = '';
    const fileInfo = document.getElementById('selectedFileInfo');
    if (fileInfo) fileInfo.classList.add('d-none');
    const loadInd = document.getElementById('importLoadingIndicator');
    if (loadInd) loadInd.classList.add('d-none');
    const resBox = document.getElementById('importResultBox');
    if (resBox) resBox.classList.add('d-none');
    const btn = document.getElementById('btnIniciarImportacao');
    if (btn) btn.disabled = false;

    // Abre o modal
    const modalEl = document.getElementById('modalReimportarBanco');
    if (modalEl) {
      const modal = new bootstrap.Modal(modalEl);
      modal.show();
    }
  },

  onSqlFileSelected(event) {
    const file = event.target.files[0];
    if (file) {
      this.selectedSqlFile = file;
      document.getElementById('selectedFileName').innerText = file.name;
      const sizeMb = (file.size / (1024 * 1024)).toFixed(2);
      document.getElementById('selectedFileSize').innerText = `${sizeMb} MB`;
      document.getElementById('selectedFileInfo').classList.remove('d-none');
    }
  },

  async executarImportacaoBanco() {
    const btn = document.getElementById('btnIniciarImportacao');
    const loadInd = document.getElementById('importLoadingIndicator');
    const resBox = document.getElementById('importResultBox');
    
    // Verifica qual aba está ativa
    const tabFileBtn = document.getElementById('tab-file-btn');
    const isTabFile = tabFileBtn && tabFileBtn.classList.contains('active');

    let payload = {};

    if (isTabFile && this.selectedSqlFile) {
      // Lê o arquivo como texto ou envia para o servidor
      btn.disabled = true;
      loadInd.classList.remove('d-none');
      resBox.classList.add('d-none');

      try {
        const fileContent = await this.lerArquivoComoTexto(this.selectedSqlFile);
        payload = { sql_content: fileContent };
      } catch (err) {
        alert('Erro ao ler o arquivo selecionado no seu computador: ' + err.message);
        btn.disabled = false;
        loadInd.classList.add('d-none');
        return;
      }
    } else {
      const customPath = (document.getElementById('inputCustomSqlPath')?.value || '').trim();
      if (!customPath && !this.selectedSqlFile) {
        alert('Por favor, selecione um arquivo .SQL ou informe o caminho do arquivo.');
        return;
      }
      payload = { caminho_arquivo: customPath || 'database/dbateniense.sql' };
      btn.disabled = true;
      loadInd.classList.remove('d-none');
      resBox.classList.add('d-none');
    }

    try {
      const res = await this.api('/api/database/reimport', 'POST', payload);
      loadInd.classList.add('d-none');
      btn.disabled = false;

      if (res.success) {
        resBox.classList.remove('d-none');
        const det = res.detalhes || {};
        document.getElementById('importResultTitle').innerText = res.message;
        document.getElementById('importResultSummary').innerHTML = `
          Tempo de execução: <strong>${det.elapsed || 0}s</strong> | 
          Total de Tabelas: <strong>${det.total_tables || 0}</strong> | 
          Total de Registros Importados: <strong>${(det.total_records || 0).toLocaleString('pt-BR')}</strong>
        `;

        const tablesDiv = document.getElementById('importTablesList');
        if (tablesDiv && det.tables) {
          tablesDiv.innerHTML = Object.entries(det.tables)
            .sort((a, b) => b[1] - a[1])
            .map(([t, count]) => `
              <div class="col-6 col-md-4">
                <span class="badge bg-light text-dark border me-1">${t}</span>
                <span class="text-primary fw-bold">${count}</span>
              </div>
            `).join('');
        }

        // Atualiza Dashboard e estatísticas
        this.loadDashboard();
      } else {
        alert('Erro ao importar: ' + (res.error || 'Falha na importação.'));
      }
    } catch (e) {
      loadInd.classList.add('d-none');
      btn.disabled = false;
      alert('Erro na requisição de importação: ' + e.message);
    }
  },

  lerArquivoComoTexto(file) {
    return new Promise((resolve, reject) => {
      const reader = new FileReader();
      reader.onload = (e) => resolve(e.target.result);
      reader.onerror = (e) => reject(new Error('Falha ao ler o arquivo local.'));
      reader.readAsText(file);
    });
  }
};

document.addEventListener('DOMContentLoaded', () => App.init());
