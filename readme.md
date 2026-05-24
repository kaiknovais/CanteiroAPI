# Canteiro API

Olá, meu nome é Kaik Novais e esta é uma API de teste desenvolvida com .NET Core para gerenciamento de obras, permitindo o controle de funcionários, equipamentos e tarefas.

## Tecnologias

- .NET 10
- Entity Framework Core
- SQLite
- Swagger

## Entidades

- **Funcionario** — cadastro de profissionais da obra
- **Equipamento** — controle de máquinas e ferramentas
- **Tarefa** — atribuição de atividades a funcionários e equipamentos

## Como rodar

1. Clone o repositório
2. Entre na pasta do projeto
3. Rode os comandos:

```bash
dotnet restore
dotnet ef database update
dotnet run
```

4. Acesse o Swagger em `http://localhost:{porta}/swagger`

## Endpoints

### Funcionario

| Método | Rota | Descrição |
|--------|------|-----------|
| GET | /api/Funcionario | Lista todos os funcionários |
| POST | /api/Funcionario | Cria um funcionário |
| GET | /api/Funcionario/{id} | Busca um funcionário |
| PUT | /api/Funcionario/{id} | Edita um funcionário |
| DELETE | /api/Funcionario/{id} | Deleta um funcionário |

### Equipamento

| Método | Rota | Descrição |
|--------|------|-----------|
| GET | /api/Equipamento | Lista todos os equipamentos |
| POST | /api/Equipamento | Cria um equipamento |
| GET | /api/Equipamento/{id} | Busca um equipamento |
| PUT | /api/Equipamento/{id} | Edita um equipamento |
| DELETE | /api/Equipamento/{id} | Deleta um equipamento |

### Tarefa

| Método | Rota | Descrição |
|--------|------|-----------|
| GET | /api/Tarefa | Lista todas as tarefas |
| POST | /api/Tarefa | Cria uma tarefa |
| GET | /api/Tarefa/{id} | Busca uma tarefa |
| PUT | /api/Tarefa/{id} | Edita uma tarefa |
| DELETE | /api/Tarefa/{id} | Deleta uma tarefa |