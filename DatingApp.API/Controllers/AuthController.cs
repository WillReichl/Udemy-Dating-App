using System.Threading.Tasks;
using DatingApp.API.Data;
using DatingApp.API.Dtos;
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
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto) // replace variables w/ DTO
        {
            // validate request

            userForRegisterDto.Username = userForRegisterDto.Username.ToLower();

            if (await _authRepo.UserExists(userForRegisterDto.Username))
                return BadRequest("Usename already exists");

            var userToCreate = new User {
                Username = userForRegisterDto.Username
            };

            var createdUser = await _authRepo.RegisterAsync(userToCreate, userForRegisterDto.Password);

            return StatusCode(201); // will come back and use CreatedAtRoute() later
        }
    }
}