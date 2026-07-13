# Arquitetura de Inteligência Artificial

## Objetivo

Construir uma arquitetura desacoplada que permita trocar provedores de IA sem alterar as regras de negócio.

## Camadas

```
Aplicação
      │
      ▼
AI Service
      │
      ▼
Prompt Builder
      │
      ▼
Provider
      │
      ▼
Modelo
      │
      ▼
Resposta
```

## Componentes

### AI Service

Responsável por centralizar todas as chamadas para IA.

### Prompt Builder

Constrói prompts padronizados.

### Provider

Implementação específica de cada fornecedor.

Exemplos:

- OpenAI
- Google Gemini
- Anthropic
- Azure OpenAI
- Ollama

### Modelos

Cada provider poderá possuir diversos modelos.

### Memória

Armazena contexto da conversa.

### Ferramentas

Executam ações externas.

### RAG

Consulta documentos antes da geração da resposta.

### Observabilidade

Monitora:

- Tokens
- Tempo de resposta
- Custos
- Erros
- Latência

## Princípios

- Baixo acoplamento
- Fácil expansão
- Multi-tenant
- Alta disponibilidade
- Baixo custo operacional