using Microsoft.EntityFrameworkCore;
using ProjetoVendas.Data;
using ProjetoVendas.Dto.vendedor;
using ProjetoVendas.Modal;

namespace ProjetoVendas.Services.Vendedor
{
    public class VendedorService : IVendedorInterface
    {
        private readonly AppDbContext _context;

        public VendedorService(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public async Task<ResponseModel<VendedorModel>> BuscarVendedorPorid(int idVendedor)
        {
            ResponseModel<VendedorModel> resposta = new ResponseModel<VendedorModel>();

            try
            {
                var vendedor = await _context.Vendedor.FirstOrDefaultAsync(vendedor => vendedor.idVendedor == idVendedor);

                if (vendedor == null) 
                {
                    resposta.Mensagem = "Nenhum vendedor Encontrado";
                    return resposta;
                }

                resposta.Dados = vendedor;
                resposta.Mensagem = "Vendedor Encontrado";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = "Falha ao Buscar o Vendedor";
                return resposta;
            }

        }

        public async Task<ResponseModel<List<VendedorModel>>> CiacaoVendedor(VendedorCriacaoDto vendedorCriacaoDto)
        {
            ResponseModel<List<VendedorModel>> resposta = new ResponseModel<List<VendedorModel>>();

            try
            {
                var vendedor = new VendedorModel()
                {
                    NomeVendedor = vendedorCriacaoDto.NomeVendedor
                };

                _context.Add(vendedor);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Vendedor.ToListAsync();
                resposta.Mensagem = "Vendedor Cadastrado";
                
                return resposta;
            }
            catch (Exception ex) 
            {
                resposta.Mensagem = "Falha ao Cadastrar o Vendedor";
                return resposta;
            }
        }

        public async Task<ResponseModel<List<VendedorModel>>> EdicaoVendedor(VendedorEdicaoDto vendedorEdicaoDto)
        {
            ResponseModel<List<VendedorModel>> resposta = new ResponseModel<List<VendedorModel>>();

            try
            {
                var vendedor = await _context.Vendedor
                    .FirstOrDefaultAsync(vendedorBanco => vendedorBanco.idVendedor == vendedorEdicaoDto.idVendedor);

                if (vendedor == null)
                {
                    resposta.Mensagem = "Nenhum Vendedro Encontrado";
                    return resposta;
                }

                vendedor.NomeVendedor = vendedorEdicaoDto.NomeVendedor;

                _context.Update(vendedor);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Vendedor.ToListAsync();
                resposta.Mensagem = "Vendedor Alterado";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = "Falha ao Alterar o Vendedor";
                return resposta;
            }
        }

        public async Task<ResponseModel<List<VendedorModel>>> ExcluirVendedor(int idVendedor)
        {
            ResponseModel<List<VendedorModel>> resposta = new ResponseModel<List<VendedorModel>>();

            try
            {
                var vendedor = await _context.Vendedor.FirstOrDefaultAsync(vendedor => vendedor.idVendedor==idVendedor);

                if (vendedor == null)
                {
                    resposta.Mensagem = "Nenhum Vendedor Encontrado";
                    return resposta;
                }

                _context.Remove(vendedor);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Vendedor.ToListAsync();
                resposta.Mensagem = "Vendedor Excluido0";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = "Falha ao Excluir o Vendedor";
                return resposta;
            }
        }
    }
}

