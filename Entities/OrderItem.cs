namespace Entities
{
    public class OrderItem
    {
        #region Constructors
        private OrderItem()
        {

        }
        public OrderItem(int ProductId, decimal unitPrice, int quanity, decimal total)
        {
            this.ProductId = ProductId;
            this.UnitPrice = unitPrice;
            this.Quantity = quanity;
            this.Total = total;
        }
        #endregion

        #region Properties
        public int Id { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }

        public string OrderId { get; set; }

        public virtual Order Order { get; set; } 
        #endregion
    }
}
