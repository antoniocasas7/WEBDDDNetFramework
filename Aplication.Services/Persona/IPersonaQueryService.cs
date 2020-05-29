using Aplication.Services.Persona.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aplication.Services.Persona
{
    public interface IPersonaQueryService
    {
        Task<List<PersonaDTO>> GetAllPersona();

        Task<PersonaDTO> GetPersonaById(int id);
    }
}
