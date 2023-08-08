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
    public class ClienteAddService : IClienteAdderService
    {
        private readonly IClientesRepository _clientesRepository;
        private readonly ILogger<ClienteAddService> _logger;

        public ClienteAddService(IClientesRepository clientesRepository, ILogger<ClienteAddService> logger)
        {
            _clientesRepository = clientesRepository;
            _logger = logger;
        }

        public async Task<ClienteResponse> AddCliente(ClienteAddRequest request)
        {
            
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            
            if (request.Identificacion == 0)
            {
                throw new ArgumentException(nameof(request.Identificacion));
            }

            
            if (request.Contrasena == null)
            {
                throw new ArgumentException(nameof(request.Contrasena));
            }

            // Validation: ClienteId can't be duplicate
            if (await _clientesRepository.GetClienteByClienteID(request.ClienteId) != null)
            {
                throw new ArgumentException("Given Cliente ID already exists");
            }

            
            Cliente cliente = request.ToCliente();

            // Add cliente object into _clientesRepository
            var addedCliente = await _clientesRepository.AddCliente(cliente);

            return addedCliente.ToClienteResponse();
        }


    }
}
