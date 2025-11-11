using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPecas.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do produto é obrigatório")]
        [Display(Name = "Nome do Produto")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O preço é obrigatório")]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Preço")]
        public decimal Preco { get; set; }

        [Display(Name = "Quantidade em Estoque")]
        [Required(ErrorMessage = "A quantidade em estoque é obrigatória")]
        public int QuantidadeEstoque { get; set; }

        [Display(Name = "Estoque Mínimo")]
        [Required(ErrorMessage = "O estoque mínimo é obrigatório")]
        public int EstoqueMinimo { get; set; }

        [Display(Name = "Categoria")]
        public int CategoriaId { get; set; }

        [ForeignKey("CategoriaId")]
        public Categoria? Categoria { get; set; }
    }
}
