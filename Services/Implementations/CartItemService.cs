using Repository.Interfaces;
using Services.Interfaces;

namespace Services.Implementations
{
    public class CartItemService : ICartItemService
    {
        #region Properties

        ICartRepository cartRepository;
        ICartItemRepository cartItemRepository; 

        #endregion

        #region Constructors

        public CartItemService(ICartRepository cartRepository, ICartItemRepository cartItemRepository)
        {
            this.cartRepository = cartRepository;
            this.cartItemRepository = cartItemRepository;
        } 
        #endregion
    }
}
