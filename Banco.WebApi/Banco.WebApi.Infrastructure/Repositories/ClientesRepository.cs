using Banco.WebApi.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Banco.WebApi.Infrastructure.Repositories
{
    public class ClientesRepository : IClientesRepository
    {
        private readonly BancoDbContext _context;
        private readonly ILogger<ClientesRepository> _logger;

        public ClientesRepository(BancoDbContext context, ILogger<ClientesRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Cliente> AddCliente(Cliente cliente)
        {
            _logger.LogInformation("Agregando un nuevo cliente");
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<bool> DeleteClienteByClienteID(int clienteID)
        {
            _logger.LogInformation($"Eliminando cliente con ID: {clienteID}");
            var cliente = await _context.Clientes.FindAsync(clienteID);
            if (cliente == null)
            {
                return false;
            }

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Cliente>> GetAllClientes()
        {
            _logger.LogInformation("Obteniendo todos los clientes");
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Cliente?> GetClienteByClienteID(int clienteID)
        {
            _logger.LogInformation($"Obteniendo cliente con ID: {clienteID}");
            return await _context.Clientes.FindAsync(clienteID);
        }

        public async Task<Cliente> UpdateCliente(Cliente cliente)
        {
            _logger.LogInformation($"Actualizando cliente con ID: {cliente.ClienteId}");
            Cliente? matchingCliente = await _context.Clientes.FirstOrDefaultAsync(temp => temp.ClienteId == cliente.ClienteId);

            if (matchingCliente == null)
                return cliente;

            matchingCliente.Nombre = cliente.Nombre;
            matchingCliente.Contrasena = cliente.Contrasena;

            int countUpdated = await _context.SaveChangesAsync();

            return matchingCliente;
        }
    }
}
