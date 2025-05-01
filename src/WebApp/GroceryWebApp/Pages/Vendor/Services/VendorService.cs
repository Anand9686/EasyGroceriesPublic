using GroceryWebApp.Extensions;
using GroceryWebApp.Pages.Vendor.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace GroceryWebApp.Pages.Vendor.Services
{
    public class VendorService : IVendorService
    {
        private readonly HttpClient _client;

        public VendorService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<VendorResponseModel>> GetVendors()
        {
            var response = await _client.GetAsync($"/Api/Vendor");
            return await response.ReadContentAs<List<VendorResponseModel>>();
        }

        public async Task<int> CreateVendor(VendorResponseModel prodmodel)
        {
            var response = await _client.PostAsJson($"/Api/Vendor", prodmodel);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<int>();
            else
            {
                throw new Exception("Something went wrong when calling api.");
            }
        }

        public async Task<IEnumerable<VendorResponseModel>> GetVendor(int vendorid)
        {
            var response = await _client.GetAsync($"/Api/Vendor/GetVendor/{vendorid}");

            return await response.ReadContentAs<IEnumerable<VendorResponseModel>>();
        }

        public async Task<int> CreateVendorProducts(VendorProductsModel model)
        {
            var response = await _client.PostAsJson($"/Api/Vendor/CreateVendorProducts", model);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<int>();
            else
            {
                throw new Exception("Something went wrong when calling api.");
            }
        }

        public async Task<IEnumerable<VendorProductsModel>> GetVendorProducts(VendorProductsModel ctrRespModel)
        {
            var response = await _client.GetAsync($"/api/Vendor/GetVendorProducts?VendorId=" + ctrRespModel.VendorId + "&CategoryId="+ctrRespModel.CategoryId);
            return await response.ReadContentAs<List<VendorProductsModel>>();
        }
       
    }
}
