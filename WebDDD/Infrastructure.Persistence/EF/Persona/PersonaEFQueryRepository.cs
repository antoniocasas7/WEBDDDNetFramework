namespace Infrastructure.Persistence.EF.Persona
{
    //public class PersonaEFQueryRepository : IPersonaQueryRepository
    //{
    //    private readonly ICache<IEnumerable<Domain.Core.Model.Persona.Persona>> cacheRepository;

    //    private readonly WebDDDNet.Models.ApplicationDbContext dbcontext;

    //    public PersonaEFQueryRepository(WebDDDNet.Models.ApplicationDbContext dbcontext, ICache<IEnumerable<Domain.Core.Model.Persona.Persona>> cacheRepository) 
    //    {
    //        this.dbcontext = dbcontext;
    //        this.cacheRepository = cacheRepository;
    //    }

    //    public async Task<IEnumerable<Domain.Core.Model.Persona.Persona>> GetAll()
    //    {
    //        IEnumerable<Domain.Core.Model.Persona.Persona> personaToReturn = cacheRepository.Get("Persona");
    //        if (personaToReturn != null)
    //            return personaToReturn;

    //        cacheRepository.Set("Persona", personaToReturn);
    //        return await dbcontext.Personas.ToListAsync(); 
    //    }

    //    public async Task<Domain.Core.Model.Persona.Persona> GetById(int id)
    //    {
    //        IEnumerable<Domain.Core.Model.Persona.Persona> personaToReturn = cacheRepository.Get("Persona" + id.ToString());
    //        if (personaToReturn != null)
    //            return personaToReturn.SingleOrDefault();

    //        cacheRepository.Set("Persona" + id, personaToReturn);
    //        return await dbcontext.Personas.Where(p => p.Id == id).SingleAsync();
    //    }

    //    public async Task<IEnumerable<Domain.Core.Model.Persona.Persona>> GetBySearchText(string text)
    //    {
    //        return await dbcontext.Personas.Where(p => p.Nombre.Contains(text)).ToListAsync();
    //    }
    //}
}
