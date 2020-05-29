using Domain.Core.Event;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Core.Model
{
    public abstract class BaseEntity
    {
        #region propiedades publicas
        [Display(Name = nameof(traducciones.Mensajes.Creada_por), ResourceType = typeof(traducciones.Mensajes))]
        public string UsuarioIdCreacion { get; set; }

        [Display(Name = nameof(traducciones.Mensajes.Fecha_creacion), ResourceType = typeof(traducciones.Mensajes))]
        public DateTime FechaCreacion { get; set; }

        [Display(Name = nameof(traducciones.Mensajes.Editada_por), ResourceType = typeof(traducciones.Mensajes))]
        public string UsuarioIdActualizacion { get; set; }

        [Display(Name = nameof(traducciones.Mensajes.Fecha_edicion), ResourceType = typeof(traducciones.Mensajes))]
        public DateTime? FechaActualizacion { get; set; }
        #endregion

        private readonly ICollection<IDomainEvent> Events = new List<IDomainEvent>();

        protected void AddEvent(IDomainEvent @event)
        {
            this.Events.Add(@event);
        }

        private void ClearEvents()
        {
            this.Events.Clear();
        }

        public void DispatchEvents()
        {

            foreach (IDomainEvent @event in Events)
            {
                DomainEvents.Publish(@event);
            }
            ClearEvents();
        }
    }
}
