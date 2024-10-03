# RepoFinder - Projeto de integração com API do Github

Este projeto é uma Web API desenvolvida com .NET Core 8 que é consumida por uma SPA desenvolvida com Angular 18. O principal
é objetivo implementar uma integração com a API pública do GitHub para busca de dados referentes a repositórios públicos e seus respectivos donos.

## Funcionalidades de ponta a ponta (Backend e Frontend)
- Listagem de todos os repositórios do meu perfil.
- Busca de detalhes de repositórios por nome e dono.

## Pré-requisitos:
- .NET SDK (Última versão estável recomendada)
- Node.js and npm
- Angular CLI

## Executando o projeto:
1. Clone o repositório do projeto
> git clone https://github.com/your-username/github-api-integration.git

> cd RepoFinder
2. Abra as soluções no Visual Studio selecione RepoFinder.Server como Startup Project
3. Pressione o botão run e aguarde alguns minutos até a aplicação ser iniciada

## Estrutura do Projeto
### Back-End
- Domain: contém as classes que definem as entidades da aplicação.
- Business: contém as regras de negócio para consulta de repositórios, exceções e definição de interfaces para comunicação com APIs externas.
- Infra: contém as implementações concretas dos serviços que se comunicam com serviços externos.
- Infra.Data: contém as implementações e configurações relacionadas à persistência em bancos de dados.
- Server(Application): contém a implementação da Web Api em .NET.
- client: contém a SPA desenvolvida em angular que consome a API desenvolvida em .NET.

### Front-End
- components: componentes reutilizados em vários pontos da aplicação.
- models: modelos de dados que são retornas pela web api.
- services: serviços que isolam a comunicação com web api.
- pages: páginas da aplicação.
- errors: classes que mapeiam erros na aplicação.
- utils: classes utilitárias.

## API endpoints
- GET: /api/github/repositories/{githubUsername} - Lista todos os repositórios por username
- GET: /api/github/repositories/{githubUsername}/{githubRepositoryName} - Busca repositório por username e nome do repositório
- GET: /api/github/repositories/search?search={searchText}&items_per_page=10&page=1 - Busca paginada de repositórios por nome
