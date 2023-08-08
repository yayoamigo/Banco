using Banco.WebApi.Entity;
using System.Linq.Expressions;

namespace RepositoryContracts
{
    public interface IMovimientosRepository
    {
        Task<Movimiento> AddMovimiento(Movimiento movimiento);
        
        Task<List<Movimiento>> GetFilteredMovimientos(Expression<Func<Movimiento, bool>> predicate);
        
        
    }
}
