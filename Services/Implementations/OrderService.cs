using Repository.Interfaces;
using Services.Interfaces;

namespace Services.Implementations
{
    public class OrderService : IOrderService
    {
        #region Properties
        IOrderRepository orderRepository;
        #endregion

        #region Constructors
        public OrderService(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        } 
        #endregion

    }
}
