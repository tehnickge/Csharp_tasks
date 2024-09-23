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
        public JsonResult Check(Contacts model)
        {
            if (ModelState.IsValid)
            {
                return Json(new { success = true, data = model });
            }
            else
            {
                return Json(new { success = false });
            }
        }
    }
}