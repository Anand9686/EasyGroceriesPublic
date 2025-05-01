using GroceryWebApp.Extensions;
using GroceryWebApp.Pages.Utils.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GroceryWebApp.Pages.Utils.Services
{
    public class UtilsServices: IUtilsService
    {
        private readonly HttpClient _client;

        public UtilsServices(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<UnitModel>> GetUnits()
        {
            var response = await _client.GetAsync($"/Api/Unit");
            return await response.ReadContentAs<List<UnitModel>>();
        }

        public async Task<IEnumerable<UnitDetailModel>> GetUnitDetail(string unitId)
        {
            var response = await _client.GetAsync($"/Api/Unit/GetUnitDetail/{unitId}");
            return await response.ReadContentAs<List<UnitDetailModel>>();
        }

        public async Task<UnitDetailModel> GetUnitDetailById(string unitDetailId)
        {
            var response = await _client.GetAsync($"/Api/Unit/GetUnitDetailById/{unitDetailId}");
            return await response.ReadContentAs<UnitDetailModel>();
        }
    }
}
