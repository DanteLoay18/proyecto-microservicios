using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Docentes.Domain.DTOs.Request
{
    public class CreateDocenteRequest
    {
        public string? NombreCompleto { get; set; }
        public int? IdEscuela { get; set; }
        public int? IdFacultad { get; set; }
        public string? Email { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? IdUsuario { get; set; }
    }
}
