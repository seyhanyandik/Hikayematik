using Microsoft.AspNetCore.Mvc;

namespace Hikayematik.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
