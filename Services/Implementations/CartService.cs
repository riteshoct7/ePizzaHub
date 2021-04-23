using Entities;
using Repository.Interfaces;
using Repository.Models;
using Services.Interfaces;
using System;
using System.Linq;

namespace Services.Implementations
{
    public class CartService : ICartService
    {

        #region Properties

        ICartRepository cartRepository;
        ICartItemRepository cartItemRepository;

        #endregion

        #region Constructors

        public CartService(ICartRepository cartRepository, ICartItemRepository cartItemRepository)
        {
            this.cartRepository = cartRepository;
            this.cartItemRepository = cartItemRepository;
        }

        #endregion

        #region Methods

        public Cart AddItem(int UserId, Guid CartId, int ItemId, decimal UnitPrice, int Quantity)
        {
            try
            {
                Cart cart = cartRepository.GetCart(CartId);
                if (cart == null )
                {
                    cart = new Cart();
                    CartItem item = new CartItem(ItemId, Quantity, UnitPrice);
                    cart.Id = CartId;
                    cart.UserId = UserId;
                    cart.CreatedTime = DateTime.Now;

                    item.Cartid = cart.Id;
                    cart.Items.Add(item);
                    cartRepository.Add(cart);
                    cartRepository.SaveChanges();
                }
                else
                {
                    CartItem item = cart.Items.Where(x => x.ProductId == ItemId).FirstOrDefault();
                    if (item != null)
                    {
                        item.Quantity += Quantity;
                        cartItemRepository.Update(item);
                        cartItemRepository.SaveChanges();
                    }
                    else
                    {
                        item = new CartItem(ItemId, Quantity, UnitPrice);
                        item.Cartid = cart.Id;
                        cart.Items.Add(item);

                        cartItemRepository.Add(item);
                        cartItemRepository.SaveChanges();
                    }
                }
                return cart;
            }
            catch (Exception)
            {
                return null;                
            }
        }

        public int DeleteItem(Guid cartId, int itemId)
        {
            return cartRepository.DeleteItem(cartId, itemId);
        }

        public int GetCartCount(Guid cartId)
        {
            var cart = cartRepository.GetCart(cartId);
            return cart != null ? cart.Items.Count() : 0;
        }

        public CartModel GetCartDetails(Guid CartId)
        {
            var model = cartRepository.GetCartDetails(CartId);
            if (model !=null && model.Items.Count > 0 )
            {
                decimal subTotal = 0;
                foreach (var item in model.Items)
                {
                    item.Total = item.UnitPrice * item.Quantity;
                    subTotal += item.Total;
                }
                model.Total = subTotal;
                //5%Tax
                model.Tax = Math.Round((model.Total * 5) / 100, 2);
                model.GrandTotal = model.Total + model.Tax;
            }
            return model;
        }

        public int UpdateCart(Guid cartId, int userId)
        {
            return cartRepository.UpdateCart(cartId, userId);
        }

        public int UpdateQuantity(Guid CartId, int ItemId, int Quantity)
        {
            return cartRepository.UpdateQuantity(CartId, ItemId, Quantity);
        }

        public Cart GetCart(Guid CartId)
        {            
            return cartRepository.GetCart(CartId);
        }            

        #endregion

    }
}
