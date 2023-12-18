using Api.Facultad.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;

namespace Api.Facultad.Domain.Entities
{
    [Table("Escuela", Schema = "dbo")]
    public class Escuela
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public long Id { get; set; }

        [Column("Nombre")]
        [Required]
        public string? Nombre { get; set; }

        [Column("FacultadId")]
        [Required]
        public long FacultadId { get; set; }

        public virtual Facultade? Facultad { get; set; }
    }
}
