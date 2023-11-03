using AppCrud.Models;
using AppCrud.Repositorios.Contrato;
using AppCrud.Repositorios.Implementacion;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IGenericRepository<Departamento>,DepartamentoRepository>();
builder.Services.AddScoped<IGenericRepository<Empleado>,EmpleadoRepository>();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(option =>
        {
            option.LoginPath = "/Acceso/Index";
            option.ExpireTimeSpan = TimeSpan.FromMinutes(20);
            option.AccessDeniedPath = "/Home/Privacy";

        });

builder.Services.AddRazorPages();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Acceso}/{action=Index}/{id?}");

app.Run();
