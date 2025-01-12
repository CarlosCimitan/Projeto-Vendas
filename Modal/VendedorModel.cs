using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjetoVendas.Modal
{
    public class VendedorModel
    {
        [Key]
        public int idVendedor { get; set; }
        public string NomeVendedor { get; set; }

        [JsonIgnore]
        public ICollection<VendasModel> Vendas { get; set; }
    }
}
