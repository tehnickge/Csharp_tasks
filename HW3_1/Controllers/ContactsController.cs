using HW3_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace HW3_1.Controllers
{
    public class ContactsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Check(Contacts contacts)
        {
            if(ModelState.IsValid)
            {
                return Redirect("/");
            }
            return View("Index");
        }
    }
}
