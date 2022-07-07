using Microsoft.AspNetCore.Mvc;
using TDDNet6.Services.User;

namespace TDDNet6.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        //private readonly ILogger<UsersController> _logger;
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet(Name = "GetUsers")]
        public async Task<IActionResult> Get()
        {
            var users = await _userService.GetAllUsers();
            if (users.Any())
            {
                return Ok(users);
            }

            return NotFound();
        }
    }
}