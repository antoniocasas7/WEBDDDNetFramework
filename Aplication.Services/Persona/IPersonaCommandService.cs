using Aplication.Services.Persona.DTO;
using System.Threading.Tasks;

namespace Aplication.Services.Persona
{
    public interface IPersonaCommandService
    {
        Task<bool> CreateNewPersonaAsync(PersonaDTO personaDto);

        Task<bool> DeletePersonaAsync(PersonaDTO personaDTO);
    }
}
