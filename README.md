# PasswordCheck

## Teste técnico de implementação de lógica

Considere uma senha sendo válida quando a mesma possuir as seguintes definições:

- Nove ou mais caracteres
- Ao menos 1 dígito
- Ao menos 1 letra minúscula
- Ao menos 1 letra maiúscula
- Ao menos 1 caractere especial
  - Considere como especial os seguintes caracteres: !@#$%^&*()-+
- Não possuir caracteres repetidos dentro do conjunto

Exemplo:  

```c#
IsValid("") // false  
IsValid("aa") // false  
IsValid("ab") // false  
IsValid("AAAbbbCc") // false  
IsValid("AbTp9!foo") // false  
IsValid("AbTp9!foA") // false
IsValid("AbTp9 fok") // false
IsValid("AbTp9!fok") // true
```

> **_Nota:_**  Espaços em branco não devem ser considerados como caracteres válidos.
## Problema

Construa uma aplicação que exponha uma api web que valide se uma senha é válida.

Input: Uma senha (string).  
Output: Um boolean indicando se a senha é válida.

## Pontos que daremos maior atenção

- Testes de unidade / integração
Requisito atendido. Exemplos:
    - O projeto WebApi possui testes de unidade
    - O projeto WebApp possui testes de integração

- Abstração, acoplamento, extensibilidade e coesão
Requisito atendido. Exemplos:
    - Abstração: No projeto backend, a classe PasswordService permite interação como entidade
    - Acoplamento: No projeto backend, a classe IPasswordService permite acoplamento aceitável quando usa apenas métodos públicos da classe PasswordService
    - Extensibilidade: No projeto backend, 

- Design de API
Requisito atendido. Exemplos: 
    - A api do projeto backend possui documentação através do Swagger
    - Simplicidade e de fácil entendimento
    - Padrão RESTful utilizado
    - Possui versionamento

- Clean Code
Requisito atendido. Exemplos:
    - Os métodos possuem nomes auto explicativos. 
    - Possuem objetivos únicos
    - Ex.: CheckIfIsValid(), IsValid(), IsValid_Returns_Expected_Result()

- SOLID
Requisito atendido. Exemplos:
    - S: Single Responsibility Principle usado na classe PasswordService 
    - O: Open/Closed Principle não foi utilizado
    - L: Liskov Substitution Principle não foi utilizado
    - I: Interface Segregation Principle usado na clase IPasswordService
    - D: Dependency Inversion Principle usado na classe program

- Documentação da solução no *README*
Requisito atendido.

# Estrutura do Projeto backend

|--Back/<br />
&nbsp;&nbsp;|--src/<br />
&nbsp;&nbsp;&nbsp;&nbsp;|--PasswordValidator.API/<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|--Controllers<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|--Properties<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|--Services<br />
&nbsp;&nbsp;&nbsp;&nbsp;|--PasswordValidator.Tests<br />
&nbsp;&nbsp;&nbsp;&nbsp;|--PasswordValidator.sln<br />

* O projeto backend webapi foi desenvolvido com .Net 7.0.3
- Apenas o ambiente de desenvolvimento foi configurado
- Uma política de CORS genérica foi configurada para permitir o acesso via api
    Program.cs - app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
- Uma classe chamada PasswordService.cs foi utilizada para dar suporte ao projeto de teste. Em um projeto maior, esse serviço poderia ser um microsservice que diminuiria o acoplamento.

* O projeto de teste unitário de unidade utilizou xUnit 2.4.2 
- O projeto de testes faz referência para:
     ..\PasswordValidator.API\PasswordValidator.API.csproj

## Comandos para rodar esse projeto

    * WebApi
    PasswordCheck\Back\src\PasswordValidator.API> dotnet run
    http://localhost:5062
    http://localhost:5062/swagger/index.html   

    * Testes
    PasswordCheck\Back\src\PasswordValidator.Tests> dotnet test

# Estrutura do Projeto frontend

|--Front/<br />
&nbsp;&nbsp;|--PassworkChecker-App/<br />
&nbsp;&nbsp;&nbsp;&nbsp;|--src/<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|--app/<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|--password-form<br />  

* O projeto frontend WebApp foi desenvolvido em: 
    - Angular CLI: 16.0.0       
    - Node: 18.14.1
    - Package Manager: npm 9.6.6

- A pasta cache gerada pelo projeto de teste foi adicionado ao .gitignore      

## Comandos para rodar esse projeto

    * WebApp
    PasswordCheck\Front\PasswordChecker-App> npm start

    * Testes
    PasswordCheck\Front\PasswordChecker-App> npm test 

# Link do repositório público com a solução

Github: https://github.com/luishpp/PasswordCheck