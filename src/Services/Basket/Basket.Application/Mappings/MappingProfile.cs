using AutoMapper;
using Basket.Application.Features.Baskets.Query.GetBasketList;
using Basket.Application.Features.Baskets.Query.GetBookingHistory;
using Basket.Application.Features.Baskets.Query.GetBookingId;
using Basket.Application.Features.Commands.BookCheckoutItesm;
using Basket.Application.Features.Commands.CheckOut;
using Basket.Application.Features.Commands.Create;
using Basket.Application.Features.Commands.Delete;
using Basket.Application.Features.Commands.GetBookedCheckourItems;
using Basket.Domain.Entities;

namespace Basket.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BasketEnt, BasketList>().ReverseMap();
            CreateMap<BasketEnt ,BasketCommand> ().ReverseMap();
            CreateMap<BasketEnt, BasketDelCommand>().ReverseMap();
            CreateMap<BookItemsForCheckOut, BookChkItmsCommand>().ReverseMap();
            CreateMap<BookItemsForCheckOut, GetBookedChkItmsList>().ReverseMap();
            CreateMap<BasketCheckout, CheckOutCommand>().ReverseMap();
            CreateMap<BookingHistory, BookItemsForCheckOut>().ReverseMap();
            CreateMap<BasketProductItem, BasketCommand>().ReverseMap();
            CreateMap<BookingHistory, BookingHistoryList>().ReverseMap();
            CreateMap<BasketCheckout, GetBookingIdList>().ReverseMap();

            

        }
    }
}
