using Banco.WebApi.Entity;
using ServiceContracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Banco.WebApi.Core.ServiceContracts
{
    public interface IClienteGetterService
    {
        Task<List<ClienteResponse>> GetAllClientes();
        Task<ClienteResponse?> GetClienteByClienteID(int clienteID);
        


    }
}
