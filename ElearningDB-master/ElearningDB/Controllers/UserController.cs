using Microsoft.AspNetCore.Mvc;

namespace ElearningDB.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
