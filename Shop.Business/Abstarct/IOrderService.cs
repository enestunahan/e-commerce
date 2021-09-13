using Shop.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Business.Abstarct
{
   public interface IOrderService
    {
        Order AddOrder(Order order);
        List<Order> Orders(string userid);
    }
}
