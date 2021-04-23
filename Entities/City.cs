using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class City
    {

        #region Properties
        [Key]
        public int Cityid { get; set; }

        [Required]
        [DisplayName("City Name")]
        public string CityName { get; set; }

        public string Description { get; set; }

        public bool Enabled { get; set; }
        public virtual int StateId { get; set; }
        public virtual State State { get; set; } 
        #endregion
    }
}
