using FIAP.FCG.Service.Dto.User;
using FIAP.FCG.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace FIAP.FCG.API.Controllers;

[Route("[controller]")]
[ApiController]
public class UserController(IUserService service) : ControllerBase
{
    private readonly IUserService _service = service;

    /// <summary>
    /// Cria um novo usuário.
    /// </summary>
    /// <param name="input">Dados do usuário a ser criado.</param>
    /// <response code="200">Usuário criado com sucesso.</response>
    /// <response code="400">Dados inválidos.</response>
    [HttpPost]
    [Authorize(Policy = "Admin")]
    public IActionResult Post([FromBody] UserCreateDto input)
    {
        _service.Create(input);
        return Ok();
    }

    /// <summary>
    /// Atualiza um usuário existente.
    /// </summary>
    /// <param name="input">Dados do usuário para atualização.</param>
    /// <response code="200">Usuário atualizado com sucesso.</response>
    /// <response code="404">Usuário não encontrado.</response>
    [HttpPut]
    [Authorize(Policy = "Admin")]
    public IActionResult Put([FromBody] UserUpdateDto input)
    {
        _service.Update(input);
        return Ok();
    }

    /// <summary>
    /// Remove um usuário pelo ID.
    /// </summary>
    /// <param name="id">ID do usuário.</param>
    /// <response code="200">Usuário removido com sucesso.</response>
    /// <response code="404">Usuário não encontrado.</response>
    [HttpDelete("{id:long}")]
    [Authorize(Policy = "Admin")]
    public IActionResult Delete(long id)
    {
        _service.DeleteById(id);
        return Ok();
    }

    /// <summary>
    /// Obtém um usuário pelo ID.
    /// </summary>
    /// <param name="id">ID do usuário.</param>
    /// <response code="200">Usuário encontrado.</response>
    /// <response code="404">Usuário não encontrado.</response>
    [HttpGet("GetById/{id:long}")]
    [Authorize]
    public IActionResult GetById(long id)
    {
        return Ok(_service.GetById(id));
    }

    /// <summary>
    /// Lista todos os usuários.
    /// </summary>
    /// <response code="200">Lista de usuários retornada com sucesso.</response>
    [HttpGet("GetAll")]
    [Authorize]
    public IActionResult GetAll()
    {
        return Ok(_service.GetAll());
    }

}
