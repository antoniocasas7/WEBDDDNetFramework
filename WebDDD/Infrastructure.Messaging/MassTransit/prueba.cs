namespace Infrastructure.Messaging.MassTransit
{
    public class prueba
    {

        // MAssTRansit4
        //public static void comienzo2()
        //{
        //    IBusControl busControl = Bus.Factory.CreateUsingRabbitMq((Action<global::MassTransit.RabbitMqTransport.IRabbitMqBusFactoryConfigurator>)(sbc =>
        //    {
        //        var host = sbc.Host(new Uri("rabbitmq://localhost"), h =>
        //        {
        //            h.Username("guest");
        //            h.Password("guest");
        //        });

        //       // sbc.UseRetry(Retry.Immediate(5));

        //        sbc.ReceiveEndpoint(host, "input_queue", (Action<global::MassTransit.RabbitMqTransport.IRabbitMqReceiveEndpointConfigurator>)(ep =>
        //        {
        //            ep.Handler(async (ConsumeContext<Domain.Core.Model.Persona.IPersonaCreated> context) =>
        //            {                
        //                await Console.Out.WriteLineAsync($"Actualizada Persona: {context.Message.persona}");
        //            });
        //        }));
        //    }));



        //    //busControl.Start();

        //    //PublishMessage(busControl)
        //    //    .Wait();

        //    //busControl.Stop();
        //}

        //public static Task PublishMessage(IBus bus)
        //{
        //    return bus.Publish(new YourMessage { Text = "Hi" });
        //}
    }
}
