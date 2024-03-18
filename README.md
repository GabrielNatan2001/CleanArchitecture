 - Domain: Modelo de domínio, regras de negócio, interfaces
 - Application: Regras de domínios da aplicação, mapeamentos, serviços, DTOs, CQRS
 - Data: EF Core, Contexto, Configurações, Migrations, Repository
 - Infra/IoC: Dependecy Injection, registros dos serviços, tempo de vida
 - UI: MVC, Controller, Views, Filtros, ViewModels, API


 Relacionamento e dependência entre os projetos
 - Domain: não possui dependências
 - Application: dependência com o projeto domain
 - Data: dependência com o projeto domain
 - IoC: dependência com os projetos domain, Application, Data
 - UI/API: dependência com o projeto IoC

 Registros de Dependência
 - Transient(AddTrasient) = Cria os objetos a cada vez que forem solicitados
 - Scoped(AddScoped) = Cria os objetos uma vez por solicitação
 - Singleton(AddSingleton) = Cria os objetos apenas na primeira vez que for solicitado