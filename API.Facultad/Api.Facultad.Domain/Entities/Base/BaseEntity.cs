using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api.Facultad.Domain.Entities.Base
{
    public abstract class BaseEntity : AuditEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public long Id { get; set; }

        [Column("Eliminado")]
        [Required]
        public bool IsDeleted { get; set; }
    }
}
