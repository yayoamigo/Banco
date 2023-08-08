using Banco.WebApi.Entity;

namespace ServiceContracts.DTO
{
    public class PersonaResponse
    {
        public int Identificacion { get; set; }
        public string? Nombre { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != typeof(PersonaResponse)) return false;
            PersonaResponse persona_to_compare = (PersonaResponse)obj;
            return Identificacion == persona_to_compare.Identificacion && Nombre == persona_to_compare.Nombre;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    public static class PersonaExtensions
    {
        public static PersonaResponse ToPersonaResponse(this Persona persona)
        {
            return new PersonaResponse() { Identificacion = persona.Identificacion, Nombre = persona.Nombre };
        }
    }
}
