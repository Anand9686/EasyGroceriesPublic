using MediatR;

namespace Vendor.Application.Features.Commands.CreateVendor
{
    public class CreateVendorCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public bool Flag { get; set; }
    }
}
