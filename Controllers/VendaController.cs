using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoVendas.Dto.Venda;
using ProjetoVendas.Modal;
using ProjetoVendas.Services.Vendas;

namespace ProjetoVendas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendaController : ControllerBase
    {
        private readonly IVendasInterface _vendasInterface;

        public VendaController(IVendasInterface vendasInterface)
        {
            _vendasInterface = vendasInterface;
        }

        [HttpPost("CriarVenda")]
        public async Task<ActionResult<VendasModel>> CriarVenda(VendaCriacaoDto vendaCriacaoDto)
        {
            var venda = await _vendasInterface.CriarVenda(vendaCriacaoDto);
            return Ok(venda);
        }

        [HttpGet("TopVendedores")]
        public async Task<ActionResult<ResponseModel<List<TopVendedorDto>>>> TopVendedores()
        {
            var topVendas = await _vendasInterface.TopVendedores();

            return Ok(topVendas); 
        }
    }
}
