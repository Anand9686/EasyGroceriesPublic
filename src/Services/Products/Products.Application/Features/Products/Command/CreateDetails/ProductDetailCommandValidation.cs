using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Application.Features.Products.Command.CreateDetails
{
    public class ProductDetailCommandValidation:AbstractValidator<ProductDetailsCommand>
    {
        public ProductDetailCommandValidation()
        {         
            RuleFor(p => p.ProductDetail.FirstOrDefault().ProductId)
                .NotEmpty().WithMessage("Selecct Product  from the list.")
                .GreaterThan(0).WithMessage("Selecct Product  from the list.");

            // .MaximumLength(50).WithMessage("{Name} must not exceed 50 characters.");
            RuleFor(p => p.ProductDetail.FirstOrDefault().CategoryId)
                   .NotEmpty().WithMessage("Selecct Category  from the list.")
                   .GreaterThan(0).WithMessage("Selecct Category  from the list.");

            RuleFor(p => p.ProductDetail.FirstOrDefault().VendorId)
               .NotEmpty().WithMessage("Selecct Vendor  from the list.")
               .GreaterThan(0).WithMessage("Selecct Vendor  from the list.");

            RuleFor(p => p.ProductDetail.FirstOrDefault().ProductVendorCode)
              .NotEmpty().WithMessage("Product Vendor Code isrequired.")
              .NotNull()
              .MaximumLength(10).WithMessage("{ProductVendorCode} must not exceed 10 characters.");

            RuleFor(p => p.ProductDetail.FirstOrDefault().ProductVendorName)
            .NotEmpty().WithMessage("Product Vendor Name isrequired.")
            .NotNull()
            .MaximumLength(50).WithMessage("{ProductVendorName} must not exceed 50 characters.");

            RuleFor(p => p.ProductDetail.FirstOrDefault().UnitId)
              .NotEmpty().WithMessage("Selecct Unit  from the list.")
              .GreaterThan(0).WithMessage("Selecct Unit  from the list.");

            RuleFor(p => p.ProductDetail.FirstOrDefault().Quantity)
             .NotEmpty().WithMessage("Enter valid Quantity.")
              .GreaterThan(0).WithMessage("Enter valid Quantity.");

            RuleFor(p => p.ProductDetail.FirstOrDefault().AvailableQuantity)
            .NotEmpty().WithMessage("Enter valid Availability Quantity.")
            .GreaterThan(0).WithMessage("Enter valid Availability Quantity.");

            RuleFor(p => p.ProductDetail.FirstOrDefault().StockArivalDate)
           .NotEmpty().WithMessage("Select valid Stock Arival Date.");

            RuleFor(p => p.ProductDetail.FirstOrDefault().DiscountEffectiveEndDate)
             .NotEmpty().WithMessage("Deiscount Effective Statt Date should be less than Discount Effective End Date")
             .GreaterThanOrEqualTo(p => p.ProductDetail.FirstOrDefault().DiscountEffectiveEndDate);

            //   RuleFor(p => p.Price)
            //      .NotEmpty().WithMessage("{Price} is required.");

        }
    }
}
