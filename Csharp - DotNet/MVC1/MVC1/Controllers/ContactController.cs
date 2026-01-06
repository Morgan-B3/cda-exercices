using Microsoft.AspNetCore.Mvc;

namespace MVC1.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Details()
        {
            return Content("Ceci est une page de contact");
        }
    }
}
