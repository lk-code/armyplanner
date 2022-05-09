using ArmyPlanner.Pages;
using ArmyPlanner.Pages.Interfaces;
using ArmyPlanner.Pages.Services.Navigation;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddSingleton<INavigationService, NavigationService>();

await builder.Build().RunAsync();
