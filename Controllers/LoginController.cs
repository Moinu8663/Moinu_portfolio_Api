using Microsoft.AspNetCore.Mvc;
using Moinu_portfolio_Api.Models;
using Moinu_portfolio_Api.Services;

namespace Moinu_portfolio_Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class LoginController(LoginService loginservice) : ControllerBase
{
    private readonly LoginService loginservice = loginservice;

    [HttpPost("login")]
    public IActionResult GetUser(LoginModels loginmodel)
    {
        var user = loginservice.GetUser(loginmodel);
        if (user == null)
            return Unauthorized(new { message = "Invalid username or password" });

        return Ok(new { message = "Login successful",user});
    }
}