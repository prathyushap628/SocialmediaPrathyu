using Dotnetsql.Models;
using Dotsql.Repositories;
using Microsoft.AspNetCore.Mvc;
using own.DTOs;

namespace Own.Controllers;

[ApiController]
[Route("api/User")]
public class UserControllerController : ControllerBase
{


    private readonly ILogger<UserControllerController> _logger;
    private readonly IUserRepository _user;

    public UserControllerController(ILogger<UserControllerController> logger, IUserRepository user)
    {
        _logger = logger;
        _user = user;
    }

    [HttpGet("{user_id}")]
    public async Task<ActionResult<UserDTO>> GetUserById([FromRoute] long user_id)
    {
        var user = await _user.GetById(user_id);
        if (user is null)
            return NotFound("No user found with given user id");
        return Ok(user.asDto);

    }
    [HttpPost]
    public async Task<ActionResult<UserDTO>> CreateUser([FromBody] UserCreateDTO Data)
    {
        var toCreateUser = new User
        {

            EmailAddress = Data.EmailAddress.Trim(),
            Password = Data.Password.Trim(),
            Country = Data.Country.Trim(),
            GivenName = Data.GivenName.Trim(),
            Surname = Data.Surname.Trim(),


        };
        var createdUser = await _user.Create(toCreateUser);
        return StatusCode(StatusCodes.Status201Created, createdUser.asDto);
    }

    [HttpPut("{user_id}")]
    public async Task<ActionResult> UpdateUser([FromRoute] long user_id, [FromBody] UserUpadateDTO Data)
    {
        var existing = await _user.GetById(user_id);
        if (existing is null)
            return NotFound("No user found with given employee number");
        var toUpdateUser = existing with
        {
            GivenName = Data.GivenName?.Trim() ?? existing.GivenName,
            Surname = Data.Surname?.Trim() ?? existing.Surname,

        };
        var didUpdate = await _user.Update(toUpdateUser);
        if (!didUpdate)

            return StatusCode(StatusCodes.Status500InternalServerError, "could not update user");

        return NoContent();
    }

    [HttpDelete("{user_id}")]
    public async Task<ActionResult> DeleteUser([FromRoute] long user_id)
    {
        var existing = await _user.GetById(user_id);
        if (existing is null)
            return NotFound("No user found with given user id");
        var didDelete = await _user.Delete(user_id);
        return NoContent();

    }




}