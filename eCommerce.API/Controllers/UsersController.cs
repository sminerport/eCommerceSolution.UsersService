using eCommerce.Core.DTO;
using eCommerce.Core.ServiceContracts;

using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUsersService _usersService;

    public UsersController(IUsersService usersService)
    {
        _usersService = usersService;
    }

    // GET /api/users/{userID}
    [HttpGet("{userID:guid}")]
    public async Task<IActionResult> GetUserByUserID(Guid userID)
    {
        //await Task.Delay(10000);
        //throw new NotImplementedException("This is a test exception in the UsersMicroService");

        if (userID == Guid.Empty)
        {
            return BadRequest("UserID cannot be empty");
        }

        UserDTO? user = await _usersService.GetUserByUserID(userID);

        if (user == null)
        {
            return NotFound("User not found");
        }

        return Ok(user);
    }
}