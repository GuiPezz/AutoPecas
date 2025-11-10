using AutoPecas.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoPecas.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Categoria>().HasData(
    new Categoria { Id = 1, Nome = "Motor" },
    new Categoria { Id = 2, Nome = "Freios" },
    new Categoria { Id = 3, Nome = "Suspensão" }
);

            modelBuilder.Entity<Produto>().HasData(
                new Produto { Id = 1, Nome = "Filtro de Óleo", Preco = 25.90m, CategoriaId = 1 },
                new Produto { Id = 2, Nome = "Pastilha de Freio", Preco = 120.00m, CategoriaId = 2 },
                new Produto { Id = 3, Nome = "Amortecedor Dianteiro", Preco = 340.00m, CategoriaId = 3 }
            );


            modelBuilder.Entity<Produto>()
                .HasOne(p => p.Categoria)
                .WithMany(c => c.Produtos)
                .HasForeignKey(p => p.CategoriaId);
        }
    }
}
