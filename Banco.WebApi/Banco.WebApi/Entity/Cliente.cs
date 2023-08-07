using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Banco.WebApi.Entity;

public partial class Cliente
{
    [Key]
    public int ClienteId { get; set; }

    [Required]
    public int Identificacion { get; set; }

    [Required]
    public string Contrasena { get; set; }

    [Required]
    public string? Estado { get; set; }

    public virtual ICollection<Cuenta> Cuenta { get; set; } = new List<Cuenta>();

    public virtual Persona? IdentificacionNavigation { get; set; }
}
