using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopUI.Models
{
    public class CartViewModel
    {
       public int CartId { get; set; }
       public List<CartItemModel> CartItemModels { get; set; }
       public decimal TotalPrice
        {
            get
            {
                return (decimal)CartItemModels.Sum(x => x.Price * x.Quantity);
            }
        }
    }
}
