global using Microsoft.AspNetCore.Components.Authorization;
using LittleThings.Client;
using LittleThings.Client.Services.SocialMediaS;
using LittleThings.Client.Services.AuthS;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.LocalStorage;
using BlazorEcommerce.Client;
using LittleThings.Client.Services.SubCategoryS;
using LittleThings.Client.Services.CategoryS;
using LittleThings.Client.Services.ProductS;
using LittleThings.Client.Services.CartS;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<ISocialMediaService, SocialMediaService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ISubCategoryService, SubCategoryService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICartService, CartService>();

builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();

await builder.Build().RunAsync();
