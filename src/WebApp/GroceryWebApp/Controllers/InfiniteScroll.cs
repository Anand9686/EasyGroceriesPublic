using GroceryWebApp.Model;
using GroceryWebApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryWebApp.Controller
{
    public class InfiniteScroll : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsModel(IProductService productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        public IEnumerable<ProductResponseModel> Products { get; set; } = new List<ProductResponseModel>();
        
        public ActionResult Index()
        {
           // Products = _productService.GetProducts();
            return PartialViewResult("_ProductItemPartial", Products);//return your partial view here
        }

        private ActionResult PartialViewResult(string v, IEnumerable<ProductResponseModel> products)
        {
            throw new NotImplementedException();
        }
    }
}
