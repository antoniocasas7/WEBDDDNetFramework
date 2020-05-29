using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Core.Model.Idiomas
{
    [Table("Idiomas")]
    public class Idioma : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = nameof(traducciones.Idiomas.Campo_vacio), ErrorMessageResourceType = typeof(traducciones.Idiomas))]
        [RegularExpression(@"[a-z]{2}-[A-Z]{2}", ErrorMessageResourceName = nameof(traducciones.Idiomas.Cultura_invalida), ErrorMessageResourceType = typeof(traducciones.Idiomas))]
        [StringLength(5, ErrorMessageResourceName = nameof(traducciones.Mensajes.Longitud), ErrorMessageResourceType = typeof(traducciones.Mensajes), MinimumLength = 5)]
        [Display(Name = nameof(traducciones.Idiomas.Cultura_idioma), ResourceType = typeof(traducciones.Idiomas))]
        public string Cultura { get; set; }

        [Required]
        [StringLength(128)]
        [Display(Name = nameof(traducciones.Idiomas.Icono_idioma), ResourceType = typeof(traducciones.Idiomas))]
        public string Icono { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = nameof(traducciones.Idiomas.Campo_vacio), ErrorMessageResourceType = typeof(traducciones.Idiomas))]
        [StringLength(80, ErrorMessageResourceName = nameof(traducciones.Mensajes.Longitud), ErrorMessageResourceType = typeof(traducciones.Mensajes), MinimumLength = 1)]
        [Display(Name = nameof(traducciones.Idiomas.Nombre_idioma), ResourceType = typeof(traducciones.Idiomas))]
        public string Nombre { get; set; }
    }
}
