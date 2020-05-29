using Domain.Core.Event;
using System;

namespace Domain.Core.Model.Persona
{
    public interface IPersonaCreated : IDomainEvent
    {
        Persona persona { get; set; }

        DateTime OccurredOn { get; set; }
    }
}
