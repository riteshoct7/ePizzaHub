using Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;

namespace Repository.Implementations
{
    public class OrderItemRepository : Repository<OrderItem>, IOrderItemRepository
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

        public OrderItemRepository(DbContext db) : base(db)
        {

        }


        #endregion
    }
}
