using Microsoft.AspNetCore.Mvc;
using UserService.Models;
using UserService.Service;
using UserService.DTO;

namespace UserService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IService<UserDtoReceive, UserDtoSend> _service;

    public UserController(IService<UserDtoReceive, UserDtoSend> service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetAll());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var pizza = await _service.GetById(id);
        if (pizza is null)
            return NotFound("User Not found");
        return Ok(pizza);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UserDtoReceive userDtoReceive)
    {
        UserDtoSend userDtoSend = await _service.Create(userDtoReceive);
        return CreatedAtAction(nameof(Create), userDtoSend);
    }

    [HttpDelete("{id}")]

    public IActionResult Delete(int id)
    {
        if (_service.Delete(id))
        {
            return Delete(id);
        }

        return NotFound("User not found");
    }
}