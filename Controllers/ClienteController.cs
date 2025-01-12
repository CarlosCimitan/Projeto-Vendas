using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoVendas.Dto.Cliente;
using ProjetoVendas.Modal;
using ProjetoVendas.Services.Cliente;

namespace ProjetoVendas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteInterface _clienteInterface;

        public ClienteController(IClienteInterface clienteInterface)
        {
            _clienteInterface = clienteInterface;
        }

        [HttpPost("CiacaoCliente")]
        public async Task<ActionResult<CLienteModel>> CiacaoCliente(ClienteCriacaoDto clienteCriacaoDto)
        {
            var cliente = await _clienteInterface.CiacaoCliente(clienteCriacaoDto);
            return Ok(cliente);
        }

        [HttpPut("EdicaoCliente")]
        public async Task<ActionResult<List<CLienteModel>>> EdicaoCliente(ClienteEdicaoDto clienteEdicaoDto)
        {
            var cliente = await _clienteInterface.EdicaoCliente(clienteEdicaoDto);
            return Ok(cliente);
        }

        [HttpDelete("ExcluirCliente")]
        public async Task<ActionResult<List<CLienteModel>>> ExcluirCliente(int idCliente)
        {
            var cliente = await _clienteInterface.ExcluirCliente(idCliente);
            return Ok(cliente);
        }

        [HttpGet("BuscarClientePorid")]
        public async Task<ActionResult<CLienteModel>> BuscarClientePorid(int idCliente)
        {
            var cliente = await _clienteInterface.BuscarClientePorid(idCliente);
            return Ok(cliente);
        }


    }
}
