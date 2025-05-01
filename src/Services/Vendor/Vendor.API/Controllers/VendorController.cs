using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Vendor.Application.Features.Commands.CreateVendor;
using Vendor.Application.Features.Vendor.Command.CreateVendorProducts;
using Vendor.Application.Features.Vendor.Query.GetVendorList;
using Vendor.Application.Features.Vendor.Query.GetVendorProdList;

namespace Vendor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VendorController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet(Name = "GetVendors")]
        [ProducesResponseType(typeof(IEnumerable<VendorList>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<VendorList>>> GetVendors()
        {
            var query = new GetVendorListQuery();
            var vendors = await _mediator.Send(query);
            return Ok(vendors);
        }

        [HttpGet]
        [Route("GetVendor/{vendorid}")]
        [ProducesResponseType(typeof(IEnumerable<VendorList>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<VendorList>>> GetVendor(int vendorid)
        {
            var query = new GetVendorListQuery(vendorid);
            var vendors = await _mediator.Send(query);
            return Ok(vendors.FirstOrDefault<VendorList>());
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateProduct([FromBody] CreateVendorCommand command)
        {
            var res = await _mediator.Send(command);

            return Ok(res);
        }

        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateVendorProducts([FromBody] VendorProductsCommand command)
        {
            var res = await _mediator.Send(command);

            return Ok(res);
        }

        [Route("[action]")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<VendorProdList>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<VendorProdList>>> GetVendorProducts([FromQuery] GetVendorProdListQuery command)
        {
            var res = await _mediator.Send(command);

            return Ok(res);
        }
    }
}
