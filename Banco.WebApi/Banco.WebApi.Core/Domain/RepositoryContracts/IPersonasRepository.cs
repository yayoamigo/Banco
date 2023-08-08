using Banco.WebApi.Entity;
using System.Linq.Expressions;

namespace RepositoryContracts
{
    public interface IPersonasRepository
    {
        Task<Persona> AddPersona(Persona persona);
        Task<List<Persona>> GetAllPersonas();
        Task<Persona?> GetPersonaByIdentificacion(int identificacion);
        Task<List<Persona>> GetFilteredPersonas(Expression<Func<Persona, bool>> predicate);
        Task<bool> DeletePersonaByIdentificacion(int identificacion);
        Task<Persona> UpdatePersona(Persona persona);
    }
}
