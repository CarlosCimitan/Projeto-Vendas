using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjetoVendas.Modal
{
    public class CLienteModel
    {
        [Key]
        public int IdCliente { get; set; }
        public string NomeCliente { get; set; }
        public string EmailCliente { get; set; }

        [JsonIgnore]
        public ICollection<VendasModel> Compras { get; set; }
    }
}
