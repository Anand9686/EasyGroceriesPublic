using GroceryWebApp.Pages.Utils.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryWebApp.Pages.Utils.Services
{
    public interface IUtilsService
    {
        Task<IEnumerable<UnitModel>> GetUnits();
        Task<IEnumerable<UnitDetailModel>> GetUnitDetail(string unitId);
        Task<UnitDetailModel> GetUnitDetailById(string unitDetailId);
    }
}
