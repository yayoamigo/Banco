using Banco.WebApi.Core.ServiceContracts;
using ServiceContracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryContracts;
using Microsoft.Extensions.Logging;
using Banco.WebApi.Entity;
using Banco.WebApi.Core.Helpers;

namespace Banco.WebApi.Core.Services
{
    public class CuentaAddService : ICuentaAdderService
    {
        private readonly ICuentasRepository _cuentaRepository;
        private readonly ILogger<CuentaAddService> _logger;

        public CuentaAddService(ICuentasRepository CuentasRepository, ILogger<CuentaAddService> logger)
        {
            _cuentaRepository = CuentasRepository;
            _logger = logger;
        }

        public async Task<CuentaResponse> AddCCuenta(CuentaAddRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            if (await _cuentaRepository.GetCuentaByNumeroCuenta(request.NumeroCuenta) != null)
            {
                _logger.LogError("Este numero de cuenta ya existe");
                throw new ArgumentException("Numero de cuenta ya existe");
            }

            if (string.IsNullOrEmpty(request.Nombre))
            {
                throw new ArgumentException("Nombre no puede estar vacio");
            }

            ValidationHelper.ModelValidation(request);

            Cuenta cuenta = request.ToCuenta();


            await _cuentaRepository.AddCuenta(cuenta);

            return cuenta.ToCuentaResponse();

        }
    }
}
