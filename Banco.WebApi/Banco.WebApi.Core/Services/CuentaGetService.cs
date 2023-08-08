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
    
        public class CuentaGetService : ICuentaGetterService
        {
            private readonly ICuentasRepository _CuentasRepository;
            private readonly ILogger<CuentaAddService> _logger;

            public CuentaGetService(ICuentasRepository CuentasRepository, ILogger<CuentaAddService> logger)
            {
                _CuentasRepository = CuentasRepository;
                _logger = logger;
            }
            public async Task<List<CuentaResponse>> GetAllCuentas()
            {
                List<Cuenta> Cuentas = await _CuentasRepository.GetAllCuentas();
                return Cuentas
                  .Select(Cuenta => Cuenta.ToCuentaResponse()).ToList();
            }

            public async Task<CuentaResponse?> GetCuentaByNumeroCuenta(int numeroCuenta)
            {
                if (numeroCuenta == null)
                    return null;

                Cuenta? Cuenta_response_from_list = await _CuentasRepository.GetCuentaByNumeroCuenta(numeroCuenta);

                if (Cuenta_response_from_list == null)
                    return null;

                return Cuenta_response_from_list.ToCuentaResponse();
            }

        }
    }
