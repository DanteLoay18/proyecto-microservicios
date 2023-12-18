
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
        }
    }
}
