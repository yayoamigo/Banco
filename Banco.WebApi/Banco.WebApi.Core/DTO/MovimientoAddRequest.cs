using Banco.WebApi.Entity;
using System.ComponentModel.DataAnnotations;

namespace ServiceContracts.DTO
{
    public class MovimientoAddRequest
    {
        [Required]
        public string TipoMovimiento { get; set; } = null!;
        [Required]
        public decimal Valor { get; set; }
        [Required]
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
