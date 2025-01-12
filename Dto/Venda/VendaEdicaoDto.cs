

namespace ProjetoVendas.Dto.Venda
{
    public class VendaEdicaoDto
    {
        public int IdVenda { get; set; }
        public DateTime DataVenda { get; set; }
        public decimal ValorVenda { get; set; }
        public int IdVendedor { get; set; }
        public int IdcLiente { get; set; }
    }
}
