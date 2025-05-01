using GroceryWebApp.Pages.Products.Model;
using GroceryWebApp.Pages.Products.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
//using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using GroceryWebApp.Pages.Utils.Services;

namespace GroceryWebApp.Controllers.Products
{
   // [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductController> _logger;
        private readonly IUtilsService _utilsService;
        public ProductController(IProductService productService, IUtilsService utilsService, ILogger<ProductController> logger)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
            _utilsService = utilsService ?? throw new ArgumentNullException(nameof(utilsService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewProduct([FromForm] ProductResponseModel ctrRespModel)
        {
            var res = await _productService.CreateProduct(ctrRespModel);
            _logger.LogInformation("Products Pulled");
            return Ok(res);
        }

        [HttpPost(Name = "GetScrollContent")]
        public async Task<IActionResult> GetScrollContent(int page, int size)
        {
            var res = await _productService.GetScrollContent(page, size);
            _logger.LogInformation("Products Pulled");
            //return new PartialViewResult()
            //{
            //    ViewName= "~/Pages/Products/UI/Partial/_ScrollForMorePartial.cshtml", 
            //    ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
            //    {
            //        Model = res,
            //    }
            //}; 
            return PartialView("~/Pages/Products/UI/Partial/_ScrollForMorePartial.cshtml", res);
        }

        [HttpGet(Name = "GetScrollContent")]
        public async Task<IActionResult> GetScrollContent(int productId)
        {
            var Products = await _productService.GetProductDetailsById(productId);
            //  var ProductsList = Products.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = (c.Name + " - " + c.Unit) }).ToList();
            _logger.LogInformation("Products Details Item Pulled");
            return View(Products);
        }

        public async Task<IActionResult> GetProducts()
        {
            var Products = await _productService.GetProducts();
            var ProductsList = Products.Select(c => new SelectListItem { Value = c.Id.ToString(), Text =c.Name}).ToList();
            _logger.LogInformation("Products Pulled");
            return Json(ProductsList);
        }
        [HttpGet(Name = "GetProductsByCategory")]
        public async Task<IActionResult> GetProductsByCategory(int categoryId)
        {
            
            var roles = ((ClaimsIdentity)User.Identity).Claims
            .Where(c => c.Type == ClaimTypes.Role)
            .Select(c => c.Value);
            var Products = await _productService.GetProductsByCategory(categoryId);
            var ProductsList = Products.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = (c.Name + " - " + c.Unit) }).ToList();
            _logger.LogInformation("Products Pulled");
            return Json(ProductsList);
        }

        [HttpPost(Name = "CreateProductDetails")]
        public async Task<IActionResult> CreateProductDetails([FromBody]ProductDetails prodDetails)
        {
            foreach(var item in prodDetails.ProductDetail)
            {
                var itemDetail = await _utilsService.GetUnitDetailById(item.UnitDetailId1);
                item.UnitDetailDesc = itemDetail.UnitDescription;
            }
           var res = await _productService.CreateProductDetails(prodDetails);
            _logger.LogInformation("Products Pulled");
            return Ok(res);
        }

        [HttpGet(Name = "GetProductsDetail")]
        public async Task<IActionResult> GetProductsDetail(int productId,int categoryId, int vendorId)
        {
            var Products = await _productService.GetProductsDetail(productId,categoryId, vendorId);
            //  var ProductsList = Products.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = (c.Name + " - " + c.Unit) }).ToList();
            _logger.LogInformation("Products Pulled");
            return Json(Products);
        }

        [HttpGet(Name = "GetProductDetails")]
        public async Task<IActionResult> GetProductDetails()
        {
            var Products = await _productService.GetProductDetails();
            //  var ProductsList = Products.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = (c.Name + " - " + c.Unit) }).ToList();
            _logger.LogInformation("Product Details List Pulled");
            return Json(Products);
        }

        [HttpGet(Name = "GetProductDetailsById")]
        public async Task<IActionResult> GetProductDetailsById(int productDetailId)
        {
            var Products = await _productService.GetProductDetailsById(productDetailId);
            //  var ProductsList = Products.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = (c.Name + " - " + c.Unit) }).ToList();
            _logger.LogInformation("Products Details Item Pulled");
            return Json(Products);
        }

        [HttpGet(Name = "GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            var Products = await _productService.GetProducts();
            _logger.LogInformation("Products Pulled");
            return Json(Products);
        }
    }
}
