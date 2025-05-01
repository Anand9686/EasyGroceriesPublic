using MediatR;
using System;

namespace Categories.Application.Features.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Units { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public int StockCount { get; set; }
        public int ReorderLevel { get; set; }
        public bool Flag { get; set; }
        public DateTime DiscountValidDate { get; set; }
        public string ImageName { get; set; }

        public string Unit { get; set; }
    }
}
