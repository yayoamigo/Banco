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
    internal class MovimientosRepository : IMovimientosRepository
    {
        private readonly BancoDbContext _context;
        private readonly ILogger<MovimientosRepository> _logger;

        public MovimientosRepository(BancoDbContext context, ILogger<MovimientosRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Movimiento> AddMovimiento(Movimiento movimiento)
        {
            _logger.LogInformation("Agregando un nuevo movimiento");
            _context.Movimientos.Add(movimiento);
            await _context.SaveChangesAsync();
            return movimiento;
        }

       

        public async Task<List<Movimiento>> GetFilteredMovimientos(Expression<Func<Movimiento, bool>> predicate)
        {
            _logger.LogInformation("Obteniendo movimientos filtrados");
            return await _context.Movimientos.Include("CuentaNavigation")
            .Where(predicate).ToListAsync();
        }
    }
}
