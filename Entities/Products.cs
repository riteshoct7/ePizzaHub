using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("Products")]
    public class Products
    {

        #region Properties

        [Key]
        public int Productid { get; set; }

        [Required(ErrorMessage ="Product Name Required")]
        [DisplayName("Product Name")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Product Description Required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Unit Price Required")]
        [DisplayName("Unit Price")]
        public decimal UnitPrice { get; set; }

        [DisplayName("Image")]
        public string ImageUrl { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        #endregion

    }
}
