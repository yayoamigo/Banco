using Banco.WebApi.Entity;
using Microsoft.EntityFrameworkCore;
using RepositoryContracts;
using System.Linq.Expressions;
using Banco.WebApi.Infrastructure;
using Microsoft.Extensions.Logging;

namespace Banco.WebApi.Infrastructure.Repositories
{
    public class PersonasRepository : IPersonasRepository
    {
        private readonly BancoDbContext _db;
        private readonly ILogger<PersonasRepository> _logger;

        public PersonasRepository(BancoDbContext db, ILogger<PersonasRepository> logger)
        {
            _db = db;
            _logger = logger;
        }

        public async Task<Persona> AddPersona(Persona persona)
        {
            _logger.LogInformation("Agregada una nueva persona");
            _db.Personas.Add(persona);
            await _db.SaveChangesAsync();
            return persona;
        }

        public async Task<List<Persona>> GetAllPersonas()
        {
            _logger.LogInformation("GetAllPersonas desde PersonasRepository");
            return await _db.Personas.ToListAsync();
        }

        public async Task<Persona?> GetPersonaByIdentificacion(int identificacion)
        {
            return await _db.Personas.FirstOrDefaultAsync(p => p.Identificacion == identificacion);
        }

        public async Task<List<Persona>> GetFilteredPersonas(Expression<Func<Persona, bool>> predicate)
        {
            return await _db.Personas.Where(predicate).ToListAsync();
        }

        public async Task<bool> DeletePersonaByIdentificacion(int identificacion)
        {
            
            _db.Personas.RemoveRange(_db.Personas.Where(temp => temp.Identificacion == identificacion));
            int FilasEliminadas = await _db.SaveChangesAsync();
            _logger.LogInformation($"Eliminada la persona con identificacion: {identificacion}");

            return FilasEliminadas > 0;

        }

        public async Task<Persona> UpdatePersona(Persona persona)
        {
            Persona? matchingPersona = await _db.Personas.FirstOrDefaultAsync(temp => temp.Identificacion == persona.Identificacion);

            if (matchingPersona == null)
                return persona;

            matchingPersona.Nombre = persona.Nombre;
            matchingPersona.Genero = persona.Genero;
            matchingPersona.Edad = persona.Edad;
            matchingPersona.Direccion = persona.Direccion;
            matchingPersona.Telefono = persona.Telefono;

            int countUpdated = await _db.SaveChangesAsync();

            return matchingPersona;
        }

       
    }

}
