using Banco.WebApi.Entity;
using ServiceContracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.WebApi.Core.ServiceContracts
{
    public interface IPersonaAdderService
    {
        Task<PersonaResponse> AddPersona(PersonaAddRequest persona);
    }
}
