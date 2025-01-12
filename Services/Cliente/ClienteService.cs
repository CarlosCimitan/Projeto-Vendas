using Microsoft.EntityFrameworkCore;
using ProjetoVendas.Data;
using ProjetoVendas.Dto.Cliente;
using ProjetoVendas.Modal;

namespace ProjetoVendas.Services.Cliente
{
    public class ClienteService : IClienteInterface
    {
        private readonly AppDbContext _context;

        public ClienteService(AppDbContext appDb)
        {
            _context = appDb;
        }

        public async Task<ResponseModel<CLienteModel>> BuscarClientePorid(int idCliente)
        {
            ResponseModel<CLienteModel> resposta = new ResponseModel<CLienteModel>();
            try
            {
                var cliente = await _context.Cliente.FirstOrDefaultAsync(ClienteBanco => ClienteBanco.IdCliente == idCliente);
                
                if (cliente == null)
                {
                    resposta.Mensagem = "Nenhum Cliente Encontrado";
                    return resposta;
                }

                resposta.Dados = cliente;
                resposta.Mensagem = "Cliente Encontrado";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<CLienteModel>>> CiacaoCliente(ClienteCriacaoDto clienteCriacaoDto)
        {
            ResponseModel<List<CLienteModel>> resposta = new ResponseModel<List<CLienteModel>>();

            try
            {
                var cliente = new CLienteModel() 
                {
                    NomeCliente = clienteCriacaoDto.NomeCliente,
                    EmailCliente = clienteCriacaoDto.EmailCliente
                };

                _context.Add(cliente);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Cliente.ToListAsync();
                resposta.Mensagem = "Cliente Cadastrado";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<CLienteModel>>> EdicaoCliente(ClienteEdicaoDto clienteEdicaoDto)
        {
            ResponseModel<List<CLienteModel>> resposta = new ResponseModel<List<CLienteModel>>();
            try
            {
                var cliente = await _context.Cliente
                    .FirstOrDefaultAsync(clientebanco => clientebanco.IdCliente == clienteEdicaoDto.IdCliente);

                if (cliente == null)
                {
                    resposta.Mensagem = "Nenhum Cliente Encontrado";
                    return resposta;
                }

                cliente.NomeCliente = clienteEdicaoDto.NomeCliente;
                cliente.EmailCliente = clienteEdicaoDto.EmailCliente;

                _context.Update(cliente);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Cliente.ToListAsync();
                resposta.Mensagem = "Cliente Alterado";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<CLienteModel>>> ExcluirCliente(int idCliente)
        {
            ResponseModel<List<CLienteModel>> resposta = new ResponseModel<List<CLienteModel>>();
            try
            {
                var cliente = await _context.Cliente.FirstOrDefaultAsync(clienteBanco => clienteBanco.IdCliente == idCliente);

                if (cliente == null)
                {
                    resposta.Mensagem = "Nenhum Cliente Encontrado";
                    return resposta;
                }

                _context.Remove(cliente);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Cliente.ToListAsync();
                resposta.Mensagem = "Cliente removido";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                return resposta;
            }
        }
    }
}
