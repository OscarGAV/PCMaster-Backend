using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.Authorization;
using PCMasterFrontend;
using PCMasterFrontend.Infrastructure.HttpClient;
using PCMasterFrontend.Infrastructure.Auth;
using PCMasterFrontend.Infrastructure.Constants;
using PCMasterFrontend.Services;
using PCMasterFrontend.Services.Interfaces;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new System.Net.Http.HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddHttpClient<IApiClient, ApiClient>(client =>
{
    client.BaseAddress = new Uri(ApiRoutes.BaseUrl);
});

builder.Services.AddScoped<CustomAuthStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(sp => sp.GetRequiredService<CustomAuthStateProvider>());
builder.Services.AddAuthorizationCore();

builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IComponentService, ComponentService>();
builder.Services.AddScoped<ITechnicianService, TechnicianService>();
builder.Services.AddScoped<ITechnicalSupportService, TechnicalSupportService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IWishlistService, WishlistService>();
builder.Services.AddScoped<IComponentReviewService, ComponentReviewService>();
builder.Services.AddScoped<ITechnicalSupportReviewService, TechnicalSupportReviewService>();
builder.Services.AddScoped<TokenStorage>();

await builder.Build().RunAsync();
