using Api.Facultad.Domain.DTOs.Base;


namespace Api.Facultad.Domain.DTOs.Request
{
    public class DeleteEncargadoRequest : RequestBase
    {
        public long IdFacultad { get; set; }
    }
}
