using Vendor.Domain;
using Vendor.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vendor.Domain.Entities;

namespace Vendor.Application.Persistance
{
    public interface IVendorRepository : IAsyncRepository<VendorInfo>
    {
        Task<IEnumerable<VendorInfo>> GetVendors();
        Task<IEnumerable<VendorInfo>> GetVendor(int vendorid);
        Task AddVendorProducts(List<VendorProductsInfo> vendorProducts);
        Task<IEnumerable<VendorProductsInfo>> GetVendorProducts(int vendorId, int categoryId);
    }
}
