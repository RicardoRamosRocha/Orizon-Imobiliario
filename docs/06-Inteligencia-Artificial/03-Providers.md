# Providers de Inteligência Artificial

## Objetivo

Permitir que a plataforma utilize diferentes provedores de IA sem alterar as regras de negócio.

## Providers Suportados

### OpenAI

Modelos GPT para geração de texto, análise e raciocínio.

### Google Gemini

Modelos multimodais para texto, imagem e documentos.

### Anthropic

Modelos Claude voltados para análise, documentos extensos e segurança.

### Azure OpenAI

Versão corporativa dos modelos OpenAI hospedados na Azure.

### Ollama

Execução local de modelos open source.

### OpenRouter

Gateway para múltiplos modelos utilizando uma única API.

## Estrutura

Provider

- Nome
- Tipo
- URL Base
- API Key
- Organização
- Região
- Status
- Prioridade
- Timeout
- Limite de Requisições
- Data de Cadastro

## Funcionalidades

- Ativar/Inativar
- Testar conexão
- Definir prioridade
- Balanceamento
- Fallback automático
- Limites por tenant
- Auditoria

## Regras

- Um tenant pode utilizar vários providers.
- Um provider pode possuir vários modelos.
- O sistema deve alternar automaticamente em caso de falha.