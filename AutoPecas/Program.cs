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
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ==========================================
// 🔹 CONFIGURAÇÕES DE SESSÃO (para carrinho)
// ==========================================
builder.Services.AddDistributedMemoryCache(); // Armazena sessão na memória
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(1); // Sessão expira em 1h
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// ==========================================
// 🔹 CONSTRUÇÃO DA APLICAÇÃO
// ==========================================
var app = builder.Build();

// ==========================================
// 🔹 CONFIGURAÇÃO DO PIPELINE DE REQUISIÇÃO
// ==========================================

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Redireciona HTTP → HTTPS
app.UseHttpsRedirection();

// Permite carregar arquivos estáticos (CSS, JS, imagens)
app.UseStaticFiles();

// Habilita o roteamento
app.UseRouting();

// ✅ Habilita sessão (necessário antes da autorização)
app.UseSession();

// (Opcional) Autorização
app.UseAuthorization();

// ==========================================
// 🔹 CONFIGURAÇÃO DE ROTAS
// ==========================================

// Define a rota padrão — abre a página inicial
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Executa a aplicação
app.Run();
