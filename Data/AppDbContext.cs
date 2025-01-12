using Microsoft.EntityFrameworkCore;
using ProjetoVendas.Modal;

namespace ProjetoVendas.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {   
        }

        public DbSet<VendasModel> Vendas { get; set; }
        public DbSet<VendedorModel> Vendedor { get; set; }
        public DbSet<CLienteModel> Cliente { get; set; }
    }
}
