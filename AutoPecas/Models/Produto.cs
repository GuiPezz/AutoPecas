namespace AutoPecas.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public decimal Preco { get; set; }

        // Chave estrangeira
        public int CategoriaId { get; set; }

        // Navegação
        public Categoria? Categoria { get; set; }
    }
}
