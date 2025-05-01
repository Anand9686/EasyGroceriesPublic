using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using GUD=Utils.Application.Features.Query.GetUnitDetail;
using GUDById = Utils.Application.Features.Query.GetUnitDetailById;
using Utils.Application.Features.Query.GetUnitList;
using U=Utils.Domain.Entities;

namespace Utils.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UnitController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet(Name = "GetUnits")]
        [ProducesResponseType(typeof(IEnumerable<UnitLists>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<UnitLists>>> GetUnits()
        {
            var query = new GetUnitListQuery();
            var units = await _mediator.Send(query);
            return Ok(units);
        }

        [HttpGet]
        [Route("GetUnitDetail/{unitId}")]
        [ProducesResponseType(typeof(IEnumerable<GUD.UnitDetail>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<GUD.UnitDetail>>> GetUnitDetail(int unitId)
        {
            var query = new GUD.GetUnitDetailQuery(unitId);
            var units = await _mediator.Send(query);
            return Ok(units);
        }

        [HttpGet]
        [Route("GetUnitDetailById/{unitDetailId}")]
        [ProducesResponseType(typeof(GUDById.UnitDetailById), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GUDById.UnitDetailById>> GetUnitDetailById(int unitDetailId)
        {
            var query = new GUDById.GetUnitDetailByIdQuery(unitDetailId);
            var units = await _mediator.Send(query);
            return Ok(units);
        }

    }
}
