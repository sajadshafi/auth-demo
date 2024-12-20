using AuthDemo.IManagers;
using AuthDemo.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AuthDemo.API.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserManager _userManager;
        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserVM user)
        {
            await _userManager.CreateAsync(user);
            return Ok();
        }
    }
}