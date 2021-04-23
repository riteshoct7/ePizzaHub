using Microsoft.AspNetCore.Mvc;

namespace UI.Areas.User.Controllers
{
  
    public class DashboardController : BaseController
    {
        #region Methods
        public IActionResult Index()
        {
            return View();
        }
        #endregion
    }

}
