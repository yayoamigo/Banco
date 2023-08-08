using Banco.WebApi.Entity;

namespace ServiceContracts.DTO
{
    public class PersonaAddRequest
    {
        public int Identificacion { get; set; }
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
