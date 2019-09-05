
Este projeto tem por finalidade coletar WorkItens do ambiente DevOps do AZURE, salvar em um Banco de dados e disponibilizar para ser utilizado por uma aplicação NodeJS / AngularJS com Boostrap.

Observação: 

Eu tenho experiência com NodeJS e com outros frameworks do NodeJS ( ReactJS por exemplo). Uso muito Flask/Python e outras soluções Web também mas não tenho experiEncia suficiente em AngularJS e Bootstrap, por isso a segunda parte da solução não ficou pronta à tempo).

Iniciei ente trabalho hoje, às 11H30 da manhã e finalizei hoje as 22h20.
Pelo fato de hoje ser o deadline para este processo, estou enviando a part do projeto Csharp 100% funcional.

Características do projeto:

Faz uso do pacote NuGet – Microsoft.TeamFoundation para acessar os itens do AZURE DevOps;
Faz uso do Pacote Nugete - LiteDB para criar um banco de dados local
Exporta dados para um arquivo .JSON para ser utilizado pela plataforma NodeJS/Angular ( eu sei que existem soluções melhores, mas só pude me dedicar a este teste hoje).

O aplicativo é totalmente configurável por um arquivo XML que deverá ser criado e armazenado em seu disco local.

A exemplo eu criei um arquivo XML em: 

C:\AzureWorkItemsDb\AzureDevOpsConfig.xml

Ele deverá conter as seguintes informações:

<?xml version="1.0" encoding="utf-8" ?>
<AzureDevOps>
	<uri>https://dev.azure.com/[nome.do.projeto.devops]/</uri>
	<tokenPA>[hash token PA para acessar o projeto DevOps]</tokenPA>
	<project>[nome.do.projeto.devops]</project>
	<DBFileName>Filename=C:\\AzureWorkItemsDb\\AzureWorkItemsDb.db</DBFileName>
	<WebFileName>C:\\NodeJS\\JSONDB\\AzureWorkItemsDb.json</WebFileName>
</AzureDevOps>

Note que eu deixei indicadas as pastas onde devem estar armazenados os arquivos DB ( banco de dados do LiteDB) e JSON ( arquivo que alimentaria a página Web).

Este arquivo XML é utilizado pela classe GlobalConfiguration (que é um Singleton). A idéia é que todas as configurações ( local do arquivo de banco de dados, local do arquivo JSON, dados de acesso, etc...) ficassem armazenado neste XML, como meta-dados, e fossem disponibilizado de forma estática por esta instância Singleton.

Eu também decidi criar a classe de gestão de banco de dados, instanceCAWorkItem2DB, como Singleton. Foi uma decisão baseada em disponibilidade do recurso para qualquer parte do aplicativo. Ela, na verdade, só faz mesmo é encapsular a conexão com o DB.

A classe que realiza o acesso aos Workitems do DevOps do Azure é a classe ExecWorkItemsQuery. Ela contém uma query que está “hard coded” embutida no código. A idéia é transferir a definição desta query para o XML. 
A classe WorkItemCRUD é para ser uma FACADE de todas as operações CRUD sobre o objeto WorkItemPOCO (POCO) que contém a estrutura dos WorkItems.

Bom, eu desenvolvi este aplicativo através da metodologia XP programming. Montei um ambiente DevOps apenas com uma Board e alguns WorkItens para acessar. Pena que não pude iniciar antes de ontém. Teria dado tempo de pensar melhor nas coisas. 

Mas este projeto mostra um pouco de forma eu posso trabalhar sob pressão.

** Senhores:  eu fiquei devendo a parte Web. Se você me derem mais um dia eu posso desenvolver a parte Web ( eu acabei usando somente um dos três dias de projeto, não tive tempo mesmo).


