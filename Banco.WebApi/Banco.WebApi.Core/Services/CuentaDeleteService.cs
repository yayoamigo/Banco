using Banco.WebApi.Core.ServiceContracts;
using Banco.WebApi.Entity;
using Microsoft.Extensions.Logging;
using RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.WebApi.Core.Services
{
    public class CuentaDeleteService : ICuentaDeleterService
    {
        private readonly ICuentasRepository _cuentaRepository;
        private readonly ILogger<CuentaAddService> _logger;

        public CuentaDeleteService(ICuentasRepository CuentasRepository, ILogger<CuentaAddService> logger)
        {
            _cuentaRepository = CuentasRepository;
            _logger = logger;
        }
        public async Task<bool> DeleteCuentaByNumeroCuenta(int numeroCuenta)
        {
            if (numeroCuenta == null)
            {
                throw new ArgumentNullException(nameof(numeroCuenta));
            }
            Cuenta? Cuenta = await _cuentaRepository.GetCuentaByNumeroCuenta(numeroCuenta);
            if (Cuenta == null)
                return false;
            await _cuentaRepository.DeleteCuentaByNumeroCuenta(numeroCuenta);
            _logger.LogInformation($"Cuenta numero: {numeroCuenta} deleted");

            return true;
        }
    }
}
