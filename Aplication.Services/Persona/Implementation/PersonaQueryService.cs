using Aplication.Services.Persona.DTO;
using Domain.Core.Model.Persona;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aplication.Services.Persona.Implementation
{
    public class PersonaQueryService : IPersonaQueryService
    {
        private IPersonaQueryRepository personaQueryRepository;

        public PersonaQueryService(IPersonaQueryRepository personaQueryRepository)
        {
            this.personaQueryRepository = personaQueryRepository;
        }

        public async Task<List<PersonaDTO>> GetAllPersona()
        {
            var result = await personaQueryRepository.GetAll();
            List<PersonaDTO> resultDto = new List<PersonaDTO>();
          

            foreach (var persona in result)
            {
                PersonaDTO per = new PersonaDTO
                {
                    Id = persona.Id,
                    dni = persona.Dni,
                    nombre = persona.Nombre,
                    apellidos = persona.Apellidos,
                    telefono = persona.Telefono
                };
                // if(resultDto != null && per != null)
                resultDto.Add(per);
            }      
            return resultDto;
        }

        public async Task<PersonaDTO> GetPersonaById(int id)
        {
            var result = await personaQueryRepository.GetById(id);
            return new PersonaDTO()
            {
                Id = result.Id,
                dni = result.Dni,
                nombre = result.Nombre,
                apellidos = result.Apellidos,
                telefono = result.Telefono
            };
        }
    }
}
