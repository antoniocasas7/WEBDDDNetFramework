using Aplication.Services.Persona.DTO;
using MediatR;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.Models.Query.Persona;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    /// <summary xml:lang="es-ES">
    ///     Controlador encargado de realizar las consultas de las Personas.
    /// </summary>
    /// <summary xml:lang="en-GB">
    ///     Controller in charge of consulting the Persons.
    ///     
    [RoutePrefix("api/Personas")]
    public class PersonasController : ApiController
    {
        private readonly IMediator _mediator;
        public PersonasController(IMediator mediator)
        {
            this._mediator = mediator;
        }


        /// <summary xml:lang="es-ES">
        ///     Obtiene todas las Personas , Segun los para metros de PersonaQuery . Si Id=0 es todos, Searchstring = segun cadena de busqueda.
        /// </summary>
        /// <summary xml:lang="en-GB">
        ///     It obtains all the Persons.
        /// </summary>
        [Route("Get")]
        [ResponseType(typeof(List<PersonaDTO>))]
        public async Task<List<PersonaDTO>> GetAsync([FromUri]Models.Query.Persona.PersonaQuery query)
        {
            //var orders = await _mediator.Send(new GetCustomerOrdersQuery(customerId));
            var personas = await _mediator.Send(query);

            return personas.Personas;
        }



        // GET: api/Personas/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Personas
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Personas/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Personas/5
        public void Delete(int id)
        {
        }
    }
}
