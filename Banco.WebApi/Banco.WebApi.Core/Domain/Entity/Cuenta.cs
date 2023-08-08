using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Banco.WebApi.Entity;

public partial class Cuenta
{
    [Key]
    [Required]
    public int NumeroCuenta { get; set; }

    [Required]
    public int ClienteId { get; set; }

    [Required]
    public string TipoCuenta { get; set; } = null!;

    [Required]
    public decimal SaldoInicial { get; set; }

   
    public string? Estado { get; set; } = "Activa";

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual ICollection<Movimiento> Movimientos { get; set; } = new List<Movimiento>();
}
