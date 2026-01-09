using Caisse_enregistreuse.Services;
using Microsoft.AspNetCore.Mvc;

namespace Caisse_enregistreuse.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly CategorieService _service;

        public CategoriesController(CategorieService service)
        {
            _service = service;
        }

        public IActionResult Index()
            => View(_service.GetAll());

    }
}
