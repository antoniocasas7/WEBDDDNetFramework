namespace Infrastructure.Messaging.MassTransit.Consumer
{
    //public class PersonaCreated_Rabbit4 : IConsumer<IPersonaCreated> 
    //{     
    //    public static void Listen()
    //    {

    //        var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
    //        {
    //            var host = cfg.Host(new Uri("rabbitmq://localhost/"), h =>
    //                  {
    //                      h.Username("guest");
    //                      h.Password("guest");
    //                  });

    //            cfg.ReceiveEndpoint(host, "PersonaCreada", e =>
    //            {
    //                e.Consumer<PersonaCreated_Rabbit4>();
    //            });
    //        });


    //        //busControl.Start();

    //        //PublishMessage(busControl)
    //        //    .Wait();

    //        //busControl.Stop();

    //    }

    //    //public static Task PublishMessage(IBus bus)
    //    //{
    //    //    var mensaje = "Persona Creada HOY";
    //    //   // return bus.Publish(mensaje);
    //    //    //await Console.Out.WriteLineAsync($"Actualizada Persona: {context.Message.persona}");
    //    //}


    //    public async Task<IPersonaCreated> Consume(ConsumeContext<IPersonaCreated> context)
    //    {
    //        //  throw new NotImplementedException();         
    //        //  await Console.Out.WriteLineAsync($"PERSONA CREADA: {context.Message.persona.Nombre}");
    //        return await Task.FromResult(context.Message);

    //    }
    //}
}
