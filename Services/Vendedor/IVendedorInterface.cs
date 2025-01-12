using ProjetoVendas.Dto.vendedor;
using ProjetoVendas.Modal;

namespace ProjetoVendas.Services.Vendedor
{
    public interface IVendedorInterface
    {
        Task<ResponseModel<List<VendedorModel>>> CiacaoVendedor(VendedorCriacaoDto vendedorCriacaoDto);
        Task<ResponseModel<List<VendedorModel>>> EdicaoVendedor(VendedorEdicaoDto vendedorEdicaoDto);
        Task<ResponseModel<List<VendedorModel>>> ExcluirVendedor(int idVendedor);
        Task<ResponseModel<VendedorModel>> BuscarVendedorPorid(int idVendedor);
    }
}
