﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Banco.WebApi.Entity;

public partial class Cliente
{
    [Key]
    [Required]
    public int ClienteId { get; set; }
    [Required]
    public int Identificacion { get; set; }
    [Required]
    public string Contrasena { get; set; } 
    
    public string? Nombre { get; set; } 
    public string? Estado { get; set; } = "Activo";

    public virtual ICollection<Cuenta> Cuenta { get; set; } = new List<Cuenta>();

}
