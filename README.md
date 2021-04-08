# :checkered_flag: Backend Challenge Iti

### :point_right: Descrição do Projeto
Esse projeto faz parte de um desafio de desenvolvimento backend. Objetivo é validar uma senha na API, com seguintes critérios:
- Nove ou mais caracteres
- Ao menos 1 dígito
- Ao menos 1 letra minúscula
- Ao menos 1 letra maiúscula
- Ao menos 1 caractere especial
	- Considere como especial os seguintes caracteres: !@#$%^&*()-+
- Não possuir caracteres repetidos dentro do conjunto 

### :point_right: Tecnologias utilizadas
- **C#**
- **Asp.Net Core 3.1**
- **Swagger**
- **xUnit** 
### :point_right: Processo de Desenvolvimento

Tentei seguir boas práticas usando conceitos de Clean Code e SOLID e Design de API tentei ao não fazer algo tão complexo para resolver um problema simples, mas ao mesmo tempo organizei a arquitetura de uma forma limpa, contendo as camadas de:
- Api
- Core
- Infra

Para realizar a validação da senha criei um recurso na "ValidatorsController" para receber via HTTP POST e validar se o mesmo foi preenchido usando a validação do Modelo "ModelState", caso contrário irá dispara uma mensagem informando que o campo é requerido. Usei POST pois se trata de um dado mais sensível e acredito faz sentido encapsular no corpo da requisição.

Para orquestrar o procedimento criei Service onde tem a responsabilidade de acionar a regra de negócio em uma classe de validação. Não criei entidade pois entendo que Senha não é uma entidade mas sim a propriedade, como contrato criei uma classe chamada AbstractValidator genérica onde é possível passar qualquer tipo para ela e implementar o método "IsValid" usando o tipo passado, ou seja houvesse a necessidade de criar uma entidade e validar a mesma com regras diferentes, será somente criar uma nova classe de validação e implementar essa interface, permitindo que haja alta coesão por quem implementar e tendo que explicitar suas regras, e baixo acoplamento pois a classe dependente de si mesmo para realizar a validação do que for passado com tipo.

Para resolver as validações solicitadas foi criado uma “Expressão Regular” para resolver a mesma, pois ser um projeto de desafio não estou levando em consideração a performance que em cenários maiores deve-se ser repensado. 

Para testar criei dois projetos de Testes que valida partes unidade do código, e outro para validar a integração da aplicação, com os cenários de senhas inválidas e senha valida com o resultado esperado.

Por ultimo inclui o “Swagger” para documentar o recurso criado visando uma boa pratica de API.

### :point_right: Executando o projeto

Instalar .Net Core 3.1 SDK
link: https://dotnet.microsoft.com/download/dotnet/3.1

Utilize o CLI do .NET Core para checar a instalação, digite os comandos abaixo:
$ dotnet --version

Acessar o diretório na pasta raiz do projeto onde se encontra a sln e execute:

$ dotnet restore

$ dotnet build

$ cd src\PasswordValidator.Api

$ dotnet run

> **_Nota:_** Para acessar a documentação cole no browser: http://localhost:5000/swagger/index.html

### :point_right: Testes
- Ainda com o CMD aberto voltar para pasta raiz do projeto onde se encontra o arquivo sln 

$ dotnet test
