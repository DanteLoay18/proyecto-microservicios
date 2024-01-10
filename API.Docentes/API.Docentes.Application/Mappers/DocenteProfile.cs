using API.Docentes.Application.Features.Docentes.Queries.GetDocentesPaginated;
using API.Docentes.Domain.DTOs.Request;
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
        }
           
    }
}
