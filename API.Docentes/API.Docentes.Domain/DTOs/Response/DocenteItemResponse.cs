using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Docentes.Domain.DTOs.Response
{
    public class DocenteItemResponse
    {
        public long Id { get; set; }
        public string? NombreCompleto { get; set; }
        public int? IdEscuela { get; set; }
        public int? IdFacultad { get; set; }
        public string? Email { get; set; }
        public string? NumeroDocumento { get; set; }
    }
}
