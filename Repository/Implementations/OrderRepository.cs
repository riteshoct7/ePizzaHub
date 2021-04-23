using Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;

namespace Repository.Implementations
{
    public class OrderRepository : Repository<Order>, IOrderRepository
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

        public OrderRepository(DbContext db) : base(db)
        {

        }


        #endregion
    }
}
