using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Banco.WebApi.Entity;

public partial class Cuenta
{
    [Key]
    public int NumeroCuenta { get; set; }

    [Required]
    public int ClienteId { get; set; }

    [Required]
    public string TipoCuenta { get; set; }

    [Required]
    public decimal SaldoInicial { get; set; }

    public string? Estado { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual ICollection<Movimiento> Movimientos { get; set; } = new List<Movimiento>();
}
