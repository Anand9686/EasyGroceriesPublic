using Categories.Application.Features.Commands.CreateProduct;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Products.Application.Features.Products.Command.CreateDetails;
using Products.Application.Features.Products.Command.UpdateQtyForCheckout;
using Products.Application.Features.Products.Query;
using Products.Application.Features.Products.Query.GetProductDetails;
using Products.Application.Features.Products.Query.GetProductDetailsById;
using Products.Application.Features.Products.Query.GetProductList;
using Products.Application.Features.Products.Query.GetScrollContent;
using Products.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Products.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet(Name = "GetProducts")]
        [ProducesResponseType(typeof(IEnumerable<ProductList>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ProductList>>> GetProducts()
        {
            var query = new GetProductListQuery();
            var products = await _mediator.Send(query);
            return Ok(products);
        }

        [HttpGet]
        [Route("GetProducts/{productid}")]
        [ProducesResponseType(typeof(IEnumerable<ProductList>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ProductList>>> GetProducts(int productid)
        {
            var query = new GetProductListQuery(productid);
            var products = await _mediator.Send(query);
            return Ok(products.FirstOrDefault<ProductList>());
        }

        [HttpGet]
        [Route("GetProductsByCategory/{categoryId}")]
        [ProducesResponseType(typeof(IEnumerable<ProductList>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ProductList>>> GetProductsByCategory(int categoryId)
        {
            var query = new GetProductsByCategoryQuery(categoryId);
            var products = await _mediator.Send(query);
            return Ok(products);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateProduct([FromBody] CreateProductCommand command)
        {
            var res = await _mediator.Send(command);

            return Ok(res);
        }

        [HttpGet]
        [Route("GetScrollContent/{page}/{size}")]
        [ProducesResponseType(typeof(IEnumerable<GetScrollProductDetails>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<GetScrollProductDetails>>> GetScrollContent(int page,int size)
        {
            var query = new GetScrollContentQuery(page,size);
            var products = await _mediator.Send(query);
            return Ok(products);
        }


        [HttpPost]
        [Route("CreateProductDetails")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateProductDetails([FromBody] ProductDetailsCommand command)
        {
            var res = 0;
            try
            {
                res = await _mediator.Send(command);
            }
            catch
            {
                throw;
            }

            return Ok(res);
        }

        [HttpGet]
        [Route("GetProductDetail/{productId}/{caategoryId}/{vendorId}")]
        [ProducesResponseType(typeof(IEnumerable<ProductList>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ProductDetails>>> GetProductDetail(int productId, int caategoryId, int vendorId)
        {
            var query = new Application.Features.Products.Query.GetProductDetail.ProductDetailQuery(productId, caategoryId,vendorId);
            var products = await _mediator.Send(query);
            return Ok(products);
        }

        [HttpGet]
        [Route("GetProductDetails")]
        [ProducesResponseType(typeof(IEnumerable<ProductDetails>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ProductDetails>>> GetProductDetails()
        {
            var query = new ProductDetailsQuery();
            var products = await _mediator.Send(query);
            return Ok(products);
        }

        [HttpGet]
        [Route("GetProductDetailsById/{productDetailId}")]
        [ProducesResponseType(typeof(ProductDetails), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductDetails>> GetProductDetailsById(int productDetailId)
        {
            var query = new ProductDetailsByIdQuery(productDetailId);
            var product = await _mediator.Send(query);
            return Ok(product);
        }

        [HttpPost]
        [Route("UpdateProductQuantityForChecout")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> UpdateProductQuantityForChecout([FromBody] ProdUpdQtyCommand command)
        {
            var res = 0;
            try
            {
                res = await _mediator.Send(command);
            }
            catch
            {
                throw;
            }

            return Ok(res);
        }

    }
}
