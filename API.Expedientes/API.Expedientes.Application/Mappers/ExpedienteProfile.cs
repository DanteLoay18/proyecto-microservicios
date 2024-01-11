
using Api.Expedientes.Domain.Entities;
using Api.Facultad.Domain.Constants.Base;
using API.Expedientes.Application.Features.Commands.CreateExpediente;
using AutoMapper;

namespace API.Docentes.Application.Mappers
{
    public class ExpedienteProfile : Profile
    {
        public ExpedienteProfile()
        {


            CreateMap<CreateExpedienteCommand, Expediente>()
                .ForMember(d => d.CreatedBy, opt => opt.MapFrom(src => src.IdUsuario))
                .ForMember(d => d.CreatedAt, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(d => d.CreatedFrom, opt => opt.MapFrom(src => AuditoriaConstant.FromCreateExpediente));

        }
           
    }
}
