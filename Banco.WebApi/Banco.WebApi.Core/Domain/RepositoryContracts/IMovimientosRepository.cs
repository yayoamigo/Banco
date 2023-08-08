using Banco.WebApi.Entity;
using System.Linq.Expressions;

namespace RepositoryContracts
{
    public interface IMovimientosRepository
    {
        Task<bool> RealizarMovimiento(int numeroCuenta, decimal valor, string tipoMovimiento);


        Task<List<Movimiento>> GetFilteredMovimientos(Expression<Func<Movimiento, bool>> predicate);
        
        
    }
}
