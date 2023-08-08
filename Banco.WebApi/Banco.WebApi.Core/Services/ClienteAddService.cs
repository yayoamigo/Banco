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
                _logger.LogError("Request is null");
                throw new ArgumentNullException(nameof(request));
               
            }

            
            if (request.Identificacion == 0)
            {
                _logger.LogError("Identificacion is null");
                throw new ArgumentException(nameof(request.Identificacion));
            }

            
            if (request.Contrasena == null)
            {
                _logger.LogError("Contrasena is null");
                throw new ArgumentException(nameof(request.Contrasena));
            }

            
            if (await _clientesRepository.GetClienteByClienteID(request.ClienteId) != null)
            {
                _logger.LogError("Given Cliente ID already exists");
                throw new ArgumentException("Given Cliente ID already exists");
            }

            ValidationHelper.ModelValidation(request);


            Cliente cliente = request.ToCliente();

            
            await _clientesRepository.AddCliente(cliente);

            return cliente.ToClienteResponse();
        }


    }
}
