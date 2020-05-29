//using Infrastructure.Persistence.EF;
//using Infrastructure.Persistence.EF.Persona;

namespace Infrastructure.Persistence.Test.EF
{
    //[TestFixture]
    //public class PersonaReadRepositoryEFTest
    //{
    //    private readonly Mock<ICache<IEnumerable<Persona>>> cacheRepositoryPersona = new Mock<ICache<IEnumerable<Persona>>>();
    //    private IPersonaQueryRepository personaEFQueryRepository;
    //    private readonly ApplicationDbContext dbcontext = new ApplicationDbContext();


    //    // private const string CONNECTION_STRING = "Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog = ANIMALES;Integrated Security=True;";

    //    List<Persona> listaPersona;

    //    // Subida o Introduccion de datos
    //    [SetUp]
    //    public void Setup()
    //    {
    //        this.listaPersona = new List<Persona>()
    //        {
    //            new Persona(1, "30948980c", "Juan", "Garcia", 635654565),
    //            new Persona(2, "30985679T", "Carmen", "Lara", 620897634 ),
    //        };

    //        //Deshabilito la cache
    //        cacheRepositoryPersona.Setup(r => r.Get(It.IsAny<string>())).Returns((IEnumerable<Persona>)null);

    //        this.personaEFQueryRepository = new PersonaEFQueryRepository(this.dbcontext, cacheRepositoryPersona.Object);
    //    }


    //    [Test]
    //    public async Task getAll()
    //    {
    //        var listaPersonas = await this.personaEFQueryRepository.GetAll();
    //        //Compruebo si en la cache hay alguna con la feha de ahora
    //        this.cacheRepositoryPersona.Verify(x => x.Get(It.IsAny<string>()), Times.AtLeast(1));
    //        //Introduzco en la cache el valor de ahora
    //        this.cacheRepositoryPersona.Verify(x => x.Set(It.IsAny<string>(), It.IsAny<IEnumerable<Persona>>()), Times.AtLeast(1));

    //        NUnit.Framework.Assert.IsNotNull(listaPersonas);

    //    }

    //    [Test]
    //    public async Task getById()
    //    {
    //        //Obtengo la primera persona de la lista creada en el Setup
    //        Persona personaResult = await this.personaEFQueryRepository.GetById(listaPersona[0].Id);
    //        //Compruebo si en la cache hay alguna con la feha de ahora
    //        this.cacheRepositoryPersona.Verify(x => x.Get(It.IsAny<string>()), Times.AtLeast(1));
    //        //Introduzco en la cache el valor de ahora
    //        this.cacheRepositoryPersona.Verify(x => x.Set(It.IsAny<string>(), It.IsAny<IEnumerable<Persona>>()), Times.AtLeast(1));

    //        NUnit.Framework.Assert.IsNotNull(personaResult);

    //    }

    //    [Test]
    //    public async Task getByText()
    //    {
    //        var nombre = "pe";
    //        IEnumerable<Persona> listaPersonas = await this.personaEFQueryRepository.GetBySearchText(nombre);
    //        //Compruebo si en la cache hay alguna con la feha de ahora
    //        this.cacheRepositoryPersona.Verify(x => x.Get(It.IsAny<string>()), Times.AtLeast(1));
    //        //Introduzco en la cache el valor de ahora
    //        //this.cacheRepositoryPersona.Verify(x => x.Set(It.IsAny<string>(), It.IsAny<IEnumerable<Persona>>()), Times.AtLeast(1));

    //        NUnit.Framework.Assert.IsNotNull(listaPersonas);
    //    }
    //}
}

