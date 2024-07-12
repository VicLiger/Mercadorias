using AutoMapper;
using Mercadorias.Application.DTOs;
using Mercadorias.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Mercadorias.Application.Mapping
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Item, ItemDTO>().ReverseMap();
        }
    }
}
