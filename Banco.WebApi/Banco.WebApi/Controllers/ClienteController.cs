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
        private readonly IClienteUpdaterService _clienteUpdaterService;

        // Constructor del controlador, inyección de dependencias para servicios
        public ClientesController(IClienteAdderService clienteAddService, IClienteGetterService clienteGetterService, IClienteUpdaterService clienteUpdaterService)
        {
            _clienteAddService = clienteAddService ?? throw new ArgumentNullException(nameof(clienteAddService));
            _clienteGetService = clienteGetterService ?? throw new ArgumentNullException(nameof(clienteGetterService));
            _clienteUpdaterService = clienteUpdaterService ?? throw new ArgumentNullException(nameof(clienteUpdaterService));
        }
        // Accion para agregar un cliente
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
        //Accion para obtener todos los clientes
        [HttpGet]
        public async Task<IActionResult> GetAllClientes()
        {
            var clientes = await _clienteGetService.GetAllClientes();
            return Ok(clientes);
        }
        // Accion para obtener clientes por ID

        [HttpGet("{clienteID}")]
        public async Task<IActionResult> GetClienteByClienteID(int clienteID)
        {
            var cliente = await _clienteGetService.GetClienteByClienteID(clienteID);
            if (cliente == null) return NotFound();
            return Ok(cliente);
        }

        // Acción para actualizar un cliente
        [HttpPut("{clienteID}")]
        public async Task<IActionResult> UpdateCliente(int clienteID, [FromBody] ClienteUpdateRequest request)
        {
            try
            {
                if (clienteID != request.ClienteId)
                    return BadRequest("El ID del cliente en la URL debe coincidir con el ID en el cuerpo de la solicitud.");

                var clienteResponse = await _clienteUpdaterService.UpdatePersona(request);
                return Ok(clienteResponse);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
