# Clean Architecture - Implementação Básica com ASP .NET Core
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)
![ASP .NET](https://img.shields.io/badge/ASP_.NET-v8.0-808080?style=for-the-badge&logo=.net&logoColor=white&&labelColor=purple)
![SQLite](https://img.shields.io/badge/sqlite-%2307405e.svg?style=for-the-badge&logo=sqlite&logoColor=white)
![Docker](https://img.shields.io/badge/docker-%230db7ed.svg?style=for-the-badge&logo=docker&logoColor=white)


## O que é a Clean Architecture?
A Clean Architecture é um padrão arquitetural de software baseado no princípio de separação de interesses, onde a aplicação é dividida em diferentes camadas, cada uma com sua preocupação. O objetivo é proporcionar aos desenvolvedores uma forma melhor de organizar o código, separando as regras de negócio, facilitando o desenvolvimento e a manutenção do código.

![The Clean Architecture by Robert C. Martin](https://blog.cleancoder.com/uncle-bob/images/2012-08-13-the-clean-architecture/CleanArchitecture.jpg)
: The Clean Architecture by Robert C. Martin

## Como está implementada a dependência entre os projetos nessa solução?

- CleanArch.Domain
    - Como esta é a camada central (contém as regras de negócio), o projeto não faz referencia a nenhum outro projeto externo.

- CleanArch.Application
    - Depende de CleanArch.Domain

- CleanArch.Infra.Data
    - Depende de CleanArch.Domain

- CleanArch.Infra.IoC
    - Depende de CleanArch.Domain
    - Depende de CleanArch.Application
    - Depende de CleanArch.Infra.Data

- CleanArch.MVC
    - Depende de CleanArch.Infra.IoC

## Testando o Projeto
Essa aplicação não tem como foco sua apresentação e funcionalidades, mas sim a forma como os projetos foram definidos e como cada um se comunica entre si, seguindo os princípios da Clean Architecture, para fins de aprendizado.

### Docker
Execute o comando ```docker compose up --build``` e acesse ```http://localhost:8080``` para testar o app.

### Teste Local
- Pré-requisitos:
    * [.NET 8.0 SDK](https://dotnet.microsoft.com/pt-br/download)


#### Build
```bash
cd CleanArchitecture-Basic/
dotnet build
```

#### Run
```bash
cd CleanArch/CleanArch.MVC
dotnet run
```
> Pode ser necessário permitir o uso de HTTPS no ambiente local. Para isso, ative a confiança no *cetificado https* do *dotnet* com o seguinte comando: ```dotnet dev-certs https --trust```

## Referências

Este projeto foi criado com base no conteúdo do canal do [Jose Carlos Macoratti](https://www.youtube.com/@josecarlosmacoratti), que forneceu detalhes da construção de cada projeto e como seria a dependencia entre eles.

## Licença
[![License](https://img.shields.io/github/license/Ileriayo/markdown-badges?style=for-the-badge)](./LICENSE)