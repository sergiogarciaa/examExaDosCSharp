using Microsoft.EntityFrameworkCore;
using sgarera.Models;
using sgarera.Servicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<exaDosContext>(
o =>

o.UseNpgsql(builder.Configuration.GetConnectionString("CadenaConexionPostgreSQL")));
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services.AddScoped<InterfazCrud, ImplementacionCrud>();

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var appDBContext = scope.ServiceProvider.GetRequiredService<exaDosContext>();
    appDBContext.Database.Migrate();
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

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    app.Run();
}
