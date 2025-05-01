using AutoMapper;
using Categories.Application.Features.Categories.Query.GetCategoryList;
using Categories.Application.Features.Commands.CreateCategory;
using Categories.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Categories.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryList>().ReverseMap();
            CreateMap<Category, CreateCategoryCommand> ().ReverseMap();
        }
    }
}
