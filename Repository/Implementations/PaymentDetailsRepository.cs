using Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;

namespace Repository.Implementations
{
    public class PaymentDetailsRepository :Repository<PaymentDetails>,IPaymentDetailsRepository
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

        public PaymentDetailsRepository (DbContext db) : base(db)
        {

        }


        #endregion

    }
}
