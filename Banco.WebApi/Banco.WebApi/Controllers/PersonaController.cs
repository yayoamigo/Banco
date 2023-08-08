using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ServiceContracts.DTO;
using Banco.WebApi.Core.ServiceContracts;
using Banco.WebApi.Core.Services;

namespace Banco.WebApi.UI.Controllers
{
    
    
        [ApiController]
        [Route("api/[controller]")]
        public class PersonasController : ControllerBase
        {
            private readonly IPersonaAdderService _personaAddService;
            private readonly IPersonaDeleterService _personaDeleteService;
            private readonly IPersonaGetterService _personaGetService;

            public PersonasController(IPersonaAdderService personaAddService, IPersonaDeleterService personaDeleteService, IPersonaGetterService personaGetService)
            {
                _personaAddService = personaAddService ?? throw new ArgumentNullException(nameof(personaAddService));
                _personaDeleteService = personaDeleteService ?? throw new ArgumentNullException(nameof(personaDeleteService));
                _personaGetService = personaGetService ?? throw new ArgumentNullException(nameof(personaGetService));
            }

            [HttpPost]
            public async Task<IActionResult> AddPersona([FromBody] PersonaAddRequest request)
            {
                try
                {
                    var personaResponse = await _personaAddService.AddPersona(request);
                    return CreatedAtAction(nameof(AddPersona), personaResponse);
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

            [HttpDelete("{identificacion}")]
            public async Task<IActionResult> DeletePersona(int identificacion)
            {
                try
                {
                    var result = await _personaDeleteService.DeletePersonaByIdentificacion(identificacion);
                    if (result)
                        return Ok($"Persona con identificación {identificacion} eliminada.");
                    else
                        return NotFound($"Persona con identificación {identificacion} no encontrada.");
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }

            [HttpGet]
            public async Task<IActionResult> GetAllPersonas()
            {
                var personas = await _personaGetService.GetAllPersonas();
                return Ok(personas);
            }

            [HttpGet("{identificacion}")]
            public async Task<IActionResult> GetPersonaByIdentificacion(int identificacion)
            {
                var persona = await _personaGetService.GetPersonaByIdentificacion(identificacion);
                if (persona == null) return NotFound();
                return Ok(persona);
            }
        }
    }

