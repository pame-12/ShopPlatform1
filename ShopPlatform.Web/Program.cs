using Microsoft.EntityFrameworkCore;
using ShopPlatform.Application.Extensions;
using ShopPlatform.Persistence.Context;
using ShopPlatform.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// MVC
builder.Services.AddControllersWithViews();

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registrar servicios de Application (Category, Customer, etc.)
builder.Services.AddApplicationServices();

// DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
                     ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))));

// Servicio para consumir API si lo necesitas
builder.Services.AddSingleton<ApiService>();

var app = builder.Build();

// Pipeline
if (app.Environment.IsDevelopment())
{
    // Use Swagger en el entorno de desarrollo
    app.UseSwagger();
    app.UseSwaggerUI();

    // Esta es la configuración por defecto de las plantillas de .NET,
    // es mejor que tu código se parezca a las plantillas por defecto.
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Ruta por defecto
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Category}/{action=Index}/{id?}");

app.Run();
