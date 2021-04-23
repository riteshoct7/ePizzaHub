using Entities;
using Repository.Models;
using System;

namespace Repository.Interfaces
{
    public interface ICartRepository : IRepository<Cart>
    {
        #region Methods

        Cart GetCart(Guid CartId);

        CartModel GetCartDetails(Guid CartId);

        int DeleteItem(Guid cartId, int itemId);

        int UpdateQuantity(Guid CartId, int ItemId, int Quantity);

        int UpdateCart(Guid cartId, int userId); 

        #endregion

    }
}
