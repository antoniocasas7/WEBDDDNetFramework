using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Core.Model.Animal
{
    [Table("Animales")]
    public class Animal : BaseEntity
    {

        public int Id { get; set; }
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Raza { get; set; }
        public string Dnipropietario { get; set; }

        public Animal()
        {
        }

        public Animal(int id, string identificacion, string nombre, string raza, string dnipropietario)
        {
            this.Id = id;
            this.Identificacion = identificacion;
            this.Nombre = nombre;
            this.Raza = raza;
            this.Dnipropietario = dnipropietario;

            // Evento al crear el objeto.
            // this.AddEvent((IPersonaCreated)new PersonaCreated(this));
        }
    }
}
