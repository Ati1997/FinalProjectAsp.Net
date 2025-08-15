using Microsoft.EntityFrameworkCore;
using MultiPageApplication.ApplicationServices.Services;
using MultiPageApplication.ApplicationServices.Services.Contracts;
using MultiPageApplication.Models;
using MultiPageApplication.Models.Services.Contracts;
using MultiPageApplication.Models.Services.Repositories;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MultiPageDbContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("MultiPageConnection")
        ));

//Add Scoped
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductApplicationService, ProductApplicationService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
