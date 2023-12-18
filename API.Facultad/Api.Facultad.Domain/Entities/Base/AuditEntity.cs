
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Api.Facultad.Domain.Entities.Base
{
    public abstract class AuditEntity
    {
        [Column("CreadoPor")]
        [Required]
        public string CreatedBy { get; set; }

        [Column("CreadoEn")]
        [Required]
        public DateTime CreatedAt { get; set; }

        [Column("CreadoDesde")]
        [Required]
        [StringLength(50)]
        public string? CreatedFrom { get; set; }

        [Column("ModificadoPor")]
        public string? ModifiedBy { get; set; }

        [Column("ModificadoEn")]
        public DateTime? ModifiedAt { get; set; }

        [Column("ModificadoDesde")]
        [StringLength(50)]
        public string? ModifiedFrom { get; set; }
    }
}
