using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Application.Features.Products.Command.UpdateQtyForCheckout
{
    public class ProdUpdQtyCommand : IRequest<int>
    {
        public int ProductDetailsId { get; set; }
        public int Quantity { get; set; }
        public bool IsCheckOut { get; set; } = false;

        public ProdUpdQtyCommand(int productDetailsId, int quantity, bool isCheckOut)
        {
            ProductDetailsId = productDetailsId;
            Quantity = quantity;
            IsCheckOut = isCheckOut;
        }
    }
}
