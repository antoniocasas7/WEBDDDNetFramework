using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Aplication.Services.Persona.DTO;
using System.Collections.Generic;

namespace WebApi.Models.Query.Persona.GetAll
{
    public class PersonaQueryHandler : IRequestHandler<PersonaQuery, PersonaQueryResult>
    {
        private Aplication.Services.Persona.IPersonaQueryService _personaService;

        public PersonaQueryHandler(Aplication.Services.Persona.IPersonaQueryService personaService)
        {
            this._personaService = personaService;
        }

        public async Task<PersonaQueryResult> Handle(PersonaQuery request, CancellationToken cancellationToken)
        {
            var model = new PersonaQueryResult();

            if (request.Id > 0) // En este caso solo hay un elemnto con ese Id
            {
                var persona = await this._personaService.GetPersonaById(request.Id);
                model.Personas = new List<PersonaDTO>(); // Lo inicializo porque sino da error nul reference y no asigna persona en la linea siguiente
                model.Personas.Add(persona);              
            }
            else // Todas las personas
            {
                model.Personas = await this._personaService.GetAllPersona();
                if (!string.IsNullOrEmpty(request.SearchString))
                    model.Personas = model.Personas.Where(t => t.nombre.Contains(request.SearchString) ||
                                                               t.apellidos.Contains(request.SearchString)).ToList();
            }

            return model;
        }


        Task<PersonaQueryResult> IRequestHandler<PersonaQuery, PersonaQueryResult>.Handle(PersonaQuery request, CancellationToken cancellationToken)
        {
            return Handle(request, cancellationToken);
        }
    }
}