using Microsoft.AspNetCore.Mvc;

namespace phoneBook_API.Controllers
{
    public class phoneBook : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
