using Banco.WebApi.Entity;
using System.Linq.Expressions;

namespace RepositoryContracts
{
    public interface IClientesRepository
    {
        Task<Cliente> AddCliente(Cliente cliente);
        Task<List<Cliente>> GetAllClientes();
        Task<Cliente?> GetClienteByClienteID(int clienteID);
        Task<List<Cliente>> GetFilteredClientes(Expression<Func<Cliente, bool>> predicate);
        Task<bool> DeleteClienteByClienteID(int clienteID);
        Task<Cliente> UpdateCliente(Cliente cliente);
    }
}
