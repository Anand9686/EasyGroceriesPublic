using Vendor.Domain.Common;
using System;

namespace Vendor.Domain.Entites
{
    public class VendorInfo :EntityBase 
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public bool Flag { get; set; }

    }
}
