using ProjetoVendas.Dto.Cliente;
using ProjetoVendas.Dto.vendedor;
using ProjetoVendas.Modal;

namespace ProjetoVendas.Services.Cliente
{
    public interface IClienteInterface
    {
        Task<ResponseModel<List<CLienteModel>>> CiacaoCliente(ClienteCriacaoDto clienteCriacaoDto);
        Task<ResponseModel<List<CLienteModel>>> EdicaoCliente(ClienteEdicaoDto clienteEdicaoDto);
        Task<ResponseModel<List<CLienteModel>>> ExcluirCliente(int idCliente);
        Task<ResponseModel<CLienteModel>> BuscarClientePorid(int idCliente);
    }
}
