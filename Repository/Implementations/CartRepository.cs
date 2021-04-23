using Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Implementations
{
    public class CartRepository : Repository<Cart>,ICartRepository
    {
        #region Properties

        public ApplicationDbContext _db
        {
            get
            {
                return db as ApplicationDbContext;
            }
        }

        #endregion

        #region Constructors

        public CartRepository(DbContext db) : base(db)
        {

        }


        #endregion

        #region Methods

        public Cart GetCart(Guid CartId)
        {
            return _db.Carts.Include("Items").Where(x => x.Id == CartId && x.IsActive == true).FirstOrDefault();

        }

        public int DeleteItem(Guid cartId, int itemId)
        {
            var item = _db.CartItems.Where(x => x.Cartid == cartId && x.Id == itemId).FirstOrDefault();
            if (item!=null)
            {
                _db.CartItems.Remove(item);
                return _db.SaveChanges();
            }
            else
            {
                return 0;
            }
        }

        public int UpdateQuantity(Guid CartId, int ItemId, int Quantity)
        {
            bool flag = false;
            var cart = GetCart(CartId);
            if (cart!=null)
            {
                for (int i = 0; i < cart.Items.Count; i++)
                {
                    if (cart.Items[i].Id == ItemId)
                    {
                        flag = true;
                        if (Quantity < 0 && cart.Items[i].Quantity > 1)
                            cart.Items[i].Quantity += (Quantity);
                        else if (Quantity > 0)
                            cart.Items[i].Quantity += (Quantity);
                        break;

                    }
                }
                if (flag)
                {
                    return _db.SaveChanges();
                }
            }
            return 0;
        }

        public int UpdateCart(Guid cartId, int userId)
        {
            Cart cart = GetCart(cartId);
            cart.UserId = userId;
            return _db.SaveChanges();
        }

        public CartModel GetCartDetails(Guid CartId)
        {
            var model = (from cart in _db.Carts
                         where cart.Id == CartId & cart.IsActive == true
                         select new CartModel
                         {
                             Id = cart.Id,
                             UserId = cart.UserId,
                             CreatedDate = cart.CreatedTime,
                             Items = (from cartitem in _db.CartItems
                                      join item in _db.Products
                                      on cartitem.ProductId equals item.Productid
                                      select new ProductModel
                                      { 
                                          Id = cartitem.Id,
                                          ProductName = item.ProductName,
                                          Description = item.Description,
                                          ImageUrl = item.ImageUrl,
                                          Quantity = cartitem.Quantity,
                                          Productid = item.Productid,
                                          UnitPrice = cartitem.UnitPrice
                                      }).ToList()
                         }).FirstOrDefault();
            return model;
        }


        #endregion


    }
}
