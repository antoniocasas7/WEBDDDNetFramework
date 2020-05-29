namespace Infrastructure.Persistence.EF.Persona
{
    //public class PersonaEFCommandRepository : IPersonaCommnadRepository
    //{
    //    //   private readonly IConnectionFactory connection;
    //    private readonly WebDDDNet.Models.ApplicationDbContext dbcontext;

    //    public PersonaEFCommandRepository(WebDDDNet.Models.ApplicationDbContext dbcontext)
    //    {
    //        this.dbcontext = dbcontext;
    //    }

    //    public async Task<bool> Insert(Domain.Core.Model.Persona.Persona persona)
    //    {
    //        return await Task.Run(() =>
    //        {
    //            dbcontext.Personas.Add(persona);
    //            dbcontext.SaveChanges();
    //            if (dbcontext.Personas.Any(c => c.Id.Equals(persona.Id)))
    //                return true;
    //            else
    //                return false;
    //        });
    //    }

    //    public async Task<bool> Delete(Domain.Core.Model.Persona.Persona persona)
    //    {
    //        return await Task.Run(() =>
    //        {
    //            dbcontext.Personas.Remove(persona);
    //            dbcontext.SaveChanges();
    //            if (dbcontext.Personas.Any(c => c.Id.Equals(persona.Id)))
    //                return true;
    //            else
    //                return false;
    //        });
    //    }

    //    public async Task<bool> Update(Domain.Core.Model.Persona.Persona persona)
    //    {
    //        return await Task.Run(() =>
    //        {
    //            if (dbcontext.Personas.Any(c => c.Id.Equals(persona.Id)))
    //            {
    //                dbcontext.Personas.Remove(persona);
    //                dbcontext.Personas.Add(persona);
    //            }
    //            else
    //            {
    //                dbcontext.Personas.Add(persona);
    //            }
    //            dbcontext.SaveChanges();
    //            return true;
    //        });
    //    }
    //}
}
