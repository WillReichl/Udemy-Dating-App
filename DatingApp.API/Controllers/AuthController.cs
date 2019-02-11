using System.Threading.Tasks;
using DatingApp.API.Data;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepo;

        public AuthController(IAuthRepository authRepository)
        {
            this._authRepo = authRepository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(string username, string password) // replace variables w/ DTO
        {
            // validate request

            username = username.ToLower();

            if (await _authRepo.UserExists(username))
                return BadRequest("Usename already exists");

            var userToCreate = new User {
                Username = username
            };

            var createdUser = await _authRepo.RegisterAsync(userToCreate, password);

            return StatusCode(201); // will come back and use CreatedAtRoute() later
        }
    }
}