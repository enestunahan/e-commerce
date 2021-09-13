using Shop.Business.Abstarct;
using Shop.DataAccess.Abstract;
using Shop.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Business.Concrete
{
    public class OrderItemManager : IOrderItemService
    {
        private IOrderItemDal _orderItemDal;
        public OrderItemManager(IOrderItemDal orderItemDal)
        {
            _orderItemDal = orderItemDal;
        }
        public void Add(OrderItem orderItem)
        {
            _orderItemDal.Add(orderItem);
        }
    }
}
