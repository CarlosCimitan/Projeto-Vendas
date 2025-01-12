
using ProjetoVendas.Modal;

namespace ProjetoVendas.Dto.Venda
{
    public class VendaCriacaoDto
    {
        public DateTime DataVenda { get; set; }
        public decimal ValorVenda { get; set; }
        public int idVendedor { get; set; }
        public int idcLiente { get; set; }
    }
}
