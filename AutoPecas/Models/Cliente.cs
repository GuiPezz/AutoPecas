using System.ComponentModel.DataAnnotations;

namespace AutoPecas.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Cpf { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Telefone { get; set; }

        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }
}
