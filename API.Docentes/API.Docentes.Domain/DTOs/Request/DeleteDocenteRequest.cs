using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Docentes.Domain.DTOs.Request
{
    public class DeleteDocenteRequest
    {
        public long IdDocente { get; set; }
        public string? IdUsuario { get; set; }
    }
}
