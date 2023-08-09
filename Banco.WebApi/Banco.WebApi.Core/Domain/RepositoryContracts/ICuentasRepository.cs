using Banco.WebApi.Entity;
using System.Linq.Expressions;

namespace RepositoryContracts
{
    public interface ICuentasRepository
    {
        Task<Cuenta> AddCuenta(Cuenta cuenta);
        Task<List<Cuenta>> GetAllCuentas();
        Task<Cuenta?> GetCuentaByNumeroCuenta(int numeroCuenta);
        Task<bool> DeleteCuentaByNumeroCuenta(int numeroCuenta);
        
    }
}
