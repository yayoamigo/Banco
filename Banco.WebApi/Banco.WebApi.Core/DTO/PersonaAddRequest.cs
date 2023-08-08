using Banco.WebApi.Entity;
using System.ComponentModel.DataAnnotations;

namespace ServiceContracts.DTO
{
    public class PersonaAddRequest
    {
        [Required(ErrorMessage = "Identificación can't be blank")]
        public int Identificacion { get; set; }

        [Required(ErrorMessage = "Nombre can't be blank")]
        public string Nombre { get; set; } = null!;
        public string? Genero { get; set; }
        public int? Edad { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }

        public Persona ToPersona()
        {
            return new Persona()
            {
                Identificacion = Identificacion,
                Nombre = Nombre,
                Genero = Genero,
                Edad = Edad,
                Direccion = Direccion,
                Telefono = Telefono
            };
        }
    }
}
