using Microsoft.AspNetCore.Mvc;
using ServiceTransport.Application.DTOs;
using ServiceTransport.Application.Services;

namespace ServiceTransport.API.Controllers
{
    [ApiController]
    [Route("api/transport")]
    public class TransportController : ControllerBase
    {
        private readonly ITransportService _service;

        public TransportController(ITransportService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
            => Ok(_service.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
            => _service.GetById(id) is null ? NotFound() : Ok(_service.GetById(id));

        [HttpGet("{id}/emission")]
        public IActionResult GetEmission(int id)
        {
            var emission = _service.GetEmissionCO2(id);
            if (emission < 0) return NotFound();

            return Ok(new { emissionCO2 = emission });
        }

        [HttpPost]
        public IActionResult Create(TransportDtoReceive dto)
            => Created("", _service.Create(dto));

        [HttpPatch("{id}")]
        public IActionResult Update(int id, TransportDtoReceive dto)
            => _service.Update(id, dto) is null ? NotFound() : Ok(_service.Update(id, dto));
    }
}
