
namespace Products.Grpc.Entities
{
    public class ProdUpdQtyCommand 
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
