using Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;

namespace Repository.Implementations
{
    public class CountryRepository : Repository<Country>, ICountryRepository
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

        public CountryRepository(DbContext db) : base(db)
        {

        }

        #endregion
    }
}
