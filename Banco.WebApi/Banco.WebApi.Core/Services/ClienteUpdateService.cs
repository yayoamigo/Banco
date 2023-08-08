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
    public class ClienteUpdateService : IClienteUpdaterService
    {
        private readonly IClientesRepository _clientesRepository;
        private readonly ILogger<ClienteAddService> _logger;

        public ClienteUpdateService(IClientesRepository clientesRepository, ILogger<ClienteAddService> logger)
        {
            _clientesRepository = clientesRepository;
            _logger = logger;
        }
        public async Task<ClienteResponse> UpdatePersona(ClienteUpdateRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            
            ValidationHelper.ModelValidation(request);

            
            Cliente? matchinCliente = await _clientesRepository.GetClienteByClienteID(request.ClienteId);
            if (matchinCliente == null)
            {
                _logger.LogError("No se encuentra cliente para update");
                throw new ArgumentNullException(nameof(_clientesRepository));
            }

           
            matchinCliente.ClienteId = request.ClienteId;
            matchinCliente.Identificacion = request.Identificacion;
            matchinCliente.Estado = request.Estado;
            matchinCliente.Nombre = request.Nombre;
            matchinCliente.Contrasena = request.Contrasena;
           

            await _clientesRepository.UpdateCliente(matchinCliente);
            _logger.LogInformation("Cliente actualizado");

            return matchinCliente.ToClienteResponse();
        }
    }
    }

