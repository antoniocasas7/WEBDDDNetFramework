using System;

namespace Domain.Core.Model.Persona
{
    public class PersonaTelefonoChanged : IPersonaTelefonoChanged
    {
        public Persona Persona { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Precio { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime OccuredOn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public PersonaTelefonoChanged(Persona persona, int newTelefono)
        {
            this.Persona = persona;
            this.Persona.Telefono = newTelefono;
            this.OccuredOn = DateTime.Now;
        }
    }
}
