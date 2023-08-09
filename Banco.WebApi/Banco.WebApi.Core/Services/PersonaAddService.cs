using Banco.WebApi.Core.Helpers;
using Banco.WebApi.Core.ServiceContracts;
using Banco.WebApi.Entity;
using Microsoft.Extensions.Logging;
using RepositoryContracts;
using ServiceContracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.WebApi.Core.Services
{
    public class PersonaAddService : IPersonaAdderService
    {
        private readonly IPersonasRepository _PersonaRepository;
        private readonly ILogger<PersonaAddService> _logger;

        public PersonaAddService(IPersonasRepository PersonasRepository, ILogger<PersonaAddService> logger)
        {
            _PersonaRepository = PersonasRepository;
            _logger = logger;
        }

        public async Task<PersonaResponse> AddPersona(PersonaAddRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            if (await _PersonaRepository.GetPersonaByIdentificacion(request.Identificacion) != null)
            {
                _logger.LogError($"Una persona con la identificaion {request.Identificacion} ya existe");
                throw new ArgumentException("Persona ya existe");
            }

            ValidationHelper.ModelValidation(request);

            Persona Persona = request.ToPersona();


            await _PersonaRepository.AddPersona(Persona);

            return Persona.ToPersonaResponse();

        }
    }
}
