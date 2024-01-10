

using API.Docentes.Domain.DTOs.Base;
using MediatR;

namespace API.Docentes.Application.Features.Docentes.Command.UpdateDocente
{
    public class UpdateDocenteCommand : IRequest<ResponseBase>
    {
        public long IdDocente { get; set; }
        public string? NombreCompleto { get; set; }
        public int IdEscuela { get; set; }
        public int IdFacultad { get; set; }
        public string? Email { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? IdUsuario { get; set; }
    }
}
