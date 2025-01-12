using ProjetoVendas.Dto.Venda;
using ProjetoVendas.Modal;

namespace ProjetoVendas.Services.Vendas
{
    public interface IVendasInterface
    {
        Task<ResponseModel<List<VendasModel>>> CriarVenda(VendaCriacaoDto vendaCriacaoDto);
        Task<ResponseModel<List<TopVendedorDto>>> TopVendedores();
    }
}
