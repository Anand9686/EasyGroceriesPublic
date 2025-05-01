using Login.Domain.Common;
using System;

namespace Login.Domain.Entities
{
    public class User : EntityBase
    {
        public string Mobile { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DOB { get; set; }
    }
}
