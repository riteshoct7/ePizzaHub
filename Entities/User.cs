using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class User : IdentityUser<int>
    {

        #region Proerties

        public string Name { get; set; }

        [NotMapped]
        public string[] Roles { get; set; }

        #endregion

    }
}
