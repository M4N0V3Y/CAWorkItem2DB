
Autor: ** JOSMAR AUGUSTO FONSECA BARBOSA **

This is a project for collect WorkItens from AZURE and keep it in a data base for be used with an AngularJS/Boostrap front end.


This application is configurable by XML file in local disk.
I created a XML as example: 

Fie path:)[C:\AzureWorkItemsDb\AzureDevOpsConfig.xml]

With the following information:
```xml
<?xml version="1.0" encoding="utf-8" ?>"
<AzureDevOps>"
	<uri>https://dev.azure.com/[nome.do.projeto.devops]/</uri>"
	<tokenPA>[hash token PA para acessar o projeto DevOps]</tokenPA>"
	<project>[nome.do.projeto.devops]</project>"
	<DBFileName>Filename=C:\\AzureWorkItemsDb\\AzureWorkItemsDb.db</DBFileName>"
	<WebFileName>C:\\NodeJS\\JSONDB\\AzureWorkItemsDb.json</WebFileName>"
</AzureDevOps>"
```

It's on going work


