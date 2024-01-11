
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Api.Expedientes.Domain.Entities.Base
{
    public abstract class AuditEntity
    {
        public string? CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public string? CreatedFrom { get; set; }

        public string? ModifiedBy { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public string? ModifiedFrom { get; set; }
    }
}
