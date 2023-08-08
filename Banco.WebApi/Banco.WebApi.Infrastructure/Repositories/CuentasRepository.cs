using Banco.WebApi.Entity;
using Banco.WebApi.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RepositoryContracts;
using System.Linq.Expressions;

public class CuentasRepository : ICuentasRepository
{
    private readonly BancoDbContext _context;
    private readonly ILogger<CuentasRepository> _logger;

    public CuentasRepository(BancoDbContext context, ILogger<CuentasRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<Cuenta> AddCuenta(Cuenta cuenta)
    {
        _logger.LogInformation("Agregando una nueva cuenta");
        _context.Cuenta.Add(cuenta);
        await _context.SaveChangesAsync();
        return cuenta;
    }

    public async Task<bool> DeleteCuentaByNumeroCuenta(int numeroCuenta)
    {
        _logger.LogInformation($"Eliminando cuenta con número: {numeroCuenta}");
        var cuenta = await _context.Cuenta.FindAsync(numeroCuenta);
        if (cuenta == null)
        {
            return false;
        }

        _context.Cuenta.Remove(cuenta);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<List<Cuenta>> GetAllCuentas()
    {
        _logger.LogInformation("Obteniendo todas las cuentas");
        return await _context.Cuenta.ToListAsync();
    }

    public async Task<Cuenta?> GetCuentaByNumeroCuenta(int numeroCuenta)
    {
        _logger.LogInformation($"Obteniendo cuenta con número: {numeroCuenta}");
        return await _context.Cuenta.FindAsync(numeroCuenta);
    }

    public async Task<List<Cuenta>> GetFilteredCuentas(Expression<Func<Cuenta, bool>> predicate)
    {
        _logger.LogInformation("Obteniendo cuentas filtradas");
        return await _context.Cuenta.Where(predicate).ToListAsync();
    }
}
