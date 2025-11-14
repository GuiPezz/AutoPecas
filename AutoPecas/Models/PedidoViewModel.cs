using System.Collections.Generic;

namespace AutoPecas.Models
{
    public class PedidoViewModel
    {
        public string NomeCliente { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public string Pagamento { get; set; } = string.Empty;

        public List<CarrinhoItem> ItensCarrinho { get; set; } = new List<CarrinhoItem>();
        public decimal Total { get; set; }
    }
}
