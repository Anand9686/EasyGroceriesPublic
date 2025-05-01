using AutoMapper;
using Basket.API.GrpcService;
using Basket.Application.Features.Baskets.Query.GetBasketList;
using Basket.Application.Features.Baskets.Query.GetBookedCheckourItems;
using Basket.Application.Features.Baskets.Query.GetBookingHistory;
using Basket.Application.Features.Baskets.Query.GetBookingId;
using Basket.Application.Features.Commands.BookCheckoutItesm;
using Basket.Application.Features.Commands.CheckOut;
using Basket.Application.Features.Commands.Create;
using Basket.Application.Features.Commands.Delete;
using Basket.Application.Features.Commands.GetBookedCheckourItems;
using Basket.Application.Features.Commands.RollBackCheckoutItems;
using Basket.Application.Features.Commands.UpdateBasketUserId;
using Basket.Application.Persistance;
using Basket.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Products.Grpc.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Basket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
      //  private readonly IBasketRepository _repository;
        private readonly IMapper _mapper;
        private readonly ProductGrpcService _productGrpcService;
        private readonly IMediator _mediator;
        public BasketController(IMediator mediator, IMapper mapper, ProductGrpcService productGrpcService)
        {
           // _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _productGrpcService = productGrpcService ?? throw new ArgumentNullException(nameof(productGrpcService));
        }

        [HttpGet("{basketid}", Name = "GetBasket")]
        [ProducesResponseType(typeof(BasketEnt), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<BasketShopping>> GetBasket(string basketid)
        {
            var query = new GetBasketListQuery(basketid);
            var basket = await _mediator.Send(query);
           // var basket = await _repository.GetBasket(basketid);
            var basketShopping = new BasketShopping(basketid);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BasketProductItem, ProductsModel>().ReverseMap();
                cfg.CreateMap<BasketProductItem, ProductDetailsModel>().ReverseMap();
                cfg.CreateMap<BasketEnt, BasketProductItem>();
                cfg.CreateMap<BasketList, BasketProductItem>();
            });
            var mapper = new Mapper(config);

            foreach (var item in basket) 
            {
               var product  = await _productGrpcService.GetProductDetail(item.ProductDetailId);
              
                var basketitem = mapper.Map<BasketProductItem>(product);
                basketitem = mapper.Map(item, basketitem);
                basketShopping.Items.Add(basketitem);
            }
            
            return Ok(basketShopping);
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<string> CreateOrUpdateBasket([FromBody] BasketCommand basket)
        {
           // var query = new BasketCommand(basketid);
            var response = await _mediator.Send(basket);
            //BasketEnt bskent = _mapper.Map<BasketEnt>(basket);
            //var response = await _repository.CreateOrUpdateBasket(bskent);
            return response.ToString();
        }

        [HttpDelete("{userid}/{productdetailid}", Name = "DeleteBasket")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteBasket(string userid, string productdetailid = "")
        {
            var command = new BasketDelCommand(userid, productdetailid);
            var response = await _mediator.Send(command);
            //await _repository.DeleteBasket(basketId, basketItem);
            return Ok();
        }

        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Checkout([FromBody] CheckOutCommand basketCheckout)
        {

            var response = await _mediator.Send(basketCheckout);

            //var config = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<BasketCheckout, BookedBasketCheckout>().ReverseMap();
            //    cfg.CreateMap<BookingHistory, BookItemsForCheckOut>().ReverseMap();
            //});
            //var mapper = new Mapper(config);

            //var basketitem = mapper.Map<BasketCheckout>(basketCheckout);
            // await _repository.CheckoutBasket(basketitem);

            //foreach(var item in basketCheckout.BasketItems)
            //{
            //    var basketitemHistory = mapper.Map<BookingHistory>(item);
            //    basketitemHistory.CheckOutId = basketitem.Id;
            //}

            // get existing basket with total price            
            // Set TotalPrice on basketCheckout eventMessage
            // send checkout event to rabbitmq/kafka
            // remove the basket

            // get existing basket with total price
            //var basket = await _repository.GetBasket(basketCheckout.UserId);
            //if (basket == null)
            //{
            //    return BadRequest();
            //}

            ////// send checkout event to rabbitmq/kafka
            ////var eventMessage = _mapper.Map<BasketCheckoutEvent>(basketCheckout);
            ////eventMessage.TotalPrice = basket.TotalPrice;
            ////await _publishEndpoint.Publish<BasketCheckoutEvent>(eventMessage);
            ////complete the paymnet and clear the basket
            //// remove the basket
            //await _repository.DeleteBasket(basketCheckout.BasketID, "");

            return Accepted();
        }

        [Route("BookItemsForCheckOut")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> BookItemsForCheckOut([FromBody] BookChkItmsCommand basketCheckoutItems)
        {
            int response = 0;
            ProdUpdQtyResponse grpcresp = null;
            try
            {
                response = await _mediator.Send(basketCheckoutItems);
                if (response == 1)
                {
                    var grpcProdQtyUpdReq = new GetProdUpdQtyRequest();
                    grpcProdQtyUpdReq.Productdetailid = basketCheckoutItems.ProductDetailId;
                    grpcProdQtyUpdReq.Quantity = basketCheckoutItems.Quantity;
                    grpcProdQtyUpdReq.Ischeckout = true;
                    grpcresp = await _productGrpcService.UpdateProductQuantityForChecout(grpcProdQtyUpdReq);
                }
            }
            catch
            {
               if(response == 1 && grpcresp== null)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<RollBackChkItmsCommand, BookChkItmsCommand>().ReverseMap();
                    });
                    var mapper = new Mapper(config);
                    var rollbackbasketitem = mapper.Map<RollBackChkItmsCommand>(basketCheckoutItems);
                    await _mediator.Send(rollbackbasketitem);
                    // basketCheckoutItems = basketCheckoutItems.
                    // await _mediator.Send(basketCheckoutItems);
                    //Roll back the items reserved for check out
                }
            }
           
            return Ok(response);
        }


        [HttpGet]
        [Route("GetBookedChkItems/{userid}")]
        [ProducesResponseType(typeof(GetBookedChkItmsList), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<GetBookedChkItmsList>>> GetBookedChkItems(string userid)
        {
            var query = new GetBookedChktItmesQuery(userid);
            var basket = await _mediator.Send(query);
           
            return Ok(basket);
        }

        [HttpGet]
        [Route("GetBookingHistory/{orderid}")]
        [ProducesResponseType(typeof(BasketEnt), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<BookingHistoryList>>> GetBookingHistory(string orderid)
        {
            var query = new BookingHistoryQuery(orderid);
            var basket = await _mediator.Send(query);

            return Ok(basket);
        }

        [HttpGet]
        [Route("GetUserOrders/{userid}")]
        [ProducesResponseType(typeof(GetBookingIdList), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<GetBookingIdList>>> GetUserOrders(string userid)
        {
            var query = new GetBookingIdQuery(userid);
            var userOrders = await _mediator.Send(query);

            return Ok(userOrders);
        }

        [HttpPost]
        [Route("UpdateBasketUserId")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<string> UpdateBasketUserId([FromBody] BasketUserIdCommand basket)
        {
            // var query = new BasketCommand(basketid);
            var response = await _mediator.Send(basket);
            //BasketEnt bskent = _mapper.Map<BasketEnt>(basket);
            //var response = await _repository.CreateOrUpdateBasket(bskent);
            return response.ToString();

        }
    }
}
