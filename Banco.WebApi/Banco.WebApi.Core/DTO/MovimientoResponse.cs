using Banco.WebApi.Entity;

namespace ServiceContracts.DTO
{
    public class MovimientoResponse
    {
        public int MovimientoId { get; set; }
        public decimal Valor { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != typeof(MovimientoResponse)) return false;
            MovimientoResponse movimiento_to_compare = (MovimientoResponse)obj;
            return MovimientoId == movimiento_to_compare.MovimientoId && Valor == movimiento_to_compare.Valor;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    public static class MovimientoExtensions
    {
        public static MovimientoResponse ToMovimientoResponse(this Movimiento movimiento)
        {
            return new MovimientoResponse() { MovimientoId = movimiento.MovimientoId, Valor = movimiento.Valor };
        }
    }
}
