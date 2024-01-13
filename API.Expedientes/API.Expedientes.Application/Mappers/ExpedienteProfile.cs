
using Api.Expedientes.Domain.DTOs.Response;
using Api.Expedientes.Domain.Entities;
using Api.Facultad.Domain.Constants.Base;
using API.Expedientes.Application.Features.Commands.CreateExpediente;
using API.Expedientes.Application.Features.Commands.UpdateExpediente;
using API.Expedientes.Domain.DTOs.Response;
using AutoMapper;

namespace API.Docentes.Application.Mappers
{
    public class ExpedienteProfile : Profile
    {
        public ExpedienteProfile()
        {

            CreateMap<Expediente, ExpedienteItemResponse>();

            CreateMap<(int, int, int, List<ExpedienteItemResponse>), PaginatorResponse<ExpedienteItemResponse>>()
                .ForMember(d => d.Items, opt => opt.MapFrom(src => src.Item4))
                .ForMember(d => d.Page, opt => opt.MapFrom(src => src.Item1))
                .ForMember(d => d.PageSize, opt => opt.MapFrom(src => src.Item2))
                .ForMember(d => d.Total, opt => opt.MapFrom(src => src.Item3));

            CreateMap<CreateExpedienteCommand, Expediente>()
                .ForMember(d => d.CreatedBy, opt => opt.MapFrom(src => src.IdUsuario))
                .ForMember(d => d.CreatedAt, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(d => d.CreatedFrom, opt => opt.MapFrom(src => AuditoriaConstant.FromCreateExpediente));

            CreateMap<UpdateExpedienteCommand, Expediente>()
               .ForMember(d => d.ModifiedBy, opt => opt.MapFrom(src => src.IdUsuario))
               .ForMember(d => d.ModifiedAt, opt => opt.MapFrom(src => DateTime.Now))
               .ForMember(d => d.ModifiedFrom, opt => opt.MapFrom(src => AuditoriaConstant.FromUpdateExpediente));

        }
           
    }
}
