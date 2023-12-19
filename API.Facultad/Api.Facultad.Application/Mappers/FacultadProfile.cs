
using Api.Facultad.Application.Features.Facultad.Command.AsignarEncargado;
using Api.Facultad.Domain.DTOs.Response;
using Api.Facultad.Domain.Entities;
using AutoMapper;

namespace Api.Facultad.Application.Mappers
{
    public class FacultadProfile : Profile
    {
        public FacultadProfile()
        {

            CreateMap<Facultade, FacultadItemResponse>();

            CreateMap<(int, int, int, List<FacultadItemResponse>), PaginatorResponse<FacultadItemResponse>>()
                .ForMember(d => d.Items, opt => opt.MapFrom(src => src.Item4))
                .ForMember(d => d.Page, opt => opt.MapFrom(src => src.Item1))
                .ForMember(d => d.PageSize, opt => opt.MapFrom(src => src.Item2))
                .ForMember(d => d.Total, opt => opt.MapFrom(src => src.Item3));

            CreateMap<AsignarEncargadoCommand, Facultade>()
                .ForMember(d => d.Encargado, opt => opt.MapFrom(src => src.IdEncargado))
                .ForMember(d => d.ModifiedBy, opt => opt.MapFrom(src => src.IdUsuario))//quien  hace petición
                .ForMember(d => d.ModifiedAt, opt => opt.MapFrom(src => DateTime.Now))//momento de modificación
                .ForMember(d => d.ModifiedFrom, opt => opt.MapFrom(src => "Asignar encargado"));//tipo de modificacion
        }

    }
}
