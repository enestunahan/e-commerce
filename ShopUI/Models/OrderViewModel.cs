using Shop.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopUI.Models
{
    public class OrderViewModel
    {
       public List<Address> Addresses { get; set; }
       //public List<CartItemModel> CartItemModels { get; set; }
       public List<OrderItemModel> OrderItemModels { get; set; }
       public double TotalPrice
        {
            get
            {
                return OrderItemModels.Sum(x => x.TotalPrice);
            }
        }
    }
}
