using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Categories.Application.Features.Categories.Query.GetCategoryList;
using MediatR;
using System.Net;
using Categories.Application.Features.Commands.CreateCategory;
using Categories.API.GrpcService;
using Products.Grpc.Protos;
using Categories.Application.Features.Categories.Command.CreateCategoryProducts;

namespace Categories.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ProductGrpcService _productGrpcService;

        public CategoriesController(IMediator mediator, ProductGrpcService productGrpcService)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _productGrpcService = productGrpcService ?? throw new ArgumentNullException(nameof(productGrpcService));
        }

        [HttpGet(Name = "GetCategories")]
        [ProducesResponseType(typeof(IEnumerable<CategoryList>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<CategoryList>>> GetCategories()
        {
            var query = new GetCategoryListQuery();
            var categories = await _mediator.Send(query);
            return Ok(categories);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateCategory([FromBody] CreateCategoryCommand command)
        {
            var res = await _mediator.Send(command);

            return Ok(res);
        }

        [Route("[action]")]
        [HttpGet]
        [ProducesResponseType(typeof(ProductsCategoryResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductsCategoryResponse>> GetCategoryProducts(int CategoryId)
        {

            var categories = await _productGrpcService.GetCategoryProducts(CategoryId);
            return Ok(categories);
        }

        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateCategoryProducts([FromBody] CategoryProductsCommand command)
        {
            var res = await _mediator.Send(command);

            return Ok(res);
        }
    }
}
