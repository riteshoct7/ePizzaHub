using Microsoft.AspNetCore.Mvc;
using UI.Helpers;

namespace UI.Areas.User.Controllers
{
    [CustomAuthorize(Roles = "User")]
    [Area("User")]
    public class BaseController : Controller
    {
   
    }
}
