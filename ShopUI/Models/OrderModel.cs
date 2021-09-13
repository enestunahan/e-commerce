using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopUI.Models
{
    public class OrderModel
    {
        public int Addressid { get; set; }
        public string NameOnTheCard { get; set; }
        public string CardNumber { get; set; }
        public DateTime CardExpirationDate { get; set; }
        public string CardCvc { get; set; }
    }
}
