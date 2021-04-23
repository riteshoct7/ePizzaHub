using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Order
    {
        #region Properties
        public string Id { get; set; }
        public int UserId { get; set; }
        public string PaymentId { get; set; }

        public string StreetAddress1 { get; set; }
        public string StreetAddress2 { get; set; }
        public string StreetAddress3 { get; set; }

        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Locality { get; set; }
        public string City { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public DateTime CreatedDate { get; set; } 
        #endregion

    }
}
