using Shop.Business.Abstarct;
using Shop.DataAccess.Abstract;
using Shop.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Business.Concrete
{
    public class CartManager : ICartService
    {
        private ICartDal _cartDal;
        public CartManager(ICartDal cartDal)
        {
            _cartDal = cartDal;
        }

        public void AddToCard(string userid, int quantity, int productid)
        {
            var cart = GetByUserIdCard(userid);
            var index = cart.CartItems.FindIndex(x => x.ProductId == productid);
            if (index < 0)
            {
                cart.CartItems.Add(new CartItem()
                {
                    ProductId = productid,
                    Quantity = quantity,
                    CartId = cart.Id,
                });
            }
            else
            {
                cart.CartItems[index].Quantity += quantity;
            }
            _cartDal.Update(cart);
        }

        public void DeleteFromCart(string userid, int productid)
        {
            var cart = GetByUserIdCard(userid);
            //var deletedcart = cart.CartItems.Find(x => x.ProductId == productid);
            var id = cart.CartItems.FindIndex(x => x.ProductId == productid);
            cart.CartItems.Remove(new CartItem { Id = id });
            
            _cartDal.Update(cart);
        }

        public Cart GetByCartId(int cartid)
        {
            return _cartDal.GetByCartId(cartid);
        }

        public Cart GetByUserIdCard(string userid)
        {
            return _cartDal.GetByUserId(userid);
        }

        public int GetTheCount(Cart cart)
        {
            return _cartDal.GetCartCountItem(cart);
        }

        public void InitializeCard(string userid)
        {
            _cartDal.Add(new Cart { UserId = userid });
        }
    }
}
