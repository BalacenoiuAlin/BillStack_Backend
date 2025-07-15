using BillStack_Backend.Models.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BillStack_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;

        public AuthController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }

        // Create a new account
        // POST: /api/Auth/Register
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterAccountDto registerAccountDto)
        {
            var identityUser = new IdentityUser
            {
                Email = registerAccountDto.Email,
                UserName = registerAccountDto.Username,
                PhoneNumber = registerAccountDto.PhoneNumber,

            };

            var identityResult = await userManager.CreateAsync(identityUser, registerAccountDto.PasswordHash);

            if (identityResult.Succeeded)
            {
                // Add roles to this User
                if (registerAccountDto.Role != null && registerAccountDto.Role.Any())
                {
                    await userManager.AddToRoleAsync(identityUser, registerAccountDto.Role);
                    return Ok("User was registered!");
                }
            }

            return BadRequest("Something went wrong. Account was not registered!");
        }

        // Login into an existing account
        // Post: /api/Auth/Login

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginAccountDto loginAccountDto)
        {
            var user = await userManager.FindByEmailAsync(loginAccountDto.Email);

            if ( user != null && await userManager.CheckPasswordAsync(user, loginAccountDto.PasswordHash))
            {
                // Create JWT Token

                return Ok("Login successful!");
            }

            return Unauthorized("Invalid name or password!");
        }

    }
}
