using ServiceContracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.WebApi.Core.ServiceContracts
{
    public interface ICuentaAdderService
    {
        Task<CuentaResponse> AddCCuenta(CuentaAddRequest request);
    }
}
