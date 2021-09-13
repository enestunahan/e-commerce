using Shop.Business.Abstarct;
using Shop.DataAccess.Abstract;
using Shop.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private IOrderDal _orderDal;
        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }
        public Order AddOrder(Order order)
        {            
            return _orderDal.Add(order);
        }

        public List<Order> Orders(string userid)
        {
            return _orderDal.GetOrderDetail(userid);
        }
    }
}
