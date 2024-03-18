 - Domain: Modelo de dom�nio, regras de neg�cio, interfaces
 - Application: Regras de dom�nios da aplica��o, mapeamentos, servi�os, DTOs, CQRS
 - Data: EF Core, Contexto, Configura��es, Migrations, Repository
 - Infra/IoC: Dependecy Injection, registros dos servi�os, tempo de vida
 - UI: MVC, Controller, Views, Filtros, ViewModels, API


 Relacionamento e depend�ncia entre os projetos
 - Domain: n�o possui depend�ncias
 - Application: depend�ncia com o projeto domain
 - Data: depend�ncia com o projeto domain
 - IoC: depend�ncia com os projetos domain, Application, Data
 - UI/API: depend�ncia com o projeto IoC

 Registros de Depend�ncia
 - Transient(AddTrasient) = Cria os objetos a cada vez que forem solicitados
 - Scoped(AddScoped) = Cria os objetos uma vez por solicita��o
 - Singleton(AddSingleton) = Cria os objetos apenas na primeira vez que for solicitado