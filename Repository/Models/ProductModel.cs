using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    public class ProductModel
    {


        public int Id { get; set; }

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

        public int Quantity { get; set; }

        public decimal Total { get; set; }


    }
}
