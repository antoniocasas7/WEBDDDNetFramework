using Domain.Core.Event;
using System;

namespace Domain.Core.Model.Persona
{
    public interface IPersonaTelefonoChanged : IDomainEvent
    {
        Persona Persona { get; set; }
        string Precio { get; set; }
        DateTime OccuredOn { get; set; }
    }
}
