using Repository.Interfaces;
using Services.Interfaces;

namespace Services.Implementations
{
    public class OrderItemService : IOrderItemService
    {
        #region Properties
        IOrderItemRepository orderItemRepository;
        #endregion

        #region Methods
        public OrderItemService(IOrderItemRepository orderItemRepository)
        {
            this.orderItemRepository = orderItemRepository;
        } 
        #endregion

    }
}
