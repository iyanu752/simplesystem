using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SimpleSystem.Server
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController (IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateUserDto createUserDto)
        {
            var user = await _userService.CreateUserAsync(createUserDto);
            if (user == null)
            {
                return BadRequest("Username exists, try another username");
            }
            return Ok(user);
            
        }
    }
}
