using Banco.WebApi.Core.ServiceContracts;
using Microsoft.Extensions.Logging;
using RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banco.WebApi.Entity;


namespace Banco.WebApi.Core.Services
{
    public class PersonaDeleteService : IPersonaDeleterService
    {
        private readonly IPersonasRepository _PersonaRepository;
        private readonly ILogger<PersonaAddService> _logger;

        public PersonaDeleteService(IPersonasRepository PersonasRepository, ILogger<PersonaAddService> logger)
        {
            _PersonaRepository = PersonasRepository;
            _logger = logger;
        }
        public async Task<bool> DeletePersonaByIdentificacion(int identificacion)
        {
            if (identificacion == null)
            {
                throw new ArgumentNullException(nameof(identificacion));
            }
            Persona? persona = await _PersonaRepository.GetPersonaByIdentificacion(identificacion);
            if (persona == null)
                return false;
            await _PersonaRepository.DeletePersonaByIdentificacion(identificacion);
            _logger.LogInformation($"Persona numero: {identificacion} eliminada");

            return true;
        }
    }
}
