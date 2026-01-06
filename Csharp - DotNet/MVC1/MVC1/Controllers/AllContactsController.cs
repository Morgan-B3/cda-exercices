using Microsoft.AspNetCore.Mvc;

namespace MVC1.Controllers
{
    public class AllContactsController : Controller
    {
        public IActionResult Index()
        {
            return Content("Ceci est la liste de tous les contacts");
        }
    }
}
