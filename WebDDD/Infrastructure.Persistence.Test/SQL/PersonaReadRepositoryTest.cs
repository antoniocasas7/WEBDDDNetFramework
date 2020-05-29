
using Domain.Core.Event;
using Domain.Core.Model.Persona;
using Domain.Core.Services;
using Infrastructure.Persistence.SQL;
using Infrastructure.Persistence.SQL.Persona;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Test
{
    /// <summary>
    /// Descripción resumida de PersonaQueryTest
    /// </summary>
    [TestFixture]
    public class PersonaReadRepositoryTest
    {      
        private readonly Mock<IConnectionFactory> connectionFactory = new Mock<IConnectionFactory>();
        private readonly Mock<ICache<IEnumerable<Persona>>> cacheRepositoryPersona = new Mock<ICache<IEnumerable<Persona>>>();

        private IPersonaQueryRepository PersonaQueryRepository;
   

        private IDbConnection connection;

        private const string CONNECTION_STRING = "Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=BDANIMALES;Integrated Security=True;";

        List<Persona> listaPersona;

    

        // Subida o Introduccion de datos
        [SetUp]
        public void Setup()
        {
            //ESTO ES PORQUE ESTO SE INICIALIZA EN LA APLICACION EN GLOBAL.ASAX DONDE EL AUTOFAC Y SI NO LO HAGO EL Dispatcher siempre es null y peta
            DomainEvents.Dispatcher = new Infrastructure.Messaging.MassTransit.Middleware();
            this.listaPersona = new List<Persona>()
            {
                new Persona(1, "30948980c", "Juan", "Garcia", 635654565),
                new Persona(2, "30985679T", "Carmen", "Lara", 620897634 ),
            };

            //Deshabilito la cache
            cacheRepositoryPersona.Setup(r => r.Get(It.IsAny<string>())).Returns((IEnumerable<Persona>)null);

            this.connection = new SqlConnection(CONNECTION_STRING);
            //Creo la conexion
            this.connectionFactory.Setup(x => x.Create()).Returns(connection);
            // Creo el objeto QueryRepository con la conexion y la cache , para poder acceder a las funciones que estan en el Test
            this.PersonaQueryRepository = new PersonaQueryRepository(this.connectionFactory.Object, cacheRepositoryPersona.Object);
        }


        [Test]
        public async Task getAll()
        {
            var listaPersonas = await this.PersonaQueryRepository.GetAll();
            //Compruebo si en la cache hay alguna con la feha de ahora
            this.cacheRepositoryPersona.Verify(x => x.Get(It.IsAny<string>()), Times.AtLeast(1));
            //Introduzco en la cache el valor de ahora
            this.cacheRepositoryPersona.Verify(x => x.Set(It.IsAny<string>(), It.IsAny<IEnumerable<Persona>>()), Times.AtLeast(1));

            NUnit.Framework.Assert.IsNotNull(listaPersonas);

        }

        [Test]
        public async Task getById()
        {
            //Obtengo la primera persona de la lista creada en el Setup
            Persona personaResult = await this.PersonaQueryRepository.GetById(listaPersona[0].Id);
            //Compruebo si en la cache hay alguna con la feha de ahora
            this.cacheRepositoryPersona.Verify(x => x.Get(It.IsAny<string>()), Times.AtLeast(1));
            //Introduzco en la cache el valor de ahora
            this.cacheRepositoryPersona.Verify(x => x.Set(It.IsAny<string>(), It.IsAny<IEnumerable<Persona>>()), Times.AtLeast(1));

            NUnit.Framework.Assert.IsNotNull(personaResult);

        }

        [Test]
        public async Task getByText()
        {
            var nombre = "pe";
            IEnumerable<Persona> listaPersonas = await this.PersonaQueryRepository.GetBySearchText(nombre);
            //Compruebo si en la cache hay alguna con la feha de ahora
            this.cacheRepositoryPersona.Verify(x => x.Get(It.IsAny<string>()), Times.AtLeast(1));
            //Introduzco en la cache el valor de ahora
            //this.cacheRepositoryPersona.Verify(x => x.Set(It.IsAny<string>(), It.IsAny<IEnumerable<Persona>>()), Times.AtLeast(1));

            NUnit.Framework.Assert.IsNotNull(listaPersonas);
        }
    }
}
