using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoPecas.Data;
using AutoPecas.Models;

namespace AutoPecas.Controllers
{
    public class PedidosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PedidosController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Checkout()
        {
            var itens = await _context.CarrinhoItens
                .Include(c => c.Produto)
                .ToListAsync();

            var total = itens.Sum(i => i.Subtotal);

            var vm = new PedidoViewModel
            {
                ItensCarrinho = itens,
                Total = total
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> FinalizarPedido(PedidoViewModel vm)
        {
            var pedido = new Pedido
            {
                FormaPagamento = vm.Pagamento,
                ValorTotal = vm.Total,
                Status = "Aguardando Pagamento",
                DataPedido = DateTime.Now
            };

            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();

            var itens = await _context.CarrinhoItens.ToListAsync();
            _context.CarrinhoItens.RemoveRange(itens);
            await _context.SaveChangesAsync();

            HttpContext.Session.SetInt32("CarrinhoCount", 0);

            return RedirectToAction("Confirmacao");
        }

        public IActionResult Confirmacao()
        {
            return View();
        }
    }
}
