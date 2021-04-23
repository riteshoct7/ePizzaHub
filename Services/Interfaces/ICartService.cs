using Entities;
using Repository.Models;
using System;

namespace Services.Interfaces
{
    public interface ICartService
    {
        #region Methods

        int GetCartCount(Guid cartId);

        CartModel GetCartDetails(Guid CartId);

        Cart GetCart(Guid CartId);

        Cart AddItem(int UserId, Guid CartId, int ItemId, decimal UnitPrice, int Quantity);

        int DeleteItem(Guid cartId, int itemId);

        int UpdateQuantity(Guid CartId, int ItemId, int Quantity);

        int UpdateCart(Guid cartId, int userId);

        #endregion
    }
}
