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
    public class PersonaGetService : IPersonaGetterService
    {
        private readonly IPersonasRepository _PersonasRepository;
        private readonly ILogger<PersonaAddService> _logger;

        public PersonaGetService(IPersonasRepository PersonasRepository, ILogger<PersonaAddService> logger)
        {
            _PersonasRepository = PersonasRepository;
            _logger = logger;
        }
        public async Task<List<PersonaResponse>> GetAllPersonas()
        {
            List<Persona> Personas = await _PersonasRepository.GetAllPersonas();
            return Personas
              .Select(Persona => Persona.ToPersonaResponse()).ToList();
        }

        public async Task<PersonaResponse?> GetPersonaByIdentificacion(int identificacion)
        {
            if (identificacion == null)
                return null;

            Persona? Persona_response_from_list = await _PersonasRepository.GetPersonaByIdentificacion(identificacion);

            if (Persona_response_from_list == null)
                return null;

            return Persona_response_from_list.ToPersonaResponse();
        }

    }
}
