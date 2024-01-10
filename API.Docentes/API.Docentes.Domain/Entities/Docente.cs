

using API.Docentes.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Docentes.Domain.Entities
{
    [Table("Docente")]
    public class Docente : BaseEntity
    {

        [Column("NombreCompleto")]
        [Required]
        public string? NombreCompleto { get; set; }

        [Column("IdEscuela")]
        [Required]
        public int? IdEscuela { get; set; }

        [Column("IdFacultad")]
        [Required]
        public int? IdFacultad { get; set; }

        [Column("Email")]
        [Required]
        public string? Email { get; set; }

        [Column("NumeroDocumento")]
        [Required]
        public string? NumeroDocumento { get; set; }
    }
}
