using eCommerce.Core.DTO;
using eCommerce.Core.ServiceContracts;

using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers;
[Route("api/[controller]")] //api/auth
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUsersService _usersService;

    public AuthController(IUsersService usersService)
    {
        _usersService = usersService;
    }

    [HttpPost("register")] //api/auth/register
    public async Task<IActionResult> Register(RegisterRequest registerRequest)
    {
        if (registerRequest == null)
        {
            return BadRequest("Invalid registration request");
        }

        AuthenticationResponse? authenticationResponse = await _usersService.Register(registerRequest);

        if (authenticationResponse == null || authenticationResponse.Success == false)
        {
            return BadRequest("Registration failed");
        }

        return Ok(authenticationResponse);
    }

    [HttpPost("login")] //api/auth/login
    public async Task<IActionResult> Login(LoginRequest loginRequest)
    {
        if (loginRequest == null)
        {
            return BadRequest("InvalidLogin request");
        }
        AuthenticationResponse? authenticationResponse = await _usersService.Login(loginRequest);
        if (authenticationResponse == null || authenticationResponse.Success == false)
        {
            return Unauthorized("Login failed");
        }
        return Ok(authenticationResponse);
    }
}