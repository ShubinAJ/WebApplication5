using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using WebApplication5.Models;


var builder = WebApplication.CreateBuilder(args);

// получаем строку подключения из файла конфигурации
string connection = builder.Configuration.GetConnectionString("DefaultConnection");

// добавляем контекст ApplicationContext в качестве сервиса в приложение
//builder.Services.AddScoped<ProductContext>(_ => new ProductContext(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<ProductContext>(options => options.UseSqlServer(connection));




builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowTestSite", builder => builder
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod());

});

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddControllers();

//builder.Services.AddDbContext<ProductContext>();

var app = builder.Build();

//using CORS
app.UseCors("AllowTestSite");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapDefaultControllerRoute();

app.Run();
