using Banco.WebApi.Entity;
using System.ComponentModel.DataAnnotations;

namespace ServiceContracts.DTO
{
    public class MovimientoResponse
    {
        public int MovimientoId { get; set; }

        public decimal Valor { get; set; }

        public DateTime Fecha { get; set; }

     
        public string TipoMovimiento { get; set; } = null!;


        public decimal? Saldo { get; set; }

        public decimal? saldo_inicial { get; set; }

        public int NumeroCuenta { get; set; }



    }

    public static class MovimientoExtensions
    {
        public static MovimientoResponse ToMovimientoResponse(this Movimiento movimiento)
        {
            return new MovimientoResponse() {  Valor = movimiento.Valor, Fecha = movimiento.Fecha,
                MovimientoId = movimiento.MovimientoId, NumeroCuenta = movimiento.NumeroCuenta, Saldo = movimiento.Saldo, 
                saldo_inicial = movimiento.saldo_inicial, TipoMovimiento = movimiento.TipoMovimiento };
        }
    }
}
