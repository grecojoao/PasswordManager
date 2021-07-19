# API - Gerenciador de Senhas
[![NPM](https://img.shields.io/npm/l/react)](https://github.com/grecojoao/PasswordManager/blob/master/LICENSE) 

## ⚡ Sobre o projeto

API Gerenciador de senhas é uma aplicação back-end desenvolvida para o fornecimento e validação de senhas.

A aplicação possui o Endpoint: "/Login" do tipo Post, que é responsável por autenticar o usuário e gerar um Token do tipo JWT Bearer.
No corpo da requisição devem ser informados o nome de usuário e senha:

````
{
  "user": "string",
  "password": "string"
}
````


Também possui o Endpoint: "/Password/Validate" do tipo Post, que recebe no corpo da requisição uma senha e a valida de acordo com as regras de négocio:

````
{
  "password": "string"
}
````

Regras de négocio: 

- Conter no mínimo 15 caracteres;
- Conter no mínimo uma letra maiúscula;
- Conter no mínimo uma letra minúscula;
- Conter no mínimo um dos seguintes caracteres especiais: (@,#,_,- e !);
- Não pode conter caracteres repetidos em sequência, por exemplo: 1111, aaaa, bbbb, @@@@, BBBB;
- Deve prever case-sensitive, por exemplo: A é diferente de a;


E por fim também possui o Endpoint: "/Password/Generate" do tipo Get, que é responsável por gerar uma senha válida de acordo com as regras de négocio anteriores.

Os métodos "/Password/Validate" e "/Password/Generate" requerem que o usuário esteja autenticado, deve-se passar o token no cabeçalho da requisição. Exemplo: Key: "Authorization", Value: "Bearer MEUTOKEN1!2@3#".


## :rocket: Tecnologias
- C#, ASP.NET Core(5.0)
- Docker

## :bomb: Implantação em produção
- [Microsoft Azure](https://passwordmanager-api.azurewebsites.net/swagger)

## 📝 Como executar o projeto
Pré-requisitos: 
- ASP.NET Core Runtime 5.0.8 ou 
- SDK 5.0.302(desenvolvimento)

````bash
# clonar o repositório
git clone https://github.com/grecojoao/PasswordManager.git

# entrar na pasta da API
cd PasswordManager/PasswordManager.API

# restaurar as dependências
dotnet restore

# executar o projeto
dotnet watch run
````

- Windows: Docker Desktop WSL 2
- Linux: Docker Desktop

````bash
# clonar a imagem docker
docker pull grecojoao/passwordmanagerapi

# executar a imagem docker
docker run grecojoao/passwordmanagerapi
````
