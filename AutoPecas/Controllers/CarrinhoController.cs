using AutoPecas.Data;
using AutoPecas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoPecas.Controllers
{
    public class CarrinhoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarrinhoController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var itens = await _context.CarrinhoItens.Include(c => c.Produto).ToListAsync();
            AtualizarQuantidadeNaSessao(itens.Count);
            return View(itens);
        }

        public async Task<IActionResult> Adicionar(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
                return NotFound();

            var item = new CarrinhoItem
            {
                ProdutoId = produto.Id,
                Quantidade = 1,
                PrecoUnitario = produto.Preco
            };

            _context.CarrinhoItens.Add(item);
            await _context.SaveChangesAsync();

            // ✅ Atualiza contador na sessão
            var total = _context.CarrinhoItens.Count();
            HttpContext.Session.SetInt32("CarrinhoCount", total);

            return RedirectToAction("Index", "Carrinho");
        }

        public async Task<IActionResult> Remover(int id)
        {
            var item = await _context.CarrinhoItens.FindAsync(id);
            if (item != null)
            {
                _context.CarrinhoItens.Remove(item);
                await _context.SaveChangesAsync();
            }

            // ✅ Atualiza contador
            var total = _context.CarrinhoItens.Count();
            HttpContext.Session.SetInt32("CarrinhoCount", total);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Finalizar()
        {
            var itens = await _context.CarrinhoItens.ToListAsync();
            _context.CarrinhoItens.RemoveRange(itens);
            await _context.SaveChangesAsync();

            // ✅ Zera contador
            HttpContext.Session.SetInt32("CarrinhoCount", 0);

            ViewBag.Mensagem = "Compra finalizada com sucesso!";
            return View("Confirmacao");
        }

        private void AtualizarQuantidadeNaSessao(int quantidade)
        {
            HttpContext.Session.SetInt32("CarrinhoCount", quantidade);
        }
    }
}
