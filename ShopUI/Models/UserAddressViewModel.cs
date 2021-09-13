using Shop.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopUI.Models
{
    public class UserAddressViewModel
    {
        public List<Address> Addresses { get; set; }
        public string AddressTitle { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string OpenAddress { get; set; }
    }
}
