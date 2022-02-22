# Desafio-ecommerce
Este repositório contém um web api escrito em C# usando o framework .NET para o desafio de entrevista da WA Project.

# Como abrir o projeto
Para utilizar o projeto sera necessário fazer o download do visual studio
O principal motivo é que o proprio visual studio ja vem com o SQL Server junto da instalação 

utilizei a versão 2022 .NET 6.0 (Suporte de longo prazo) 

[Link para download Visual studio](https://visualstudio.microsoft.com/pt-br/downloads/)

Versão gratis - Visual Studio 2022 Comunidade

---

Apos baixar o visual studio e o arquivo do projeto abra o arquivo como mostra a imagem
![Dentro da pasta abra o visual studio](https://export-download.canva.com/Ajw7k/DAE5GHAjw7k/5/0/0001-19606018163.png?X-Amz-Algorithm=AWS4-HMAC-SHA256&X-Amz-Credential=AKIAJHKNGJLC2J7OGJ6Q%2F20220222%2Fus-east-1%2Fs3%2Faws4_request&X-Amz-Date=20220222T004847Z&X-Amz-Expires=63480&X-Amz-Signature=161797c1a413caa666f0a6b8c5bdc027b2673f9f0fc5d516fa16998361aa6c48&X-Amz-SignedHeaders=host&response-content-disposition=attachment%3B%20filename%2A%3DUTF-8%27%27Design%2520sem%2520nome.png&response-expires=Tue%2C%2022%20Feb%202022%2018%3A26%3A47%20GMT)

---

Em seguida abra Desafio o Desafio E-commerce Dashboard Local.sin
![abrir o projeto](https://export-download.canva.com/i2z54/DAE5F6i2z54/18/0/0001-19600313687.png?X-Amz-Algorithm=AWS4-HMAC-SHA256&X-Amz-Credential=AKIAJHKNGJLC2J7OGJ6Q%2F20220222%2Fus-east-1%2Fs3%2Faws4_request&X-Amz-Date=20220222T095228Z&X-Amz-Expires=27287&X-Amz-Signature=7e064538bc97e88d06abeb855955cc506632ed8e0f7a8a0b939836927c989dd3&X-Amz-SignedHeaders=host&response-content-disposition=attachment%3B%20filename%2A%3DUTF-8%27%27Design%2520sem%2520nome.png&response-expires=Tue%2C%2022%20Feb%202022%2017%3A27%3A15%20GMT)

---

Ao abrir pela primeira vez é possivel que demore um pouco e também pessa para baixar mais algumas Dependências
![Click em play para rodar a aplicação](https://export-download.canva.com/i2z54/DAE5F6i2z54/31/0/0001-19601656638.png?X-Amz-Algorithm=AWS4-HMAC-SHA256&X-Amz-Credential=AKIAJHKNGJLC2J7OGJ6Q%2F20220222%2Fus-east-1%2Fs3%2Faws4_request&X-Amz-Date=20220222T053249Z&X-Amz-Expires=43087&X-Amz-Signature=951a06537261d6b271db89a969ec1fca54902a8860916d4aee383d0cb8480eae&X-Amz-SignedHeaders=host&response-content-disposition=attachment%3B%20filename%2A%3DUTF-8%27%27Design%2520sem%2520nome.png&response-expires=Tue%2C%2022%20Feb%202022%2017%3A30%3A56%20GMT)

---

Após aberto o projeto no navegador falta uma ultima etapa
ao clicar em pedidos, produtos ou equipe aparecera uma mennsagem de erro, click em adicionar migrações e recarregue a pagina e pronto
tudo deve estar funcionando normalmente agora


# Desafio tokens segurança

Entre os desafios estava a geração de um token de seguraça
E como isto não esta muito visivel no projeto eu decidi colocar aqui algumas instruções e imagens para demonstrar

Para isso eu utilizei o postman 
[Link para download do Postman](https://www.postman.com/downloads/)


![Click em play para rodar a aplicação](https://export-download.canva.com/4AhpQ/DAE5GB4AhpQ/3/0/0001-19604076121.png?X-Amz-Algorithm=AWS4-HMAC-SHA256&X-Amz-Credential=AKIAJHKNGJLC2J7OGJ6Q%2F20220222%2Fus-east-1%2Fs3%2Faws4_request&X-Amz-Date=20220222T115911Z&X-Amz-Expires=19526&X-Amz-Signature=d230963ad6aa39b3a7a520595b4a40a010d93f7c5e2973257b468f83255c57ff&X-Amz-SignedHeaders=host&response-content-disposition=attachment%3B%20filename%2A%3DUTF-8%27%27Design%2520sem%2520nome.png&response-expires=Tue%2C%2022%20Feb%202022%2017%3A24%3A37%20GMT)


Basta colocar a porta com a url correta
Digite um email de usuario valido e um user name

Se tudo estiver correto ele retornara um 200 Ok
E ira gerar uma senha para a conexão

![Click em play para rodar a aplicação](https://export-download.canva.com/4AhpQ/DAE5GB4AhpQ/6/0/0001-19604794945.png?X-Amz-Algorithm=AWS4-HMAC-SHA256&X-Amz-Credential=AKIAJHKNGJLC2J7OGJ6Q%2F20220221%2Fus-east-1%2Fs3%2Faws4_request&X-Amz-Date=20220221T200948Z&X-Amz-Expires=78694&X-Amz-Signature=a0edf84cd0ad5117eb5494aa571c87e295b5061148da22c09c9ed1a317e17172&X-Amz-SignedHeaders=host&response-content-disposition=attachment%3B%20filename%2A%3DUTF-8%27%27Design%2520sem%2520nome.png&response-expires=Tue%2C%2022%20Feb%202022%2018%3A01%3A22%20GMT)

Com o email e a senha confirmado ele então gera um token de segurança do tipo Jwt com as informações da conta


Salvo no banco de dados

![Click em play para rodar a aplicação](https://export-download.canva.com/4AhpQ/DAE5GB4AhpQ/8/0/0001-19605095677.png?X-Amz-Algorithm=AWS4-HMAC-SHA256&X-Amz-Credential=AKIAJHKNGJLC2J7OGJ6Q%2F20220222%2Fus-east-1%2Fs3%2Faws4_request&X-Amz-Date=20220222T030525Z&X-Amz-Expires=53730&X-Amz-Signature=4eabd0e99e13d577c31f0ded8bcbe41586a7bb90e00197684e4674a5de992af8&X-Amz-SignedHeaders=host&response-content-disposition=attachment%3B%20filename%2A%3DUTF-8%27%27Design%2520sem%2520nome.png&response-expires=Tue%2C%2022%20Feb%202022%2018%3A00%3A55%20GMT)
