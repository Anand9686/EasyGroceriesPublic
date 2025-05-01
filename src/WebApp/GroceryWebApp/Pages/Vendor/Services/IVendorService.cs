using GroceryWebApp.Pages.Vendor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryWebApp.Pages.Vendor.Services
{
    public interface IVendorService
    {
        Task<IEnumerable<VendorResponseModel>> GetVendors();
        Task<int> CreateVendor(VendorResponseModel model);

        Task<IEnumerable<VendorResponseModel>> GetVendor(int vendorid);

        Task<int> CreateVendorProducts(VendorProductsModel model);

        Task<IEnumerable<VendorProductsModel>> GetVendorProducts(VendorProductsModel ctrRespModel);
    }
}
