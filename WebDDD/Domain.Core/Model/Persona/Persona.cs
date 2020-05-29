using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Core.Model.Persona
{
    [Table("Personas")]
    public class Persona : BaseEntity
    {
        public int Id { get; set; }
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Telefono { get; set; }

        public Persona()
        {

            // Evento al crear el objeto.
            this.AddEvent((IPersonaCreated)new PersonaCreated(this));
            this.DispatchEvents();
        }

        public Persona(int id, string dni, string nombre, string apellidos, int telefono)
        {
            this.Id = id;
            this.Dni = dni;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.Telefono = telefono;

            // Evento al crear el objeto.
            this.AddEvent((IPersonaCreated)new PersonaCreated(this));
            this.DispatchEvents();
        }

        public void ChangeTelefono(int NewTelefono)
        {
            this.Telefono = NewTelefono;

            this.AddEvent((IPersonaTelefonoChanged)new PersonaTelefonoChanged(this, this.Telefono));
        }
    }
}
