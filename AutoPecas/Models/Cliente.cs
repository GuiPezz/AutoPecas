using System.ComponentModel.DataAnnotations;

namespace AutoPecas.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório")]
        public string Telefone { get; set; }

        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }
}
