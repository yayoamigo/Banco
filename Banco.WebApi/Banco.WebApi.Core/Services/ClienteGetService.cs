using Banco.WebApi.Core.ServiceContracts;
using Banco.WebApi.Entity;
using Microsoft.Extensions.Logging;
using RepositoryContracts;
using ServiceContracts.DTO;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Banco.WebApi.Core.Services
{
    public class ClienteGetService: IClienteGetterService
    {
        private readonly IClientesRepository _clientesRepository;
        private readonly ILogger<ClienteAddService> _logger;

        public ClienteGetService(IClientesRepository clientesRepository, ILogger<ClienteAddService> logger)
        {
            _clientesRepository = clientesRepository;
            _logger = logger;
        }
        public async Task<List<ClienteResponse>> GetAllClientes()
        {
            List<Cliente> clientes = await _clientesRepository.GetAllClientes();
            return clientes
              .Select(cliente => cliente.ToClienteResponse()).ToList();
        }

        public async Task<ClienteResponse?> GetClienteByClienteID(int clienteID)
        {
            if (clienteID == null)
                return null;

            Cliente? Cliente_response_from_list = await _clientesRepository.GetClienteByClienteID(clienteID);

            if (Cliente_response_from_list == null)
                return null;

            return Cliente_response_from_list.ToClienteResponse();
        }

       
    }
}
