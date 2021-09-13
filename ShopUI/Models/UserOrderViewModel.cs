using Shop.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopUI.Models
{
    public class UserOrderViewModel
    {
        public int OrderId { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public Address Address { get; set; }
    }
}
