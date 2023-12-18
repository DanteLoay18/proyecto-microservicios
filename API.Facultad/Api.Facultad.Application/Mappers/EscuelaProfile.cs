using Api.Facultad.Domain.DTOs.Response;
using Api.Facultad.Domain.Entities;
using AutoMapper;

namespace Api.Facultad.Application.Mappers
{
    public class EscuelaProfile : Profile
    {
        public EscuelaProfile()
        {
            CreateMap<Escuela, EscuelaItemResponse>();
        }
    }
}
