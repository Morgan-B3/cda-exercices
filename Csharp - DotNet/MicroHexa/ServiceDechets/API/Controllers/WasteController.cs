using Microsoft.AspNetCore.Mvc;
using ServiceDechets.Application.DTOs;
using ServiceDechets.Application.Services;

namespace ServiceDechets.API.Controllers
{
    [ApiController]
    [Route("api/waste")]
    public class WasteController : ControllerBase
    {
        private readonly IWasteService _service;

        public WasteController(IWasteService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_service.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
            => _service.GetById(id) is null ? NotFound() : Ok(_service.GetById(id));

        [HttpPost]
        public IActionResult Create(WasteDtoReceive dto)
            => Created("", _service.Create(dto));

        [HttpPatch("{id}")]
        public IActionResult Update(int id, WasteDtoReceive dto)
            => _service.Update(id, dto) is null ? NotFound() : Ok(_service.Update(id, dto));
    }
}
