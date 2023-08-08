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
    public class MovimientosRepository : IMovimientosRepository
    {
        private readonly BancoDbContext _context;
        private readonly ILogger<MovimientosRepository> _logger;

        public MovimientosRepository(BancoDbContext context, ILogger<MovimientosRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> RealizarMovimiento(int numeroCuenta, decimal valor, string tipoMovimiento)
        {
            try
            {
               await  _context.RealizarMovimiento(numeroCuenta, valor, tipoMovimiento);
                _logger.LogInformation($"Movimiento realizado con éxito en la cuenta {numeroCuenta}");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al realizar el movimiento en la cuenta {numeroCuenta}");
                return false;
            }
        }



        public async Task<List<Movimiento>> GetFilteredMovimientos(Expression<Func<Movimiento, bool>> predicate)
        {
            _logger.LogInformation("Obteniendo movimientos filtrados");
            return await _context.Movimientos.Include("CuentaNavigation")
            .Where(predicate).ToListAsync();
        }
    }
}
