using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("States")]
    public class State
    {
        #region Properties
        [Key]
        public int Stateid { get; set; }

        [Required]
        [DisplayName("State Name")]
        public string StateName { get; set; }

        public string Description { get; set; }

        public bool Enabled { get; set; }
        public virtual int CountryId { get; set; }
        public virtual Country Country { get; set; }      
        #endregion
    }
}
