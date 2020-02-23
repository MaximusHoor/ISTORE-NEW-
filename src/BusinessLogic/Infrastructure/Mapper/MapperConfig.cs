using AutoMapper;
using Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Infrastructure.Mapper
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<OperationDetailDTO, OperationDetail>();
        }
    }
}
