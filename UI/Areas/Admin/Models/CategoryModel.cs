using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UI.Areas.Admin.Models
{
    public class CategoryModel
    {

        #region Properties

        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Category Name Required")]
        [DisplayName("Category Name")]
        public string CategoryName { get; set; }

        public string Description { get; set; } 

        #endregion

    }
}
