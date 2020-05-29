using Domain.Core.Model.Persona;
using MassTransit;
using System;

namespace Infrastructure.Messaging.MassTransit.Consumer
{
    public class PersonaCreated : Consumes<IPersonaCreated>.Context
    {

        public static void Listen()
        {
            var bus = BusInitializer.CreateBus("Subscriber", x =>
            {
                x.Subscribe(subs =>
                {
                    subs.Consumer<PersonaCreated>().Permanent();
                });
            });
        }


        public void Consume(IConsumeContext<IPersonaCreated> message)
        {
            throw new NotImplementedException();
        }
    }
}
