
using Api.Facultad.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Facultad.Domain.Entities
{
    [Table("Facultad", Schema = "dbo")]
    public class Facultade : BaseEntity
    {

        [Column("Nombre")]
        [Required]
        public string? Nombre { get; set; }

        [Column("Encargado")]
        public string? Encargado { get; set; }

        public virtual ICollection<Escuela>? Escuelas { get; set; }
    }
}
