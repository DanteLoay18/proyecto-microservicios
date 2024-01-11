using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api.Expedientes.Domain.Entities.Base
{
    public abstract class BaseEntity : AuditEntity
    {
     
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
