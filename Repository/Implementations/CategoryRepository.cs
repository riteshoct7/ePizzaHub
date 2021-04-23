using Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System.Linq;

namespace Repository.Implementations
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
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

        public CategoryRepository(DbContext db) : base(db)
        {

        }

        #endregion

        #region Methods

        public Category GetCategoryByDescription(string description)
        {
            return _db.Categories.Where(x => x.Description == description).FirstOrDefault();
        }

        public Category GetCategoryByName(string catgeoryName)
        {
            return _db.Categories.Where(x => x.CategoryName == catgeoryName).FirstOrDefault();
        } 

        #endregion

    }
}
