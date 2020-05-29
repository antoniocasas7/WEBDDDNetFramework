namespace Infrastructure.Persistence.SQL.Persona.QueryObjects
{
    internal class PersonaSelect
    {
        public QueryObject All()
        {
            return new QueryObject(@"Select p.id, p.dni, p.nombre, p.apellidos, p.telefono 
                                     From Personas p");
        }

        public QueryObject ByID(int personaId)
        {
            return new QueryObject(All().Sql + @" Where p.Id = @Id", new { Id = personaId });
        }

        public QueryObject AllBySearchText(string textName)
        {
            //  return new QueryObject(All().Sql + @" where p.nombre LIKE '%@Nombre%' ", new { Nombre = textName });
            // return new QueryObject(All().Sql + @" where p.nombre = 'pepe' ");
            return new QueryObject(All().Sql + @" where p.nombre LIKE '%" + textName + "%'");

        }
    }
}
