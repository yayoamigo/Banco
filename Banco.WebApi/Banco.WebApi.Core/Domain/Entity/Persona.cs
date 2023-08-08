using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Banco.WebApi.Entity;

public partial class Persona
{
    [Key]
    [Required]
    public int Identificacion { get; set; }

    [Required]
    public string Nombre { get; set; } = null!;

    public string? Genero { get; set; }

    public int? Edad { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

}
