using FIAP.FCG.Service.Dto.User;
using FIAP.FCG.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FIAP.FCG.API.Controllers;

[Route("[controller]")]
[ApiController]
public class UserController(IUserService service) : ControllerBase
{
    private readonly IUserService _service = service;

    [HttpPost]
    [Authorize(Policy = "Admin")]
    public IActionResult Post([FromBody] UserCreateDto input)
    {
        _service.Create(input);
        return Ok();
    }

    [HttpPut]
    [Authorize(Policy = "Admin")]
    public IActionResult Put([FromBody] UserUpdateDto input)
    {
        _service.Update(input);
        return Ok();
    }

    [HttpDelete("{id:long}")]
    [Authorize(Policy = "Admin")]
    public IActionResult Delete(long id)
    {
        _service.DeleteById(id);
        return Ok();
    }

    [HttpGet("GetById/{id:long}")]
    [Authorize]
    public IActionResult GetById(long id)
    {
        return Ok(_service.GetById(id));
    }

    [HttpGet("GetAll")]
    [Authorize]
    public IActionResult GetAll()
    {
        return Ok(_service.GetAll());
    }

}
