# Getting Started

You can develop your own app and use the ArmyPlanner data. There is a ready-made library for this purpose:

[ArmyPlanner for .NET Projects (via NuGet)](https://www.nuget.org/packages/ArmyPlanner)

[![Build](https://github.com/lk-code/armyplanner-core/actions/workflows/net-build.yml/badge.svg)](https://github.com/lk-code/armyplanner-core/actions/workflows/net-build.yml)

### setup your project

1. add the nuget: <br />
`PM> Install-Package ArmyPlanner`

2. add the ArmyPlanner Services (via Dipendency Injection)<br />
`using ArmyPlanner.Extensions;`<br />
`...`<br />
`IServiceCollection services = ....`<br />
`services.AddArmyPlanner();`

3. ArmyPlanner services store data locally on a device storage. For this, a path must be specified by the developer. There is an internal app path (to store the repository data) and a public path for the user (to store the roster files)<br />
`// set app paths`<br />
`APP_DOCUMENTS_PATH = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}{Path.DirectorySeparatorChar}{DIRECTORY_APP_NAME}";`<br />
`APP_LOCAL_PATH = FileSystem.Current.AppDataDirectory; // on .NET MAUI`<br />
`APP_LOCAL_PATH = ApplicationData.Current.LocalFolder.Path; // on UWP`<br />
` `<br />
`// CodexService`<br />
`ICodexService codexService = App.Services.GetService<ICodexService>();`<br />
`codexService.SetBasePathForCodexData(APP_LOCAL_PATH);`<br />
` `<br />
`// RepositoryService`<br />
`IRepositoryService repositoryService = App.Services.GetService<IRepositoryService>();`<br />
`repositoryService.SetBasePathForData(APP_LOCAL_PATH);`<br />
` `<br />
`// RosterService`<br />
`IRosterService rosterService = App.Services.GetService<IRosterService>();`<br />
`rosterService.SetBasePathForRosterData(APP_DOCUMENTS_PATH);`<br />

4. Now you can work with ArmyPlanner platform 😊

### ArmyPlanner Library Content

#### ArmyPlanner Services

The ArmyPlanner services are the central access to the entire platform. It is recommended to perform all work through these services.

The following services are added via the DI method `AddArmyPlanner();`

* [`IHttpService`](developer/services/http-service.md) ArmyPlanner services access various endpoints through the HTTP-Service
* [`IRepositoryService`](developer/services/repository-service.md) Provides methods to access the ArmyPlanner repository
* [`ITranslationService`](developer/services/translation-service.md) Provides easy access to ArmyPlanner's translation engine
* [`ICodexService`](developer/services/codex-service.md) Provides the interface for accessing and working with codices data
* [`IRosterService`](developer/services/roster-service.md) Provides the interface for accessing and working with roster data