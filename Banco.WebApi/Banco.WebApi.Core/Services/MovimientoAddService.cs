using Banco.WebApi.Core.Helpers;
using Banco.WebApi.Core.ServiceContracts;
using Banco.WebApi.Entity;
using Microsoft.VisualBasic;
using RepositoryContracts;
using ServiceContracts.DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.WebApi.Core.Services
{
    public class MovimientoAddService : IMovimientoAdderService
    {
        private readonly IMovimientosRepository _MovimientosRepository;
        private readonly ICuentasRepository _CuentasRepository;

        public MovimientoAddService(IMovimientosRepository movimientosRepository, ICuentasRepository cuentasRepository)
        {
            _MovimientosRepository = movimientosRepository;
            _CuentasRepository = cuentasRepository;
        }

        public async Task<MovimientoResponse> AddMovimiento(MovimientoAddRequest request)
        {

            if (request == null) throw new ArgumentNullException(nameof(request));

            ValidationHelper.ModelValidation(request);

            var cuenta = await _CuentasRepository.GetCuentaByNumeroCuenta(request.NumeroCuenta);

            if (cuenta == null)
            {
                throw new ArgumentException($"El numero de cuenta: {request.NumeroCuenta} no existe");
            }

            if (request.Valor == 0)
            {
                throw new ArgumentException("El valor no puede ser 0");
            }
            string tipoMovimiento = request.TipoMovimiento;
            decimal valor = request.Valor;
            int numeroCuenta = request.NumeroCuenta;



            bool response = await _MovimientosRepository.RealizarMovimiento(numeroCuenta, valor, tipoMovimiento);

            if (!response)
            {
                throw new InvalidOperationException("El movimiento no se pudo realizar en la base de datos. Por favor, verifica los datos e inténtalo de nuevo.");
            }

            Movimiento? movimiento = request.ToMovimiento();

            return movimiento.ToMovimientoResponse();






        }
    }
}
