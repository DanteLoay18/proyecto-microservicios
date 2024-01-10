

using API.Docentes.Domain.DTOs.Base;
using MediatR;

namespace API.Docentes.Application.Features.Docentes.Command.DeleteDocente
{
    public class DeleteDocenteCommand : IRequest<ResponseBase>
    {
        public long IdDocente { get; set; }
        public string? IdUsuario { get; set; }
    }
}
