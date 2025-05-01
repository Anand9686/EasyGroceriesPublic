using GroceryWebApp.Pages.Categories.Model;
using GroceryWebApp.Pages.Categories.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace GroceryWebApp.Controllers.Catogries
{
    public class CreateCategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CreateCategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
        }

        public async Task<IActionResult> Index()
        {
            var Categories = await _categoryService.GetCategories();
            var CategoryList = Categories.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.CategoryName }).ToList();
          //  ViewBag["CategoryList"] = CategoryList;
            return Json(CategoryList);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewCategory([FromForm] CategoryResponseModel ctrRespModel)
        {
            var res = await _categoryService.CreateCategories(ctrRespModel);

            return Ok(res);
        }

        [HttpPost(Name = "CreateCategoryProducts")]
        public async Task<IActionResult> CreateCategoryProducts([FromForm] CategoryProductsModel ctrRespModel)
        {
            var res = await _categoryService.CreateCategoryProducts(ctrRespModel);

            return Ok(res);
        }

        [HttpGet(Name = "GetAllCategories")]
        public async Task<IActionResult> GetAllCategories()
        {
            var Categories = await _categoryService.GetCategories();
            
            return Json(Categories);
            
        }

        [HttpPost(Name = "CreateCategory")]
        public async Task<IActionResult> CreateCategorys([FromBody]CategoryResponseModel ctrRespModel)
        {
            var res = await _categoryService.CreateCategories(ctrRespModel);

            return Ok(res);
        }
    }
}
