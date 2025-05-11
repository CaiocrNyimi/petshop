## API de Gerenciamento de Pet Shop

### Descrição do Projeto

Esta é uma API de gerenciamento de informações sobre os animais de um pet shop. Ela permite realizar Cadastro, Leitura, Atualização e Exclusão de animais, facilitando a organização e o acesso aos dados dos pets.

### Rotas

A API utiliza como endpoint principal o parâmetro: `/animais`. Abaixo está a demonstração de utilização das rotas disponíveis e suas funcionalidades:

1. `GET /animais`

- Descrição: Retorna todos os animais cadastrados no sistema.
- Método HTTP: `GET`
- Tipo de Retorno: `application/json`
- Códigos de Status: `200 OK`: Retorna a lista de animais com sucesso.
- Exemplo de Resposta:
    `json
    [
      {
        "id": 1,
        "nome": "Patrick",
        "raca": "Salsicha",
        "idade": 8
      },
      {
        "id": 2,
        "nome": "Bob",
        "raca": "Siamês",
        "idade": 5
      }
    ]
    `

2. `GET /animais/{id}`

- Descrição: Retorna um animal com base no seu ID.
- Método HTTP: `GET`
- Parâmetros de Rota: `id` (int): O ID do animal a ser buscado.
- Tipo de Retorno: `application/json`
- Códigos de Status: `200 OK`: Retorna o animal encontrado com sucesso;
                     `404 Not Found`: Se nenhum animal for encontrado com o ID fornecido.
- Exemplo de Resposta (200 OK):
    `json
    {
      "id": 2,
      "nome": "Bob",
      "raca": "Siamês",
      "idade": 5
    }
    `
- Exemplo de Resposta (404 Not Found):
    `json
    {
      "type": "https://tools.ietf.org/html/rfc9110#section-15.5.5",
      "title": "Not Found",
      "status": 404,
      "traceId": "00-cd799f7829a508c27a9f585254b8be6c-a8d6ea17254b1fb1-00"
    }
    `

3. `POST /animais`

- Descrição: Adiciona um novo animal ao sistema.
- Método HTTP: `POST`
- Corpo da Requisição: `application/json`
- Esquema do Corpo da Requisição:
    `json
    {
      "nome": "Florzinha",
      "raca": "Pit bull",
      "idade": 4
    }
    `
- Tipo de Retorno: `application/json`
- Códigos de Status: `201 Created`: Retorna o animal recém-criado com sucesso;
                     `400 Bad Request`: Se os dados do animal fornecidos forem inválidos.
- Exemplo de Resposta (201 Created):
    `json
    {
      "id": 3,
      "nome": "Florzinha",
      "raca": "Pit bull",
      "idade": 4
    }
    `

4. `PUT /animais/{id}`

- Descrição: Atualiza as informações de um animal com base no seu ID.
- Método HTTP: `PUT`
- Parâmetros de Rota: `id` (int): O ID do animal a ser atualizado.
- Corpo da Requisição: `application/json`
- Esquema do Corpo da Requisição: (Semelhante ao `POST`, mas sem `id`, pois já é declarado na rota).
    `json
    {
      "nome": "Florzinha",
      "raca": "Chihuahua",
      "idade": 4
    }
    `
- Tipo de Retorno: `application/json`
- Códigos de Status: `200 OK`: Retorna o animal com as informações atualizadas com sucesso;
                     `400 Bad Request`: Se os dados do animal fornecidos na requisição forem inválidos;
                     `404 Not Found`: Se nenhum animal for encontrado com o ID fornecido.
- Exemplo de Resposta (200 OK):
    `json
    {
      "id": 3,
      "nome": "Florzinha",
      "raca": "Chihuahua",
      "idade": 4
    }
    `

5. `DELETE /animais/{id}`

- Descrição: Remove um animal do sistema com base no seu ID.
- Método HTTP: `DELETE`
- Parâmetros de Rota: `id` (int): O ID único do animal a ser removido.
- Tipo de Retorno: Nenhum corpo na resposta.
- Códigos de Status: `204 No Content`: O animal foi removido com sucesso;
                     `404 Not Found`: Se nenhum animal for encontrado com o ID fornecido.

### Instalação

Para executar esta API localmente, siga os seguintes passos:

**Pré-requisitos:**

**.NET SDK:** SDK do .NET (8.0 ou superior).
**Visual Studio ou outro editor de código:** Visual Studio é mais recomendado, porém você pode usar outros editores como Visual Studio Code.
**Banco de Dados Oracle:** Instância do banco de dados Oracle rodando e configurada para a API (já está configurado).
**SQL Developer Oracle:** Para verificar os dados no banco, caso necessário.

**Passos para Instalação:**

1. Clonar o Repositório:
    `bash
    git clone https://github.com/CaiocrNyimi/petshop
    cd petshop
    `

2. Configurar a String de Conexão (já está configurado):
    - Navegue até o projeto `PetShop.API`.
    -Abra o arquivo `appsettings.json`.
    - Localize a seção `ConnectionStrings` e atualize a string de conexão `OracleConnection` com as credenciais corretas para o seu banco de dados Oracle.
    `json
    {
      "ConnectionStrings": {
      "OracleConnection": "Data Source=[hostname]:[port]/[sid];User ID=[username];Password=[password];"
      },
      "Logging": {
        "LogLevel": {
          "Default": "Information",
          "Microsoft.AspNetCore": "Warning"
        }
      },
      "AllowedHosts": "*"
    }
    `

3. Aplicar Migrações do Entity Framework Core:
    - Abra o terminal ou o cmd na pasta raiz do projeto.
    - Execute os seguintes comandos para garantir que o banco de dados esteja configurado corretamente:
        `
          dotnet tool install --global dotnet-ef
          dotnet ef database update --project PetShop.Infrastructure --startup-project PetShop.API
        `
        Esses comandos criarão as tabelas necessárias no seu banco de dados Oracle com base nas definições das entidades do Entity Framework Core.

4. Restaurar Pacotes NuGet:
    - Se você abriu o projeto no Visual Studio, ele geralmente restaura os pacotes NuGet automaticamente. Caso contrário, execute o seguinte comando no terminal, dentro da pasta raiz da sua solução:
        `
          dotnet restore
        `

5. Executar a API:
    - Navegue até a pasta `PetShop.API` no terminal.
    - Execute o seguinte comando para iniciar a API:
        `
          dotnet run
        `
    - A API estará disponível na seguinte URL `http://localhost:[porta]`, sendo [porta] o número exibido no seu terminal quando a aplicação for iniciada.

6.  Acessar a Documentação do Swagger UI:
    - Após a API estar rodando, você pode acessar a documentação interativa da API através do Swagger UI. Abra seu navegador e teste a API ma seguinte URL:
        `
        http://localhost:[porta]/swagger
        `
    - Aqui você poderá explorar os endpoints da API, visualizar os schemas de requisição e resposta, e interagir com a API diretamente.
