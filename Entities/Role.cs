using Microsoft.AspNetCore.Identity;

namespace Entities
{
    public class Role : IdentityRole<int>
    {

        #region Properties

        public string Description { get; set; } 

        #endregion

    }
}
