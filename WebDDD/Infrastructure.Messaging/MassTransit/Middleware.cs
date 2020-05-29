using Domain.Core.Event;
using MassTransit;
using MassTransit.BusConfigurators;
using MassTransit.Log4NetIntegration.Logging;
using System;

namespace Infrastructure.Messaging.MassTransit
{
    public class Middleware : IDomainEventPublisher
    {
        private static IServiceBus serviceBus = null;
        private static IServiceBus bus
        {
            get
            {
                if (serviceBus == null)
                    serviceBus = BusInitializer.CreateBus("Publisher", x => { });

                return serviceBus;
            }
        }

        public void Publish(IDomainEvent domainEvent)
        {
            switch (domainEvent.GetType().Name)
            {
                case "PersonaCreated":
                    //  bus.Publish<IPersonaCreated>(domainEvent, x => { x.SetDeliveryMode(DeliveryMode.Persistent); });
                    // bus.Publish<IPersonaCreated>("PERSONA CREADA");
                    // bus.Publish("PERSONA CREADA");
                    break;
            }
        }
    }

    public class BusInitializer
    {
        public static IServiceBus CreateBus(string queueName, Action<ServiceBusConfigurator> moreInitialization)
        {
            Log4NetLogger.Use();
            var bus = ServiceBusFactory.New(x =>
            {
                x.UseRabbitMq();
                x.ReceiveFrom("rabbitmq://localhost/APITest_" + queueName);
                moreInitialization(x);
            });

            return bus;
        }
    }
}
