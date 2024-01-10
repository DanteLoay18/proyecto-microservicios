using API.Docentes.Application.Features.Docentes.Command.CreateDocente;
using API.Docentes.Application.Features.Docentes.Command.DeleteDocente;
using API.Docentes.Application.Features.Docentes.Command.UpdateDocente;
using API.Docentes.Application.Features.Docentes.Queries.GetDocentesPaginated;
using API.Docentes.Domain.Constants.Base;
using API.Docentes.Domain.DTOs.Request;
using API.Docentes.Domain.DTOs.Response;
using API.Docentes.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Docentes.Application.Mappers
{
    public class DocenteProfile : Profile
    {
        public DocenteProfile()
        {

            CreateMap<GetDocentesPaginatedRequest, GetDocentesPaginatedQuery>();
            CreateMap<CreateDocenteRequest, CreateDocenteCommand>();
            CreateMap<UpdateDocenteRequest, UpdateDocenteCommand>();
            CreateMap<DeleteDocenteRequest, DeleteDocenteCommand>();

            CreateMap<Docente, DocenteItemResponse>();

            CreateMap<(int, int, int, List<DocenteItemResponse>), PaginatorResponse<DocenteItemResponse>>()
                .ForMember(d => d.Items, opt => opt.MapFrom(src => src.Item4))
                .ForMember(d => d.Page, opt => opt.MapFrom(src => src.Item1))
                .ForMember(d => d.PageSize, opt => opt.MapFrom(src => src.Item2))
                .ForMember(d => d.Total, opt => opt.MapFrom(src => src.Item3));

            CreateMap<CreateDocenteCommand, Docente>()
                .ForMember(d => d.CreatedBy, opt => opt.MapFrom(src => src.IdUsuario))
                .ForMember(d => d.CreatedAt, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(d => d.CreatedFrom, opt => opt.MapFrom(src => AuditoriaConstant.FromCreateDocente));

            CreateMap<UpdateDocenteCommand, Docente>()
                .ForMember(d => d.ModifiedBy, opt => opt.MapFrom(src => src.IdUsuario))
                .ForMember(d => d.ModifiedAt, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(d => d.ModifiedFrom, opt => opt.MapFrom(src => AuditoriaConstant.FromUpdateDocente));

            CreateMap<DeleteDocenteCommand, Docente>()
              .ForMember(d => d.IsDeleted, opt => opt.MapFrom(src => true))
              .ForMember(d => d.ModifiedBy, opt => opt.MapFrom(src => src.IdUsuario))
              .ForMember(d => d.ModifiedAt, opt => opt.MapFrom(src => DateTime.Now))
              .ForMember(d => d.ModifiedFrom, opt => opt.MapFrom(src => AuditoriaConstant.FromDeleteDocente));
        }
           
    }
}
