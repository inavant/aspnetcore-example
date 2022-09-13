using System.Globalization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Empresa.Proyecto.Core.Interfaces;
using Empresa.Proyecto.Core.Entities;
using Empresa.Proyecto.Infra.Data;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MyProjectContext>(db =>
    db.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection"))
    );

builder.Services.AddScoped<IAsyncRepository<SimpleEntity>, EFRepository<SimpleEntity>>();
builder.Services.AddScoped<IAsyncRepository<ComplexEntity>, EFRepository<ComplexEntity>>();

//Configuracion de JSON para que no cambie el case al hacer parse, y funcione los controles de Kendo
builder.Services.AddRazorPages()
    .AddJsonOptions(options=>
    options.JsonSerializerOptions.PropertyNamingPolicy = null);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Poruqe no esta configurada la autorizacion :D
//app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

app.Run();
