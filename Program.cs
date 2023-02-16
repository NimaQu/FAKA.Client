using System.Text.Json;
using Blazored.LocalStorage;
using FAKA.Client;
using FAKA.Client.Auth;
using FAKA.Server.Auth;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
var configuration = builder.Configuration;

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(configuration.GetValue<string>("BaseUrl")) });
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<CustomAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(provider => provider.GetRequiredService<CustomAuthenticationStateProvider>());
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddHttpClient<AuthenticationHttpClient>(client =>
    client.BaseAddress = new Uri(configuration.GetValue<string>("BaseUrl")?.TrimEnd('/') ?? string.Empty));
builder.Services.AddAuthorizationCore();
builder.Services.AddMudServices();

await builder.Build().RunAsync();
