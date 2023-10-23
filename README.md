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

![video-output-371C4690-857B-4D64-833B-21F82F363850](https://github.com/louresb/DesafioDotNetBaltaIO/assets/103293696/f1bc5af0-a80a-431b-8691-4182d79db5eb)

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
  <img src="https://github.com/louresb/DesafioDotNetBaltaIO/assets/103293696/be3a9ec1-9f26-4bc8-817c-05beef60b636" height="250px"; width="25%">
  <img src="https://github.com/louresb/DesafioDotNetBaltaIO/assets/103293696/4fda56d8-0eab-4475-bde0-ad6a1311500a" height="250px"; width="25%">
  <img src="https://github.com/louresb/DesafioDotNetBaltaIO/assets/103293696/80ebde16-ca2c-4806-8a64-016c9d12f03d" height="250px"; width="45%">
  <br />
  <br />
  <img src="https://github.com/louresb/DesafioDotNetBaltaIO/assets/103293696/3a2ff9b1-39a0-4b50-8ffc-ba65629199fb" height="150px"; width="45%">
</div>

### Todas as cidades / Pesquisa por cidade
<div>
  <img src="https://github.com/louresb/DesafioDotNetBaltaIO/assets/103293696/a947e448-c7d8-45a6-9ad1-311304271492" height="320px"; width="35%">
  <img src="https://github.com/louresb/DesafioDotNetBaltaIO/assets/103293696/dfb4cdce-75d1-42d4-a0ba-0aac647c3014" height="180px"; width="30%">
  <img src="https://github.com/louresb/DesafioDotNetBaltaIO/assets/103293696/f554da14-8de6-4e9a-bdd5-ec79bff9870a" height="150px"; width="25%">
</div>

### Pesquisa por estado
<div>
  <img src="https://github.com/louresb/DesafioDotNetBaltaIO/assets/103293696/6fd10a04-59cf-4b23-ab69-06d8e3db70ee" height="350px"; width="50%">
  <img src="https://github.com/louresb/DesafioDotNetBaltaIO/assets/103293696/618bf380-5d76-4759-854b-e771bc1c3d51" height="250px"; width="40%">
</div>

### Pesquisa por código do IBGE
<div>
  <img src="https://github.com/louresb/DesafioDotNetBaltaIO/assets/103293696/49620944-e7dd-465f-a24b-3c837e2ad927" height="250px"; width="40%">
  <img src="https://github.com/louresb/DesafioDotNetBaltaIO/assets/103293696/a4f181db-7b22-4551-8657-f0aa7d80df5b" height="150px"; width="45%">
</div>

### Adicionar cidade
<div>
  <img src="https://github.com/louresb/DesafioDotNetBaltaIO/assets/103293696/d7335d63-6430-4ecd-9b83-84dd208f2ec1" height="280px"; width="25%">
  <img src="https://github.com/louresb/DesafioDotNetBaltaIO/assets/103293696/807b9016-9396-4489-a9d8-873b7aa0334b" height="150px"; width="25%">  
</div>

### Editar registro / Deletar cidade
<div>
  <img src="https://github.com/louresb/DesafioDotNetBaltaIO/assets/103293696/c0f970ba-bfee-41e0-a61d-08e38ca7c0a7" height="320px"; width="25%">
  <img src="https://github.com/louresb/DesafioDotNetBaltaIO/assets/103293696/5218c1bd-f91f-47f7-9f0c-19265d86a9c" height="80px"; width="10%"> 
  <img src="https://github.com/louresb/DesafioDotNetBaltaIO/assets/103293696/bca269bf-3f0a-45b6-bef1-f141767e94d1" height="280px"; width="50%">
  <img src="https://github.com/louresb/DesafioDotNetBaltaIO/assets/103293696/5334473e-d83b-4993-a0d3-82c5ae5f1b17" height="80px"; width="10%">
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
