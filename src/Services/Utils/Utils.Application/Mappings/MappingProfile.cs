using AutoMapper;
using Utils.Application.Features.Query.GetUnitList;
using U=Utils.Domain.Entities;

namespace Utils.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<U.Unit, UnitLists>().ReverseMap();

            CreateMap<U.UnitDetail, Features.Query.GetUnitDetail.UnitDetail>().ReverseMap();

            CreateMap<U.UnitDetail, Features.Query.GetUnitDetailById.UnitDetailById>().ReverseMap();
        }
    }
}
