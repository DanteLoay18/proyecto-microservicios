

using API.Docentes.Domain.DTOs.Base;
using MediatR;

namespace API.Docentes.Application.Features.Docentes.Command.CreateDocente
{
    public class CreateDocenteCommand : IRequest<ResponseBase>
    {
        public string? NombreCompleto { get; set; }
        public int? IdEscuela { get; set; }
        public int? IdFacultad { get; set; }
        public string? Email { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? IdUsuario { get; set; }
    }
}
