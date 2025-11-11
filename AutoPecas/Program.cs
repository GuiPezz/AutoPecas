using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using AutoPecas.Data;

var builder = WebApplication.CreateBuilder(args);

// ==========================================
// 🔹 CONFIGURAÇÕES DE SERVIÇOS
// ==========================================

// Adiciona suporte a controladores e views (MVC)
builder.Services.AddControllersWithViews();

// Configura a conexão com o banco de dados SQL Server
// 🔸 Certifique-se de que o appsettings.json tem a ConnectionString "DefaultConnection"
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ==========================================
// 🔹 CONSTRUÇÃO DA APLICAÇÃO
// ==========================================
var app = builder.Build();

// ==========================================
// 🔹 CONFIGURAÇÃO DO PIPELINE DE REQUISIÇÃO
// ==========================================

if (!app.Environment.IsDevelopment())
{
    // Página de erro customizada em produção
    app.UseExceptionHandler("/Home/Error");
    // Segurança adicional (HTTPS estrito)
    app.UseHsts();
}

// Redireciona HTTP → HTTPS
app.UseHttpsRedirection();

// Permite carregar arquivos estáticos (CSS, JS, imagens)
app.UseStaticFiles();

// Habilita o roteamento (para identificar controladores e ações)
app.UseRouting();

// (Opcional) Autorização — caso futuramente tenha login
app.UseAuthorization();

// ==========================================
// 🔹 CONFIGURAÇÃO DE ROTAS
// ==========================================

// Define a rota padrão — o site abre em ProdutosController / Index
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Executa a aplicação
app.Run();
