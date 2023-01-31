# HVEXTest
API criada com algumas camadas. Existem 3 delas, a Presentation, a Application e a Data.

O mongoDB foi o banco utilizado, conforme solicitado no PDF do teste. A configuração está no arquivo
appsettings.json. ConnectionString, DatabaseName e o nome das collections. Mas vou deixar aqui também
para facilitar: 

"HvexTesteDatabase": {
    "ConnectionString": "mongodb://localhost:27017",
    "DatabaseName": "HvexTesteDb",
    "HvexTesteCollectionName": [ "User", "Transformer", "Test", "Report" ]
  },

Usei as melhores praticas que conheço, usando injeção de dependência e algumas validações mais importantes.
Ao rodar o projeto via visualStudio, você conseguirá testar os endpoints através do Swagger.

Em relação as camadas, a Presentation Layer contêm as controllers e alguns arquivos de configuração.
A Application, foi onde implementei a regra de negócio. Utilizei de DTO's para
a transfererncia de dados entre a Presentation e a Aplication Layer. A Model da entidade em si,
só trafega nas duas camadas mais interiores (Application e Data) da API, onde ocorre a comunicação com o banco. Na camada Application também criei meus validadores. Utilizei de abstrações para definir os contratos das services e repositorios. Cada abstração está em sua devida camada. Na camada Data, estão os modelos das entidades e os repositorios de cada uma.

Como foi a primeira vez utilizando um banco NoSQL, defini os relacionametos deixando referencias no documentos onde foi necessário. Vi também que eu poderia injetar um documento dentro do outro, mas preferi deixar somente as referencias. 

Fiz uma camada de testes, porém só deixei um exemplo de teste em User, para demonstrar que tenho conhecimento com alguns testes.