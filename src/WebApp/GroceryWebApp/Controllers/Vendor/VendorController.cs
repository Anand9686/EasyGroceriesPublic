using GroceryWebApp.Pages.Vendor.Model;
using GroceryWebApp.Pages.Vendor.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryWebApp.Controllers.Vendor
{
    public class VendorController : Controller
    {
        private readonly IVendorService _vendorService;

        public VendorController(IVendorService vendorService)
        {
            _vendorService = vendorService ?? throw new ArgumentNullException(nameof(vendorService));
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewVendor([FromForm] VendorResponseModel ctrRespModel)
        {
            var res = await _vendorService.CreateVendor(ctrRespModel);

            return Ok(res);
        }

        [HttpPost(Name = "CreateVendorProducts")]
        public async Task<IActionResult> CreateVendorProducts([FromForm] VendorProductsModel ctrRespModel)
        {
            var res = await _vendorService.CreateVendorProducts(ctrRespModel);

            return Ok(res);
        }

        public async Task<IActionResult> GetVendorList()
        {
            var Vednors = await _vendorService.GetVendors();
            var VednorsList = Vednors.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList();

            return Json(VednorsList);
        }

        [HttpGet(Name = "GetVendorProductList")]
        public async Task<IActionResult> GetVendorProductList(int VendorId ,int CategoryId)
        {
            var VendorProducts = await _vendorService.GetVendorProducts(new VendorProductsModel() { CategoryId= CategoryId, VendorId= VendorId });

            return Json(VendorProducts);
        }

        [HttpGet(Name = "GetVendorDetail")]
        public async Task<IActionResult> GetVendorDetail()
        {
            var Vednors = await _vendorService.GetVendors();
            //var VednorsList = Vednors.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList();

            return Json(Vednors);
        }

    }
}
