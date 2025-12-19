using Microsoft.AspNetCore.Mvc;
using ServiceEnergie.Application.DTOs;
using ServiceEnergie.Application.Services;

namespace ServiceEnergie.API.Controllers
{
    [ApiController]
    [Route("api/energy")]
    public class EnergyController : ControllerBase
    {
        private readonly IEnergyService _service;

        public EnergyController(IEnergyService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
            => Ok(_service.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _service.GetById(id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public IActionResult Create(EnergyDtoReceive dto)
            => Created("", _service.Create(dto));
    }
}
