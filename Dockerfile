FROM python:3.11-slim

WORKDIR /app

# O projeto utiliza exclusivamente a biblioteca padrão do Python
COPY . /app

EXPOSE 8080

ENV PYTHONUNBUFFERED=1
ENV PORT=8080

CMD ["python3", "server.py", "8080"]
