using Aplication.Services.Persona.DTO;
using Domain.Core.Model.Persona;
using System.Threading.Tasks;

namespace Aplication.Services.Persona.Implementation
{
    public class PersonaCommandService : IPersonaCommandService
    {
        private IPersonaCommnadRepository personaCommandRepository;


        public PersonaCommandService(IPersonaCommnadRepository personaCommandRepository)
        {
            this.personaCommandRepository = personaCommandRepository;
        }

        public async Task<bool> CreateNewPersonaAsync(PersonaDTO personaDto)
        {
            Domain.Core.Model.Persona.Persona personaToAdd = new Domain.Core.Model.Persona.Persona(personaDto.Id, personaDto.dni, personaDto.nombre, personaDto.apellidos, personaDto.telefono);

            if (await personaCommandRepository.Insert(personaToAdd))
                personaToAdd.DispatchEvents();

            return true;
        }

        public async Task<bool> DeletePersonaAsync(PersonaDTO personaDTO)
        {
            Domain.Core.Model.Persona.Persona personaToDelete = new Domain.Core.Model.Persona.Persona(personaDTO.Id, personaDTO.dni, personaDTO.nombre, personaDTO.apellidos, personaDTO.telefono);
            if (await personaCommandRepository.Delete(personaToDelete))
                personaToDelete.DispatchEvents();

            return true;
        }
    }
}
