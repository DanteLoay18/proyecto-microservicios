
namespace Api.Facultad.Domain.DTOs.Response
{
    public class FacultadItemResponse
    {
        public long Id { get; set; }
        public string? Nombre { get; set; }
        public string? Encargado { get; set; }
        public ICollection<EscuelaItemResponse>? Escuelas { get; set; }

    }
}
