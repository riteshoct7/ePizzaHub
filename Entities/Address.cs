using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    
    public class Address 
    {
        [Key]
        public int AddressId { get; set; }

        [Required]
        public string StreetAddress1 { get; set; }
        public string StreetAddress2 { get; set; }
        public string StreetAddress3 { get; set; }

        [Required]
        public string ZipCode { get; set; }

        public string PhoneNumber { get; set; }
        public string Locality { get; set; }



    }
}
