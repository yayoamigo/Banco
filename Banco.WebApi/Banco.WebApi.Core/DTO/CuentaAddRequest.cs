using Banco.WebApi.Entity;
using System.ComponentModel.DataAnnotations;

namespace ServiceContracts.DTO
{
    public class CuentaAddRequest
    {
        [Required]
        public int NumeroCuenta { get; set; }
        [Required]
        public int ClienteId { get; set; }
        [Required]
        public string TipoCuenta { get; set; } = null!;
        [Required]
        public decimal SaldoInicial { get; set; }
        [Required]
        public string Nombre { get; set; } 

        public Cuenta ToCuenta()
        {
            return new Cuenta()
            {
                ClienteId = ClienteId,
                TipoCuenta = TipoCuenta,
                SaldoInicial = SaldoInicial,
                Nombre = Nombre,
                NumeroCuenta = NumeroCuenta

            };
        }
    }
}
