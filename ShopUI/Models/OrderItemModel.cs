using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopUI.Models
{
    public class OrderItemModel
    {
        public int ProductId { get; set; }       
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public double TotalPrice
        {
            get
            {
                return Price * Quantity;
            }
        }

    }
}
