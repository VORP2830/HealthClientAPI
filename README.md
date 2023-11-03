
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

# Requisitos
- Todas as respostas da API devem ser JSON
- Fornece um arquivo README.md com instruções de uso (como executar, endpoints etc)