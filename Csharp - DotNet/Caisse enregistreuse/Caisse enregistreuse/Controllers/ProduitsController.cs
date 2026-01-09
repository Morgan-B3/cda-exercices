using Caisse_enregistreuse.Services;
using Microsoft.AspNetCore.Mvc;

namespace Caisse_enregistreuse.Controllers
{
    public class ProduitsController : Controller
    {
        private readonly ProduitService _service;

        public ProduitsController(ProduitService service)
        {
            _service = service;
        }

        public IActionResult Index()
            => View(_service.GetAll());
    }
}
