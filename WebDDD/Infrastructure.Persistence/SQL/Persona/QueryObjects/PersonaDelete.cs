namespace Infrastructure.Persistence.SQL.Persona.QueryObjects
{
    internal class PersonaDelete
    {
        public QueryObject All()
        {
            return new QueryObject("delete from Personas");
        }

        public QueryObject ById(int personaId)
        {
            return new QueryObject(All().Sql + @" where p.AdId = @Id", new { Id = personaId });
        }
    }
}


