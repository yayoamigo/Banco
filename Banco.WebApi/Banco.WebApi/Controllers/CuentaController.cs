
    using Microsoft.AspNetCore.Mvc;
    using Banco.WebApi.Core.Services;
    using Banco.WebApi.Core.ServiceContracts;
    using ServiceContracts.DTO;
    using System;
    using System.Threading.Tasks;
    

    namespace Banco.WebApi.UI.Controllers
    {
        [ApiController]
        [Route("api/[controller]")]
        public class CuentasController : ControllerBase
        {
            private readonly ICuentaAdderService _cuentaAddService;
            private readonly ICuentaDeleterService _cuentaDeleteService;
            private readonly ICuentaGetterService _cuentaGetService;

            public CuentasController(ICuentaAdderService cuentaAddService, ICuentaDeleterService cuentaDeleteService, ICuentaGetterService cuentaGetService)
            {
                _cuentaAddService = cuentaAddService ?? throw new ArgumentNullException(nameof(cuentaAddService));
                _cuentaDeleteService = cuentaDeleteService ?? throw new ArgumentNullException(nameof(cuentaDeleteService));
                _cuentaGetService = cuentaGetService ?? throw new ArgumentNullException(nameof(cuentaGetService));
            }

            [HttpPost]
            public async Task<IActionResult> AddCuenta([FromBody] CuentaAddRequest request)
            {
                try
                {
                    var cuentaResponse = await _cuentaAddService.AddCCuenta(request);
                    return CreatedAtAction(nameof(AddCuenta), cuentaResponse);
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

            [HttpDelete("{numeroCuenta}")]
            public async Task<IActionResult> DeleteCuenta(int numeroCuenta)
            {
                try
                {
                    var result = await _cuentaDeleteService.DeleteCuentaByNumeroCuenta(numeroCuenta);
                    if (result)
                        return Ok($"Cuenta con número {numeroCuenta} eliminada.");
                    else
                        return NotFound($"Cuenta con número {numeroCuenta} no encontrada.");
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }

            [HttpGet]
            public async Task<IActionResult> GetAllCuentas()
            {
                var cuentas = await _cuentaGetService.GetAllCuentas();
                return Ok(cuentas);
            }

            [HttpGet("{numeroCuenta}")]
            public async Task<IActionResult> GetCuentaByNumeroCuenta(int numeroCuenta)
            {
                var cuenta = await _cuentaGetService.GetCuentaByNumeroCuenta(numeroCuenta);
                if (cuenta == null) return NotFound();
                return Ok(cuenta);
            }
        }
    }

