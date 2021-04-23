using Entities;
using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UI.Areas.Admin.Models
{
    public class ProductModel
    {

        #region Properties

        public int Productid { get; set; }

        [Required(ErrorMessage = "Product Name Required")]
        [DisplayName("Product Name")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Product Description Required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Unit Price Required")]
        [DisplayName("Unit Price")]
        public decimal UnitPrice { get; set; }

        [DisplayName("Image")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Please Select Category")]
        [DisplayName("Category")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public IFormFile File { get; set; } 
        #endregion
    }
}
