

using Api.Facultad.Domain.DTOs.Base;

namespace Api.Facultad.Domain.DTOs.Request
{
    public class AsignarEncargadoRequest : RequestBase
    {
        public string IdEncargado { get; set; } = string.Empty;
        public long IdFacultad { get; set; }

    }
}
