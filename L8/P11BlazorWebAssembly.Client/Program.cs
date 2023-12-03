using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.LocalStorage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using P06Shop.Shared.Configuration;
using P06Shop.Shared.Services.AuthService;
using P06Shop.Shared.Services.ProductService;
using P06Shop.Shared.Services.SongService;
using P11BlazorWebAssembly.Client;
using P11BlazorWebAssembly.Client.Services.CustomAuthStateProvider;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var appSettings = builder.Configuration.GetSection(nameof(AppSettings));
var appSettingsSection = appSettings.Get<AppSettings>();

var uriBuilderAuth = new UriBuilder(appSettingsSection.BaseAPIUrl)
{
    // Path = appSettingsSection.BaseSongEndpoint.Base_url
};
//Microsoft.Extensions.Http
// builder.Services.AddHttpClient<IProductService, ProductService>(client => client.BaseAddress = uriBuilder.Uri);
builder.Services.AddHttpClient<IAuthService, AuthService>(client => client.BaseAddress = uriBuilderAuth.Uri); 


var uriBuilderSong = new UriBuilder(appSettingsSection.BaseAPIUrl)
{
    Path = appSettingsSection.BaseSongEndpoint.Base_url
};

builder.Services.AddHttpClient<ISongService, SongService>(client => client.BaseAddress = uriBuilderSong.Uri); 

// builder.Services.Configure<AppSettings>(appSettings);
builder.Services.AddSingleton<IOptions<AppSettings>>(new OptionsWrapper<AppSettings>(appSettingsSection));
builder.Services.AddSingleton(appSettingsSection);
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();

await builder.Build().RunAsync(); 