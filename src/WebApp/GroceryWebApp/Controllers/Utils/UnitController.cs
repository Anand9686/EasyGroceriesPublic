using GroceryWebApp.Pages.Utils.Model;
using GroceryWebApp.Pages.Utils.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryWebApp.Controllers.Utils
{
    public class UnitController : Controller
    {
        private readonly IUtilsService _utilsService;

        public UnitController(IUtilsService utilsService)
        {
            _utilsService = utilsService ?? throw new ArgumentNullException(nameof(utilsService));
        }

        public async Task<IActionResult> GetUnits()
        {
            var Units = await _utilsService.GetUnits();
            //StringBuilder sb = new StringBuilder();
            //sb.Append("{");
            //foreach(UnitModel unit in Units)
            //{
            //    sb.Append( " '" + unit.Id.ToString() + "': '" + unit.UnitName + "',");
            //}
            //sb.Append("}");
           // var UnitsList = Units.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.UnitName }).ToList();

            return Json(Units);
        }

        [HttpGet(Name = "GetUnitDetail")]
        public async Task<IActionResult> GetUnitDetail(int unitId)
        {
            var Units = await _utilsService.GetUnitDetail(unitId.ToString());
            return Json(Units);
        }

        [HttpGet(Name = "GetUnitDetailById")]
        public async Task<IActionResult> GetUnitDetailById(int unitDetailId)
        {
            var UnitDetail = await _utilsService.GetUnitDetailById(unitDetailId.ToString());
            return Json(UnitDetail);
        }
    }
}
