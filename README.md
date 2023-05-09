  _____                                    _    _____ _               _    
 |  __ \                                  | |  / ____| |             | |   
 | |__) |_ _ ___ _____      _____  _ __ __| | | |    | |__   ___  ___| | __
 |  ___/ _` / __/ __\ \ /\ / / _ \| '__/ _` | | |    | '_ \ / _ \/ __| |/ /
 | |  | (_| \__ \__ \\ V  V / (_) | | | (_| | | |____| | | |  __/ (__|   < 
 |_|   \__,_|___/___/ \_/\_/ \___/|_|  \__,_|  \_____|_| |_|\___|\___|_|\_\

# Teste técnico de implementação de lógica

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
- Abstração, acoplamento, extensibilidade e coesão
- Design de API
- Clean Code
- SOLID
- Documentação da solução no *README* 

# Estrutura do Projeto backend

* O projeto backend webapi foi desenvolvido com .Net 7.0.3
- Apenas o ambiente de desenvolvimento foi configurado
- Uma política de CORS genérica foi configurada para permitir o acesso via api
    Program.cs - app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
- Uma classe chamada PasswordService.cs foi utilizada para dar suporte ao projeto de teste. Em um projeto maior, esse serviço poderia ser um microsservice que diminuiria o acoplamento.

* O projeto de teste unitário de unidade utilizou xUnit 2.4.2 
- O projeto de testes faz referência para:
     ..\PasswordValidator.API\PasswordValidator.API.csproj

----Back/
    |----src/
        |----PasswordValidator.API
            |----Controllers
            |----Properties
            |----Services
        |----PasswordValidator.Tests
        |----PasswordValidator.sln

## Comandos para rodar esse projeto

    * WebApi
    PasswordCheck\Back\src\PasswordValidator.API> dotnet run
    http://localhost:5062
    http://localhost:5062/swagger/index.html   

    * Testes
    PasswordCheck\Back\src\PasswordValidator.Tests> dotnet test

# Estrutura do Projeto frontend

* O projeto frontend WebApp foi desenvolvido em: 
    - Angular CLI: 16.0.0       
    - Node: 18.14.1
    - Package Manager: npm 9.6.6

- A pasta cache gerada pelo projeto de teste foi adicionado ao .gitignore

----Front/
    |----PassworkChecker-App/
        |----src/
            |----app/
                |----password-form        

## Comandos para rodar esse projeto

PasswordCheck\Front\PasswordChecker-App> npm start
PasswordCheck\Front\PasswordChecker-App> npm test 


# Link do repositório público com a solução

Github: https://github.com/luishpp/PasswordCheck