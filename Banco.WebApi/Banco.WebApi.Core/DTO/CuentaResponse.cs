using Banco.WebApi.Entity;

namespace ServiceContracts.DTO
{
    public class CuentaResponse
    {
        public int NumeroCuenta { get; set; }
        public decimal SaldoInicial { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != typeof(CuentaResponse)) return false;
            CuentaResponse cuenta_to_compare = (CuentaResponse)obj;
            return NumeroCuenta == cuenta_to_compare.NumeroCuenta && SaldoInicial == cuenta_to_compare.SaldoInicial;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    public static class CuentaExtensions
    {
        public static CuentaResponse ToCuentaResponse(this Cuenta cuenta)
        {
            return new CuentaResponse() { NumeroCuenta = cuenta.NumeroCuenta, SaldoInicial = cuenta.SaldoInicial };
        }
    }
}
