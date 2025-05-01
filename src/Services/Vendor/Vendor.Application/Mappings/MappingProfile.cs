using AutoMapper;
using Vendor.Application.Features.Vendor.Query.GetVendorList;
using Vendor.Application.Features.Commands.CreateVendor;
using Vendor.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vendor.Domain.Entities;
using Vendor.Application.Features.Vendor.Query.GetVendorProdList;

namespace Vendor.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<VendorInfo, VendorList>().ReverseMap();
            CreateMap<VendorInfo, CreateVendorCommand> ().ReverseMap();
            CreateMap<VendorProductsInfo, VendorProdList>().ReverseMap();
        }
    }
}
