using System;
using System.Text.Json.Serialization;

namespace Entities
{
    public class CartItem
    {
        #region Constructors
        public CartItem()
        {

        }
        public CartItem(int productId, int quantity, decimal unitPrice)
        {
            ProductId = productId;
            UnitPrice = unitPrice;
            Quantity = quantity;
        } 
        #endregion

        #region Properties
        public int Id { get; set; }
        public Guid Cartid { get; set; }
        public int ProductId { get; set; }

        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        [JsonIgnore]
        public Cart Cart { get; set; } 
        #endregion

    }
}
