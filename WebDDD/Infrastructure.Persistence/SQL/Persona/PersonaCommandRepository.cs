using Domain.Core.Model.Persona;
using Infrastructure.Persistence.SQL.Persona.QueryObjects;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.SQL.Persona
{
    public class PersonaCommandRepository : IPersonaCommnadRepository
    {
        private readonly IConnectionFactory connection;

        public PersonaCommandRepository(IConnectionFactory connectionFactory)
        {
            this.connection = connectionFactory;
        }

        public async Task<bool> Insert(Domain.Core.Model.Persona.Persona persona)
        {
            return await Task.Run(() =>
            {
                using (IDbConnection dbConnection = connection.Create())
                {
                    var personaInsert = new PersonaInsert();
                    int newId = (int)dbConnection.Query<Int64>(personaInsert.Query(new { dni = persona.Dni, nombre = persona.Nombre, apellidos = persona.Apellidos, telefono = persona.Telefono })).FirstOrDefault();
                    return (newId > 0);
                }
            });
        }

        public async Task<bool> Delete(Domain.Core.Model.Persona.Persona persona)
        {
            return await Task.Run(() =>
            {
                using (IDbConnection dbConnection = connection.Create())
                {
                    QueryObject adDelete = new PersonaDelete().ById(persona.Id);
                    int resultUpdate = dbConnection.Execute(adDelete);
                    return (resultUpdate > 0);
                }
            });
        }

        public async Task<bool> Update(Domain.Core.Model.Persona.Persona persona)
        {
            return await Task.Run(() =>
            {
                using (IDbConnection dbConnection = connection.Create())
                {
                    var personaUpdate = new PersonaUpdate();
                    int resultUpdate = dbConnection.Execute(personaUpdate.Query(new { dni = persona.Dni, nombre = persona.Nombre, apellidos = persona.Apellidos, telefono = persona.Telefono }));
                    return resultUpdate > 0;
                }
            });
        }
    }
}
