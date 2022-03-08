global using BlazorCrudStudy.Client.Services.SuperHeroService;
global using BlazorCrudStudy.Shared;
using BlazorCrudStudy.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

/* Add custom client-side-service */
builder.Services.AddScoped<ISuperHeroService, SuperHeroService>();

await builder.Build().RunAsync();
