using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts.DTO;
using Banco.WebApi.Core.ServiceContracts;
using Banco.WebApi.Core.Services;

namespace Banco.WebApi.UI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteAdderService _clienteAddService;
        private readonly IClienteGetterService _clienteGetService;

        public ClientesController(IClienteAdderService clienteAddService, IClienteGetterService clienteGetterService)
        {
            _clienteAddService = clienteAddService ?? throw new ArgumentNullException(nameof(clienteAddService));
            _clienteGetService = clienteGetterService ?? throw new ArgumentNullException(nameof(clienteGetterService));
        }

        [HttpPost]
        public async Task<IActionResult> AddCliente([FromBody] ClienteAddRequest request)
        {
            try
            {
                var clienteResponse = await _clienteAddService.AddCliente(request);
                return CreatedAtAction(nameof(AddCliente), clienteResponse);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClientes()
        {
            var clientes = await _clienteGetService.GetAllClientes();
            return Ok(clientes);
        }

        [HttpGet("{clienteID}")]
        public async Task<IActionResult> GetClienteByClienteID(int clienteID)
        {
            var cliente = await _clienteGetService.GetClienteByClienteID(clienteID);
            if (cliente == null) return NotFound();
            return Ok(cliente);
        }
    }
}
