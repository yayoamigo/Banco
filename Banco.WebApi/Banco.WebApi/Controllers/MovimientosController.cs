using Banco.WebApi.Core.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts.DTO;

namespace Banco.WebApi.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientosController : ControllerBase
    {
        private readonly IMovimientoAdderService _movimientoAddService;
        private readonly IMovimientoGetterService _movimientoGetService;

        public MovimientosController(IMovimientoAdderService movimientoAddService, IMovimientoGetterService movimientoGetService)
        {
            _movimientoAddService = movimientoAddService ?? throw new ArgumentNullException(nameof(movimientoAddService));
            _movimientoGetService = movimientoGetService ?? throw new ArgumentNullException(nameof(movimientoGetService));
        }

        [HttpPost]
        public async Task<IActionResult> AddMovimiento([FromBody] MovimientoAddRequest request)
        {
            try
            {
                var movimientoResponse = await _movimientoAddService.AddMovimiento(request);
                return CreatedAtAction(nameof(AddMovimiento), movimientoResponse);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
