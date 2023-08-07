using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Banco.WebApi.Entity;

public partial class Persona
{
    [Key]   
    public int Identificacion { get; set; }

    [Required]
    public string Nombre { get; set; }

    
    public string? Genero { get; set; }

    public int? Edad { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();
}
