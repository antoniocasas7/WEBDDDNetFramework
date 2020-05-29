//using MassTransit.RabbitMqTransport;

namespace Infrastructure.Messaging.MassTransit
{
    //public class Middleware_rabit4 : IDomainEventPublisher
    //{

    //    private static IBusControl serviceBus = null;
    //    private static IBusControl bus
    //    {
    //        get
    //        {
    //            if (serviceBus == null)
    //                serviceBus = BusInitializer.CreateBus();

    //            return serviceBus;
    //        }
    //    }


    //    public void Publish(IDomainEvent domainEvent)
    //    {       
    //        bus.Start();
    //        switch (domainEvent.GetType().Name)  // SI NO FUNCIONA ESTO, HACERLO TODO COMO ESTA COMENTADO EN LA CLASE PersonaCreated
    //        {
    //            case "PersonaCreated":
    //                //VER EL RESULTADO DE LAS 3 SIGUIENTES
    //                 bus.Publish("Persona Creada hoy");
    //                  bus.Publish<IPersonaCreated>(domainEvent);
    //                 bus.Send("PERSONA CREADA POR JUAN");
    //                // Console.WriteLine("PERSONACREADA hoy");              
    //                break;
    //        }

    //        bus.Stop();       
    //    }
    //}

    //public class BusInitializer
    //{
    //    public static IBusControl CreateBus()
    //    {
    //        Log4NetLogger.Use();

    //        var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
    //        {
    //            var host = cfg.Host(new Uri("rabbitmq://localhost/"), h =>
    //            {
    //                h.Username("guest");
    //                h.Password("guest");
    //            });
    //            //cfg.ReceiveEndpoint(host, "APITest_Subscriber", e =>
    //            //{
    //            //    e.Consumer<Infrastructure.Messaging.MassTransit.Consumer.PersonaCreated>();
    //            //});
    //        });
    //        return busControl;         
    //    }
    //}
}
