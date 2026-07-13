# Modelos de IA

## Objetivo

Gerenciar os modelos disponíveis em cada provider.

## Estrutura

Modelo

- Nome
- Identificador
- Provider
- Categoria
- Context Window
- Tokens Máximos
- Entrada por Token
- Saída por Token
- Modalidades
- Status

## Categorias

- Chat
- Embeddings
- Visão
- Áudio
- Transcrição
- Tradução
- Geração de Imagens

## Exemplos

### OpenAI

- GPT-4.1
- GPT-4.1 Mini
- GPT-4o
- GPT-4o Mini
- o3
- o4-mini

### Google

- Gemini 2.5 Pro
- Gemini 2.5 Flash

### Anthropic

- Claude Sonnet
- Claude Opus

### Ollama

- Llama
- Mistral
- Gemma
- DeepSeek

## Funcionalidades

- Cadastro
- Ativação
- Desativação
- Definir modelo padrão
- Limites por tenant
- Controle de custos

## Regras

- Um provider possui vários modelos.
- Cada tenant poderá escolher seus modelos autorizados.
- Modelos poderão ser substituídos automaticamente conforme disponibilidade.