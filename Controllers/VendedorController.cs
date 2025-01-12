using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoVendas.Dto.Venda;
using ProjetoVendas.Dto.vendedor;
using ProjetoVendas.Modal;
using ProjetoVendas.Services.Vendedor;

namespace ProjetoVendas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendedorController : ControllerBase
    {
        private readonly IVendedorInterface _vendedorInterface;

        public VendedorController(IVendedorInterface vendedorInterface)
        {
            _vendedorInterface = vendedorInterface;
        }

        [HttpPost("CiacaoVendedor")]
        public async Task<ActionResult<VendedorModel>> CiacaoVendedor(VendedorCriacaoDto vendedorCriacaoDto)
        {
            var vendedor = await _vendedorInterface.CiacaoVendedor(vendedorCriacaoDto);
            return Ok(vendedor);
        }

        [HttpPut("EdicaoVendedor")]
        public async Task<ActionResult<List<VendedorModel>>> EdicaoVendedor(VendedorEdicaoDto vendedorEdicaoDto)
        {
            var vendedor = await _vendedorInterface.EdicaoVendedor(vendedorEdicaoDto);
            return Ok(vendedor);
        }

        [HttpDelete("ExcluirVendedor")]
        public async Task<ActionResult<List<VendedorModel>>> ExcluirVendedor(int idVendedor)
        {
            var vendedor = await _vendedorInterface.ExcluirVendedor(idVendedor);
            return Ok(vendedor);
        }

        [HttpGet("BuscarVendedorPorid/{idVendedor}")]
        public async Task<ActionResult<VendedorModel>> BuscarVendedorPorid(int idVendedor)
        {
            var vendedor = await _vendedorInterface.BuscarVendedorPorid(idVendedor);
            return Ok(vendedor);
        }
    }
}
