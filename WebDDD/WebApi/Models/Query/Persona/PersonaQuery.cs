using Aplication.Services.Persona.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace WebApi.Models.Query.Persona
{
   
    public class PersonaQuery : IRequest<PersonaQueryResult>
    {     
        public int Id { get; set; }
        public string SearchString { get; set; }
    }

    public class PersonaQueryResult
    {
        // public List<PersonaDTO> Personas { get; set; } = new List<PersonaDTO>();
        public List<PersonaDTO> Personas { get; set; } 
    }
}