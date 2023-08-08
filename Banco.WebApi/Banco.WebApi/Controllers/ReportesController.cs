using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ServiceContracts.DTO;
using Banco.WebApi.Core.ServiceContracts;
using Banco.WebApi.Core.Services;

namespace Banco.WebApi.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportesController : ControllerBase
    {
        private readonly IMovimientoAdderService _movimientoAddService;
        private readonly IMovimientoGetterService _movimientoGetService;

        public ReportesController(IMovimientoAdderService movimientoAddService, IMovimientoGetterService movimientoGetService)
        {
            _movimientoAddService = movimientoAddService ?? throw new ArgumentNullException(nameof(movimientoAddService));
            _movimientoGetService = movimientoGetService ?? throw new ArgumentNullException(nameof(movimientoGetService));
        }
        [HttpGet]
        public async Task<IActionResult> GetFilteredMovimientos([FromQuery] DateTime fecha, [FromQuery] int numeroCuenta)
        {
            try
            {
                var movimientos = await _movimientoGetService.GetFilteredMovimientos(fecha, numeroCuenta);
                if (movimientos.Count == 0)
                {
                    return NotFound($"No se encontraron movimientos para la fecha {fecha} y el número de cuenta {numeroCuenta}.");
                }
                return Ok(movimientos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
