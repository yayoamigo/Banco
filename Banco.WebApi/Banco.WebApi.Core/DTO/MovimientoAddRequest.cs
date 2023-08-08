using Banco.WebApi.Entity;

namespace ServiceContracts.DTO
{
    public class MovimientoAddRequest
    {
        public string TipoMovimiento { get; set; } = null!;
        public decimal Valor { get; set; }
        public int NumeroCuenta { get; set; }

        public Movimiento ToMovimiento()
        {
            return new Movimiento()
            {
                TipoMovimiento = TipoMovimiento,
                Valor = Valor,
                NumeroCuenta = NumeroCuenta
            };
        }
    }
}
