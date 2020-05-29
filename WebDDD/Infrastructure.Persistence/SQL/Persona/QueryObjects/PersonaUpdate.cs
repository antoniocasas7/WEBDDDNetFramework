namespace Infrastructure.Persistence.SQL.Persona.QueryObjects
{
    internal class PersonaUpdate
    {
        public QueryObject Query(object queryParams)
        {
            return new QueryObject(@"update Personas
                                     set dni = @Dni, nombre = @Nombre , apellidos = @Apellidos, telefono = @Telefono", queryParams);
        }
    }
}
