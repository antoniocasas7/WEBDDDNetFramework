namespace Infrastructure.Persistence.SQL.Persona.QueryObjects
{
    internal class PersonaInsert
    {
        public QueryObject Query(object queryParameters)
        {
            //return new QueryObject(@"insert into Personas(dni, nombre, apellidos, telefono) values (@Dni, @Nombre, @Apellidos, @Telefono);
            //                         SELECT last_insert_rowid();", queryParameters);

            return new QueryObject(@"insert into Personas(dni, nombre, apellidos, telefono) values (@Dni, @Nombre, @Apellidos, @Telefono);
                                    ", queryParameters);
        }
    }
}
