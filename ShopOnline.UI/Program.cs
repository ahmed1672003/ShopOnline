using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using ShopOnline.Services.Constants;
using ShopOnline.Services.IServices;
using ShopOnline.Services.Services;
using ShopOnline.UI;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

#region Add Services
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(Urls.baseUrl) });
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICartItemService, CartItemService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IUnitOfServices, UnitOfServices>();
#endregion


await builder.Build().RunAsync();
