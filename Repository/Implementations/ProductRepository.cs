using Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;

namespace Repository.Implementations
{
    public class ProductRepository :Repository<Products>,IProductRepository
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

        public ProductRepository(DbContext db) : base(db)
        {

        }

        #endregion
    }
}
