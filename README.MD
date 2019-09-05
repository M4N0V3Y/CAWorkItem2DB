
Este projeto tem por finalidade coletar WorkItens do ambiente DevOps do AZURE, salvar em um Banco de dados e disponibilizar para ser utilizado por uma aplica��o NodeJS / AngularJS com Boostrap.

Observa��o: 

Eu tenho experi�ncia com NodeJS e com outros frameworks do NodeJS ( ReactJS por exemplo). Uso muito Flask/Python e outras solu��es Web tamb�m mas n�o tenho experiEncia suficiente em AngularJS e Bootstrap, por isso a segunda parte da solu��o n�o ficou pronta � tempo).

Iniciei ente trabalho hoje, �s 11H30 da manh� e finalizei hoje as 22h20.
Pelo fato de hoje ser o deadline para este processo, estou enviando a part do projeto Csharp 100% funcional.

Caracter�sticas do projeto:

Faz uso do pacote NuGet � Microsoft.TeamFoundation para acessar os itens do AZURE DevOps;
Faz uso do Pacote Nugete - LiteDB para criar um banco de dados local
Exporta dados para um arquivo .JSON para ser utilizado pela plataforma NodeJS/Angular ( eu sei que existem solu��es melhores, mas s� pude me dedicar a este teste hoje).

O aplicativo � totalmente configur�vel por um arquivo XML que dever� ser criado e armazenado em seu disco local.

A exemplo eu criei um arquivo XML em: 

C:\AzureWorkItemsDb\AzureDevOpsConfig.xml

Ele dever� conter as seguintes informa��es:

<?xml version="1.0" encoding="utf-8" ?>
<AzureDevOps>
	<uri>https://dev.azure.com/[nome.do.projeto.devops]/</uri>
	<tokenPA>[hash token PA para acessar o projeto DevOps]</tokenPA>
	<project>[nome.do.projeto.devops]</project>
	<DBFileName>Filename=C:\\AzureWorkItemsDb\\AzureWorkItemsDb.db</DBFileName>
	<WebFileName>C:\\NodeJS\\JSONDB\\AzureWorkItemsDb.json</WebFileName>
</AzureDevOps>

Note que eu deixei indicadas as pastas onde devem estar armazenados os arquivos DB ( banco de dados do LiteDB) e JSON ( arquivo que alimentaria a p�gina Web).

Este arquivo XML � utilizado pela classe GlobalConfiguration (que � um Singleton). A id�ia � que todas as configura��es ( local do arquivo de banco de dados, local do arquivo JSON, dados de acesso, etc...) ficassem armazenado neste XML, como meta-dados, e fossem disponibilizado de forma est�tica por esta inst�ncia Singleton.

Eu tamb�m decidi criar a classe de gest�o de banco de dados, instanceCAWorkItem2DB, como Singleton. Foi uma decis�o baseada em disponibilidade do recurso para qualquer parte do aplicativo. Ela, na verdade, s� faz mesmo � encapsular a conex�o com o DB.

A classe que realiza o acesso aos Workitems do DevOps do Azure � a classe ExecWorkItemsQuery. Ela cont�m uma query que est� �hard coded� embutida no c�digo. A id�ia � transferir a defini��o desta query para o XML. 
A classe WorkItemCRUD � para ser uma FACADE de todas as opera��es CRUD sobre o objeto WorkItemPOCO (POCO) que cont�m a estrutura dos WorkItems.

Bom, eu desenvolvi este aplicativo atrav�s da metodologia XP programming. Montei um ambiente DevOps apenas com uma Board e alguns WorkItens para acessar. Pena que n�o pude iniciar antes de ont�m. Teria dado tempo de pensar melhor nas coisas. 

Mas este projeto mostra um pouco de forma eu posso trabalhar sob press�o.

** Senhores:  eu fiquei devendo a parte Web. Se voc� me derem mais um dia eu posso desenvolver a parte Web ( eu acabei usando somente um dos tr�s dias de projeto, n�o tive tempo mesmo).

