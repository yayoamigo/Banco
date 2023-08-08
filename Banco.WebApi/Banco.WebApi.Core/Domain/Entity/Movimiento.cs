using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Banco.WebApi.Entity;

public partial class Movimiento
{
    [Key]
    [Required]
    public int MovimientoId { get; set; }

    [Required]
    
    public DateTime Fecha { get; set; }

    [Required]
    public string TipoMovimiento { get; set; } = null!;

    [Required]
    public decimal Valor { get; set; }

    
    public decimal? Saldo { get; set; }

    public decimal? SaldoInicial { get; set; }

    [Required]
    public int NumeroCuenta { get; set; }

    public virtual Cuenta NumeroCuentaNavigation { get; set; } = null!;
}
