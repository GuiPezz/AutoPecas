using Microsoft.EntityFrameworkCore;
using AutoPecas.Data;

var builder = WebApplication.CreateBuilder(args);

// 🔹 Configurar a conexão com o banco SQL Server (vem do appsettings.json)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

// 🔹 Adicionar suporte a Controllers e Views (MVC)
builder.Services.AddControllersWithViews();

var app = builder.Build();

// 🔹 Configuração do ambiente
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// 🔹 Rota padrão (HomeController e Action Index)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
