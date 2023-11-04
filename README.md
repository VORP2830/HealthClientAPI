
# O Desafio
Crie uma API simples para gerenciar Clientes. Esta API deve permitir:
- Criar um cliente
- Editar um cliente
- Obter um cliente específico
- Listar clientes

Um Cliente deve ter os seguintes campos:
- nome
- data de nascimento
- sexo 
- [ problemas de saude ]
- data de criação
- data de atualização

Problemas de Saúde
- nome
- grau do problema (de 1 a 2)
    
    ```
    ex: diabetes, grau 2
    ```

Criar um endpoint para trazer os 10 clientes com maior risco de saúde, no qual o cálculo é:
    
    ```
        sd = soma do grau dos problemas
        score = (1 / (1 + eˆ-(-2.8 + sd ))) * 100
    ```

# Documentação da API

A **API de Gerenciamento de Clientes de Saúde** é uma aplicação que permite o gerenciamento de informações de clientes, incluindo detalhes de saúde e cálculos de risco de saúde. 

## Como Executar

Siga estas etapas para executar a API em seu ambiente de desenvolvimento:

**Clone o repositório:**

```
git clone https://github.com/VORP2830/HealthClientAPI.git
````

**Instale as dependências:**

```
dotnet restore
```

**Configure a conexão com o banco de dados no arquivo `appsettings.json`**

**Execute as migrations:**

```
dotnet ef database update
```

**Execute a API:**
```
dotnet run
```

A API estará disponível em [http://localhost:5235](http://localhost:5235). 

## Endpoints

### Clientes

- **GET /api/client**: Obtenha a lista de clientes paginada.
- **GET /api/client/{id}**: Obtenha um cliente específico por ID.
- **GET /api/client/HealthScoreRisk**: Obtenha os 10 clientes com maior risco de saúde.
- **POST /api/client**: Crie um novo cliente.
- **PUT /api/client**: Atualize um cliente existente.
- **DELETE /api/client/{id}**: Exclua um cliente por ID.

### Problemas de Saúde

- **GET /api/healthproblem/{id}**: Obtenha um problema de saúde específico por ID.
- **PUT /api/healthproblem**: Salve problemas de saúde para um cliente específico, enviando com Id igual 0 cria com Id valido atualiza.
- **DELETE /api/healthproblem/{id}**: Exclua um problema de saúde por ID.

### Informações de Saúde

- **GET /api/health**: Obtenha informações de saúde do servidor.

### Documentação (Swagger)

A API inclui documentação interativa usando o Swagger. Para explorar os endpoints e testar a API, acesse [http://localhost:5235/swagger/index.html](http://localhost:5235/swagger/index.html) após iniciar a aplicação.

## Formato dos Dados

#### Cliente (ClientDTO)

```
{
    "id": 1,
    "name": "Nome do Cliente",
    "birthDay": "1990-01-01",
    "sex": "Masculino",
    "healthProblems": [
            {
            "id": 1,
            "name": "Problema de Saúde",
            "degree": 1
            }
        ]
}
```
Problema de Saúde (HealthProblemDTO)
```
{
  "id": 1,
  "name": "Problema de Saúde",
  "degree": 1,
  "clientId": 1
}

```
Cliente com Risco de Saúde (ClientRiskProblemDTO)
```
{
  "id": 1,
  "name": "Nome do Cliente",
  "birthDay": "1990-01-01",
  "sex": "Masculino",
  "healthScoreRisk": 75.0
}
```