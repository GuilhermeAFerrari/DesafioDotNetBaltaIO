# Desafio de API de Localidades - Nível Pleno

[![licence mit](https://img.shields.io/badge/licence-MIT-blue.svg)](https://github.com/GuilhermeAFerrari/DesafioDotNetBaltaIO/blob/main/LICENSE)
![Development Status Badge](https://img.shields.io/badge/Status-Completed-green)

Resolução do desafio proposto pela plataforma [Balta.io](https://balta.io/), que consistiu na criação de uma API de Localidades com base nos dados abrangentes sobre cidades e estados de todo o Brasil. O desafio foi estruturado em torno de um [repositório](https://github.com/andrebaltieri/ibge) contendo dados do IBGE pertinentes a todas os municípios do país.

## Grupo - 18

[Guilherme Ferrari](https://github.com/GuilhermeAFerrari)

[Samuel Felipe Lima](https://github.com/SamuelFLM)

[Bruno Loures](https://github.com/louresb)

## Ferramentas utilizadas

- .NET 7
- Minimal API
- Clean Architecture
- Swagger 
- Xunit 
- Razor Pages
- Azure 
- MySQL

## Requisitos do Desafio

- Autenticação e Autorização
    - Cadastro de E-mail e Senha
    - Login (Token, JWT)
- CRUD de Localidade
    - Código, Estado, Cidade (Id, City, State)
- Pesquisa por cidade
- Pesquisa por estado
- Pesquisa por código do IBGE
- Boas práticas da API 
    - Versionamento
    - Padronização 
    - Documentação (Swagger)

## Documentação

Consulte a documentação no Swagger. Você pode acessá-la [aqui](https://challenge-balta-io.azurewebsites.net/swagger/index.html).

![video-output-371C4690-857B-4D64-833B-21F82F363850](https://github.com/louresb/Portfolio/assets/103293696/58d4a96d-a056-480a-b50c-aae13008d763)

- Para realizar login insira as informações como no JSON abaixo:

```json
{
  "email": "challenge@baltaio.com",
  "password": "1q2w3e4!@#",
  "name": "user-admin"
}
```

- Copie o Response body com o Token JWT gerado.

- Clique no botão Authorize.

- Insira Bearer seguido de seu token JWT para obter autorização nos Endpoints.

## Endpoints da API

### Location

- `GET /v1/locations` - Retorna todas as localidades disponíveis.
- `GET /v1/locations/{city}` - Pesquisar as cidades por nome.
- `GET /v1/locations/{state}` - Pesquisar os estados por nome.
- `GET /v1/locations/{ibge}` - Pesquisar por código do IBGE.
- `POST /v1/location` - Criar um registro de cidade.
- `PUT /v1/location` - Atualizar um registro de cidade.
- `DELETE /v1/location/{ibge}` - Deletar um registro de cidade.

### User

- `POST /v1/login` - Fazer login na aplicação.
- `POST /v1/register` - Criar registro de usuário.

## Screenshots

<div align="center">

### Registro / Login / Token JWT
<div>
  <img src="https://github.com/louresb/Portfolio/assets/103293696/52f80a5a-bbdc-4e35-80e7-f7b6bb898f59" height="250px"; width="25%">
  <img src="https://github.com/louresb/Portfolio/assets/103293696/dee6b887-4240-4560-927a-db70406168b1" height="250px"; width="25%">
  <img src="https://github.com/louresb/Portfolio/assets/103293696/ced3f1f4-076f-42db-b54b-34641fd33dd3" height="250px"; width="45%">
  <br />
  <br />
  <img src="https://github.com/louresb/Portfolio/assets/103293696/289c2d3b-9bdc-4c2f-8f7a-ebef628bbade" height="150px"; width="45%">
</div>

### Todas as cidades / Pesquisa por cidade
<div>
  <img src="https://github.com/louresb/Portfolio/assets/103293696/42b01242-c49e-4655-9b3d-3aa3e7d76512" height="320px"; width="35%">
  <img src="https://github.com/louresb/Portfolio/assets/103293696/0b7379b4-748a-405b-adb7-fc111fc4f132" height="180px"; width="30%">
  <img src="https://github.com/louresb/Portfolio/assets/103293696/3b8d9042-6e35-4dee-a6c7-b7bc7c8ad7c5" height="150px"; width="25%">
</div>

### Pesquisa por estado
<div>
  <img src="https://github.com/louresb/Portfolio/assets/103293696/ae16c932-6d01-49bc-a27b-ef96a613821f" height="250px"; width="40%">
  <img src="https://github.com/louresb/Portfolio/assets/103293696/a43cc695-76f4-41cd-b884-a5825b9ccb74" height="350px"; width="50%">
</div>

### Pesquisa por código do IBGE
<div>
  <img src="https://github.com/louresb/Portfolio/assets/103293696/ad28f3aa-0ecf-4563-82fa-91fcd19296c2" height="250px"; width="40%">
  <img src="https://github.com/louresb/Portfolio/assets/103293696/ff6a249b-0149-49d1-80ba-082a24c0c19f" height="150px"; width="45%">
</div>

### Adicionar cidade
<div>
  <img src="https://github.com/louresb/Portfolio/assets/103293696/cbf2106d-de74-412f-86e0-d9f42526a4fa" height="280px"; width="25%">
  <img src="https://github.com/louresb/Portfolio/assets/103293696/9ead1dbe-1a9c-42a2-8688-7730bdfad5f4" height="150px"; width="25%">  
</div>

### Editar registro / Deletar cidade
<div>
  <img src="https://github.com/louresb/Portfolio/assets/103293696/3038f43e-9275-4ffb-ac79-d17af1f3b5c5" height="320px"; width="25%">
  <img src="https://github.com/louresb/Portfolio/assets/103293696/22620cd5-a79b-4472-aab5-d433a6bcb3a9" height="80px"; width="10%"> 
  <img src="https://github.com/louresb/Portfolio/assets/103293696/380279a5-9ada-4d96-9a69-0d54922887c0" height="280px"; width="50%">
  <img src="https://github.com/louresb/Portfolio/assets/103293696/cdd88d30-7dab-488e-83d9-772f205c9937" height="80px"; width="10%">
</div>
</div>

## Deploy e CI/CD

```mermaid
graph TD
  A[GitHub Repository] --> B[GitHub Actions]
  B --> C[Build]
  B --> D[Deploy]
  C --> E[Build & Test]
  D --> F[Deploy no Azure]
  F --> G[Azure Web App]
  E --> G
  G --> H[Ambiente de produção]
  H --> I[Azure Web App]
  H --> J[MySQL Database]
```

## Contribuições

Contribuições são bem-vindas! Se você encontrar algum problema ou tiver sugestões de melhorias, abra uma issue ou envie uma pull request.

## Licença
[MIT License](https://github.com/GuilhermeAFerrari/DesafioDotNetBaltaIO/blob/main/LICENSE) ©
[Bruno Loures](https://github.com/louresb),
[Guilherme Ferrari](https://github.com/GuilhermeAFerrari), 
[Samuel Felipe Lima](https://github.com/SamuelFLM).