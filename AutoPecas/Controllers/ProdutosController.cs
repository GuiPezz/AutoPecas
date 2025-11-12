using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AutoPecas.Data;
using AutoPecas.Models;

namespace AutoPecas.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProdutosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Produtos?searchString=...
        public async Task<IActionResult> Index(string? searchString)
        {
            IQueryable<Produto> query = _context.Produtos
                                                .Include(p => p.Categoria)
                                                .AsNoTracking();

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                string term = searchString.Trim();
                query = query.Where(p => p.Nome.Contains(term));
            }

            var lista = await query.ToListAsync();
            return View(lista);
        }

        // GET: Produtos/Create
        public IActionResult Create()
        {
            ViewBag.CategoriaId = new SelectList(_context.Categorias.AsNoTracking().ToList(), "Id", "Nome");
            return View();
        }

        // POST: Produtos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Produto produto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Recarrega o dropdown se houver erro de validação
            ViewBag.CategoriaId = new SelectList(_context.Categorias.AsNoTracking().ToList(), "Id", "Nome", produto.CategoriaId);
            return View(produto);
        }
    }
}
