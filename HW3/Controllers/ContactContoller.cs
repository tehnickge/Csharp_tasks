using Microsoft.AspNetCore.Mvc;

namespace HW3.Controllers
{
    public class ContactContoller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
