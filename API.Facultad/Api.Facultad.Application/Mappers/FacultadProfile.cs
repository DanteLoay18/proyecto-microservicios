

using Api.Facultad.Application.Features.Facultad.Command.CreateFacultad;
using Api.Facultad.Application.Features.Facultad.Command.UpdateFacultad;
using Api.Facultad.Domain.DTOs.Response;
using Api.Facultad.Domain.Entities;
using AutoMapper;

namespace Api.Facultad.Application.Mappers
{
    public class FacultadProfile : Profile
    {
        public FacultadProfile()
        {
            CreateMap<CreateFacultadCommand, Facultade>()
              .ForMember(d => d.Nombre, opt => opt.MapFrom(src => src.Nombre))
              .ForMember(d => d.CreatedBy, opt => opt.MapFrom(src => src.UserId))
              .ForMember(d => d.CreatedAt, opt => opt.MapFrom(src => DateTime.Now))
              .ForMember(d => d.CreatedFrom, opt => opt.MapFrom(src => "create facultad"));

            CreateMap<UpdateFacultadCommand, Facultade>()
               .ForMember(d => d.Nombre, opt => opt.MapFrom(src => src.Nombre))
               .ForMember(d => d.ModifiedBy, opt => opt.MapFrom(src => src.UserId))
               .ForMember(d => d.ModifiedAt, opt => opt.MapFrom(src => DateTime.Now))
               .ForMember(d => d.ModifiedFrom, opt => opt.MapFrom(src => "update facultad"));

            CreateMap<Facultade, FacultadItemResponse>();

            CreateMap<(int, int, int, List<FacultadItemResponse>), PaginatorResponse<FacultadItemResponse>>()
                .ForMember(d => d.Items, opt => opt.MapFrom(src => src.Item4))
                .ForMember(d => d.Page, opt => opt.MapFrom(src => src.Item1))
                .ForMember(d => d.PageSize, opt => opt.MapFrom(src => src.Item2))
                .ForMember(d => d.Total, opt => opt.MapFrom(src => src.Item3));
        }
    }
}
