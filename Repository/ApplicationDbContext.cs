using Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int>
    {
        #region Constructors
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> db) : base(db)
        {

        }
        #endregion

        #region Methods
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer(@"Data Source=RITESHPC\SQLEXPRESS;Initial Catalog=DailyCrud;User ID=sa;Password=software123");
                //optionsBuilder.UseSqlServer(@"Data Source=epizzahubdbserver.database.windows.net;Initial Catalog=ePizzaHubProd;Persist Security Info=False;User ID=pizzaadmin;Password=Money@Magnet7;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                optionsBuilder.UseSqlServer(@"Data Source=epizzahubdbserver.database.windows.net;Initial Catalog=ePizzaHubDev;Persist Security Info=False;User ID=pizzaadmin;Password=Money@Magnet7;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
            base.OnConfiguring(optionsBuilder);
        }


        #endregion

        #region Properties

        public DbSet<Category> Categories { get; set; }

        public DbSet<Products> Products { get; set; }

        public DbSet<Country> Country { get; set; }

        public DbSet<State> State { get; set; }

        public DbSet<City> City { get; set; }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<PaymentDetails> PaymentDetails { get; set; }

        #endregion
    }
}
