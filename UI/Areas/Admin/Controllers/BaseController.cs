using Microsoft.AspNetCore.Mvc;
using UI.Helpers;

namespace UI.Areas.Admin.Controllers
{
    [CustomAuthorize(Roles ="Admin")]
    [Area("Admin")]
    public class BaseController : Controller
    {

    }
}
