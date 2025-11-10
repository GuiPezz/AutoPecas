namespace AutoPecas.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;

        // Relação 1:N com Produto
        public ICollection<Produto>? Produtos { get; set; }
    }
}
