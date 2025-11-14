using System;
using System.ComponentModel.DataAnnotations;

namespace AutoPecas.Models
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }

        public DateTime DataPedido { get; set; } = DateTime.Now;

        [Required]
        [Display(Name = "Forma de Pagamento")]
        public string FormaPagamento { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Status do Pedido")]
        public string Status { get; set; } = "Aguardando Pagamento";

        [Display(Name = "Valor Total")]
        public decimal ValorTotal { get; set; }
    }
}
