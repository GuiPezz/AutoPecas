using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AutoPecas.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome da categoria é obrigatório")]
        [Display(Name = "Nome da Categoria")]
        public string Nome { get; set; } = string.Empty;

        // Relacionamento: uma categoria pode ter vários produtos
        public ICollection<Produto> Produtos { get; set; } = new List<Produto>();
    }
}
