using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    
    [Table("Categories")]
    public class Category
    {

        #region Proerties

        [Key]
        public int CategoryId { get; set; }

        [Required]
        [DisplayName("Category Name")]
        public string CategoryName { get; set; }

        public string Description { get; set; }

        public virtual IEnumerable<Products> Products { get; set; } 

        #endregion

    }
}
