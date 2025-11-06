using Microsoft.AspNetCore.Mvc;
using AutoPecas.Data;
using AutoPecas.Models;

namespace AutoPecas.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoriasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Categorias
        public IActionResult Index()
        {
            var categorias = _context.Categorias.ToList();
            return View(categorias);
        }

        // GET: Categorias/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categorias/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _context.Categorias.Add(categoria);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }
    }
}
