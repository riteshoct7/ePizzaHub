using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("Countries")]
    public class Country
    {
        #region Properties

        [Key]
        public int CountryId { get; set; }

        [Required(ErrorMessage = "Country Naame Required")]
        [DisplayName("Country Name")]
        public string CountryName { get; set; }

        [DisplayName("ISD Code")]
        public string ISDCode { get; set; }

        public string Description { get; set; }

        public virtual IEnumerable<State> States { get; set; }

        public bool Enabled { get; set; }

        #endregion
    }
}
