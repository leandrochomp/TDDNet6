using Microsoft.AspNetCore.Mvc;
using TDDNet6.API.Models;

namespace TDDNet6.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly ILogger<UsersController> _logger;

    public UsersController(ILogger<UsersController> logger)
    {
        _logger = logger;
    }

    //[HttpGet(Name = "GetUsers")]
    //public async Task <IActionResult> Get()
    //{
    //    return null;
    //}
}
