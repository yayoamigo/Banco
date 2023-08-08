using Banco.WebApi.Entity;

namespace ServiceContracts.DTO
{
    public class CuentaAddRequest
    {
        public int ClienteId { get; set; }
        public string TipoCuenta { get; set; } = null!;
        public decimal SaldoInicial { get; set; }

        public Cuenta ToCuenta()
        {
            return new Cuenta()
            {
                ClienteId = ClienteId,
                TipoCuenta = TipoCuenta,
                SaldoInicial = SaldoInicial
            };
        }
    }
}
