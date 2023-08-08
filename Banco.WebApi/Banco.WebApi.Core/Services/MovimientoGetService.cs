using Banco.WebApi.Core.ServiceContracts;
using Banco.WebApi.Entity;
using RepositoryContracts;
using ServiceContracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Banco.WebApi.Core.Services
{
    public class MovimientoGetService : IMovimientoGetterService
    {
        private readonly IMovimientosRepository _MovimientosRepository;

        public MovimientoGetService(IMovimientosRepository repository)
        {
            _MovimientosRepository = repository;
        }

        public async Task<List<MovimientoResponse>> GetFilteredMovimientos(DateTime fecha, int numeroCuenta)
        {
            Expression<Func<Movimiento, bool>> predicate = m => m.Fecha.Date == fecha.Date && m.NumeroCuenta == numeroCuenta;
            List<Movimiento> movimientos = await _MovimientosRepository.GetFilteredMovimientos(predicate);

            return movimientos.Select(m => m.ToMovimientoResponse()).ToList();
        }
    }
}
