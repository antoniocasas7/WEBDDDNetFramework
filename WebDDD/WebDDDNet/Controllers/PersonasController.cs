using Aplication.Services.Persona;
using Aplication.Services.Persona.DTO;
using Domain.Core.Model.Persona;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Linq;
using System.Collections.Generic;
using RestSharp;
using System.IO;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System;
using Microsoft.VisualStudio.Services.DelegatedAuthorization;
using Microsoft.Graph;

namespace WebDDDNet.Models
{
    [Authorize]
    public class PersonasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        private IPersonaQueryRepository _personasQueryRepository;
        private IPersonaCommandService _personaCommandService;
        private IPersonaQueryService _personaQueryService;

        public string tokenObtenido;
        protected static RestClient client = null;


        public PersonasController(IPersonaQueryRepository personasQuery, IPersonaQueryService personaQueryService, IPersonaCommandService personaCommandService)
        {
            this._personasQueryRepository = personasQuery;
            this._personaCommandService = personaCommandService;
            this._personaQueryService = personaQueryService;
        }

        //public PersonasController()
        //{
        //}

        // GET: Personas

        public async Task<ActionResult> Index()
        {

            //USANDO ENTIFY FRAMEWORK CON EL DBCONTEXT DESDE EL PROYECTO WEBDDNET
            //return View(await db.Personas.ToListAsync());

            //USANDO PERSONAS QUERY DE LA INFRASTRUCTURE PERSISTENCE SI NECESITAMOS DATOS DE TIPO DE LA BB:DD
             return View(await this._personasQueryRepository.GetAll());

            //USANDO PERSONAS QUERYSERVICE DE APPLICATION SERVICE SI NECESITAMOS DATOS DE TIPO DTO
            //var personaDto = await this._personaQueryService.GetAllPersona();
            //return View(personaDto);

            //USANDO LA FUNCION QUE HAY EN LA WEB API, para usarla enla vista cambiar el IEnumerable a PersonaDto
            //List<PersonaDTO> personas = new List<PersonaDTO>();
            //tokenObtenido = await ObtenerTokenAsync();
            //if (!string.IsNullOrEmpty(tokenObtenido))
            //{
            //    // Si Id = 0 son todas las personas. En este caso devuekve todas y que contienen "pe"
            //    personas = GetPersonasDto(0, "pe");
            //}
            //return View(personas);
        }

        /// <summary>
        ///     Obtiene una lista de Personas <see cref="PersonaDTO"/>
        /// </summary>
        /// <param name="SearchString">Personas que contienen esa cadena</param>
        /// <param name="Id">Id de la Persona a buscar . Si es = 0 es todas </param>
        /// <returns>Lista de ubicaciones</returns>
        private List<PersonaDTO> GetPersonasDto(int Id , string SearchString)
        {
            try
            {
                client = new RestClient("http://localhost:56276/");
              //  var request = new RestRequest("api/Personas/Get/" + Id, Method.GET)
                 var request = new RestRequest("api/Personas/Get/", Method.GET)
                 {
                    RequestFormat = DataFormat.Json
                };
                // Añdo los parametros 
                request.AddParameter("Id", Id);
                request.AddParameter("SearchString", SearchString);
                request.AddHeader("Content-Type", "application/json; charset=utf-8");
                request.AddHeader("Authorization", "bearer" + " " + tokenObtenido);

                //  request.AddHeader("OriginAccess", _originAccess);
                IRestResponse<List<PersonaDTO>> response = client.Execute<List<PersonaDTO>>(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    if (response.Data == null && response.Content != null)
                        response.Data = JsonConvert.DeserializeObject<List<PersonaDTO>>(response.Content);
                    if (response.Data != null)
                    {
                        List<PersonaDTO> personas = JsonConvert.DeserializeObject<List<PersonaDTO>>(JsonConvert.SerializeObject(response.Data));
                        return personas;
                    }
                    else
                        //Mensaje de error
                        Console.WriteLine(response.ErrorMessage);
                }
                else
                {
                    //Si no estamos autorizados significa que ha caducado el token, asi que volvemos a hacer el login
                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        tokenObtenido = ObtenerTokenAsync().ToString();
                        return GetPersonasDto(Id, SearchString);
                    }
                    throw new Exception("Server Error: " + response.ErrorMessage);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
            return null;
        }


        /// <summary>
        ///  Obtiene el Token />
        /// </summary>
        /// <returns>String con el Token</returns>   

        private async Task<string> ObtenerTokenAsync()
        {
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

            HttpResponseMessage lista = new HttpResponseMessage();

            HttpClient client = new HttpClient();
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var formData = new List<KeyValuePair<string, string>>();
            formData.Add(new KeyValuePair<string, string>("client_id", "api-stag"));
            formData.Add(new KeyValuePair<string, string>("grant_type", "password"));
            //formData.Add(new KeyValuePair<string, string>("username", "antoniocasas7@gmail.com"));
            //formData.Add(new KeyValuePair<string, string>("password", "IoT@123"));
            formData.Add(new KeyValuePair<string, string>("username", user.UserName));
            // TENGO EL PASSWORD DEL USUARIO GUARDADO EN EL WEB.CONFIG PORQUE EL DE OWIN NO SE PUEDE DESCIFRAR
            formData.Add(new KeyValuePair<string, string>("password", System.Configuration.ConfigurationManager.AppSettings["userPassword"]));
            formData.Add(new KeyValuePair<string, string>("scope", ""));
   
            var content = new FormUrlEncodedContent(formData);
            var respuesta = await client.PostAsync("http://localhost:56276/Login", content);

            if (respuesta.IsSuccessStatusCode)
            {
                var result = respuesta.Content.ReadAsStringAsync().Result;
                var separados = result.Split('"');
                //El 3 es el Token
                return separados[3];
            }
            else
                return string.Empty;

        }

        //   GET: Personas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = await db.Personas.FindAsync(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // GET: Personas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Personas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Dni,Nombre,Apellidos,Telefono,UsuarioIdCreacion,FechaCreacion,UsuarioIdActualizacion,FechaActualizacion")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                //    db.Personas.Add(persona);
                //    await db.SaveChangesAsync();
                //    return RedirectToAction("Index", "Personas");

                //var result = await _personaCommandRepository.Insert(persona);    

                PersonaDTO varpersonaDTO = new PersonaDTO();
                varpersonaDTO.nombre = persona.Nombre;
                varpersonaDTO.dni = persona.Dni;
                varpersonaDTO.apellidos = persona.Apellidos;
                varpersonaDTO.telefono = persona.Telefono;
                var result = _personaCommandService.CreateNewPersonaAsync(varpersonaDTO);
            }
            //  return View(await db.Personas.ToListAsync());
            return RedirectToAction("Index", "Personas");
        }

        // GET: Personas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = await db.Personas.FindAsync(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // POST: Personas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Dni,Nombre,Apellidos,Telefono,UsuarioIdCreacion,FechaCreacion,UsuarioIdActualizacion,FechaActualizacion")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                db.Entry(persona).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(persona);
        }

        // GET: Personas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = await db.Personas.FindAsync(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // POST: Personas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Persona persona = await db.Personas.FindAsync(id);
            db.Personas.Remove(persona);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
