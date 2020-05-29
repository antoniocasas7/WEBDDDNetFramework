using System;

namespace Domain.Core.Model.Persona
{
    public class PersonaCreated : IPersonaCreated
    {
        public Persona persona { get; set; }
        public DateTime OccurredOn { get; set; }

        public PersonaCreated(Persona persona)
        {
            this.persona = persona ?? throw new ArgumentNullException(nameof(persona));
            OccurredOn = DateTime.Now;
        }

    }
}
