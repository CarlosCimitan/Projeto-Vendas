using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoVendas.Modal
{
    public class VendasModel
    {
        [Key]
        public int IdVenda { get; set; }
        public DateTime DataVenda { get; set; }
        public decimal ValorVenda { get; set; }
        public VendedorModel Vendedor { get; set; }
        public CLienteModel cLiente { get; set; }
    }
}
