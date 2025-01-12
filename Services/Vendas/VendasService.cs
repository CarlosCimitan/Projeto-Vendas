using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using ProjetoVendas.Data;
using ProjetoVendas.Dto.Venda;
using ProjetoVendas.Modal;
using ProjetoVendas.Services.Email;

namespace ProjetoVendas.Services.Vendas
{
    public class VendasService : IVendasInterface
    {
        private readonly AppDbContext _context;
        private readonly EmailService _emailService;

        public VendasService(AppDbContext appDbContext, EmailService emailService)
        {
            _context = appDbContext;
            _emailService = emailService;
        }

        public async Task<ResponseModel<List<VendasModel>>> CriarVenda(VendaCriacaoDto vendaCriacaoDto)
        {
            ResponseModel<List<VendasModel>> resposta = new ResponseModel<List<VendasModel>>();
            try
            {
                var vendedor = await _context.Vendedor
                    .FirstOrDefaultAsync(vendedorBanco => vendedorBanco.idVendedor == vendaCriacaoDto.idVendedor );

                if (vendedor == null)
                {
                    resposta.Mensagem = "Nenhum vendedor encontrado";
                    return resposta;
                }


                var cliente = await _context.Cliente
                    .FirstOrDefaultAsync(clienteBanco => clienteBanco.IdCliente == vendaCriacaoDto.idcLiente);

                if(cliente == null)
                {
                    resposta.Mensagem = "Nenhum Cliente encontrado";
                    return resposta;
                }

                var venda = new VendasModel()
                {
                    DataVenda = vendaCriacaoDto.DataVenda,
                    ValorVenda = vendaCriacaoDto.ValorVenda,
                    cLiente = cliente,
                    Vendedor = vendedor
                };

                _context.Add(venda);
                await _context.SaveChangesAsync();

                if (!string.IsNullOrEmpty(cliente.EmailCliente))
                {
                    string assunto = "Confirmação de Compra - Projeto Vendas";
                    string mensagem = $@"
                    <h2>Olá {cliente.NomeCliente},</h2>
                    <p>Sua compra foi realizada com sucesso!</p>
                    <p><strong>Valor:</strong> R$ {venda.ValorVenda:F2}</p>
                    <p><strong>Data:</strong> {venda.DataVenda:dd/MM/yyyy}</p>
                    <p><strong>Vendedor:</strong> {vendedor.NomeVendedor}</p>
                    <p>Obrigado por comprar conosco! 😊</p>";

                    await _emailService.EnviarEmail(cliente.EmailCliente, assunto, mensagem);
                }

                resposta.Dados = await _context.Vendas
                    .Include(v => v.Vendedor)
                    .Include(c => c.cLiente).ToListAsync();

                return resposta;
            }
            catch (Exception ex) 
            {
                resposta.Mensagem = ex.Message;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<TopVendedorDto>>> TopVendedores()
        {
            ResponseModel<List<TopVendedorDto>> resposta = new ResponseModel<List<TopVendedorDto>>();
            try
            {
                var topVendedores = await _context.Vendas
                    .GroupBy(v => v.Vendedor.idVendedor)
                    .Select(g => new
                    {
                        IdVendedor = g.Key,
                        NomeVendedor = g.First().Vendedor.NomeVendedor,
                        MediaVendas = g.Average(v => v.ValorVenda)
                    }).OrderByDescending(v => v.MediaVendas)
                    .Take(3)
                    .ToListAsync();

                resposta.Dados = topVendedores.Select(v => new TopVendedorDto
                {
                    IdVendedor = v.IdVendedor,
                    NomeVendedor = v.NomeVendedor,
                    MediaVendas = v.MediaVendas
                }).ToList();

                resposta.Mensagem = "Top 3 vendedores retornados com sucesso";
                return resposta;
            }
            catch(Exception ex)
            {
                resposta.Mensagem = ex.Message;
                return resposta;
            }
        }
    }
}
