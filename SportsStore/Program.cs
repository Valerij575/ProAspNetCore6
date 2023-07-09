using SportsStore.Data;
using SportsStore.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationService(builder.Configuration);
builder.Services.AddDependenciesService();

builder.Services.AddControllersWithViews().AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.MaxDepth = Int32.MaxValue;
                }); 

builder.Services.AddRazorPages();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

app.UseStaticFiles();
app.UseSession();

app.MapControllerRoute("catpage", "{category}/Page{productPage:int}", new {Controller = "Home", action = "Index"});
app.MapControllerRoute("page", "Page{productPage:int}", new {Controller = "Home", action = "Index", productPage = 1});
app.MapControllerRoute("category", "{category}", new {Controller = "Home", action ="Index", productPage = 1});
app.MapControllerRoute("pagination", "Products/Page{productPage}", new { Controller = "Home", action = "Index", productPage = 1 });

app.MapDefaultControllerRoute();
app.MapRazorPages();

SeedData.EnsurePopulated(app);

app.Run();
