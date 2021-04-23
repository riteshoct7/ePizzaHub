using Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;

namespace Repository.Implementations
{

    public class CartItemRepository : Repository<CartItem>, ICartItemRepository
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

        public CartItemRepository(DbContext db) : base(db)
        {

        }


        #endregion
    }
}
