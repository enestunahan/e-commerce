using Shop.Business.Abstarct;
using Shop.DataAccess.Abstract;
using Shop.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Business.Concrete
{
    public class CartItemManager : ICartItemService
    {
        private ICartItemDal _cartItemDal;
        public CartItemManager(ICartItemDal cartItemDal)
        {
            _cartItemDal = cartItemDal;
        }
        public void DeleteFromCart(int cartid, int productid)
        {
            _cartItemDal.Delete(Get(cartid, productid));
        }
        public CartItem Get(int cartid , int productid)
        {
            return _cartItemDal.Get(filter: x => x.CartId == cartid & x.ProductId == productid);
        }
    }
}
