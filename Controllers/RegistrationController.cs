using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using socialmediaproject.Models;
using socialmediaproject.Repo.Repositories;

namespace socialmediaproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationRepo _registrationRepo;

        public RegistrationController(IRegistrationRepo registrationRepo)
        {
            _registrationRepo = registrationRepo;

        }
        [HttpGet("getbyId/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user=await _registrationRepo.GetUserById(id);
            if(user == null)
            {
                return NotFound();
            }
            return Ok(user);

        }
        [HttpGet("allusers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var _result = await _registrationRepo.GetAllUsersAsync();
            return Ok(_result);

        }
        [HttpPost("create")]
        public async Task<IActionResult> AddUser(Registration registration)
        {
            if(registration == null)
            {
                return BadRequest("Post Object is Null");
            }
            var createdUser = await this._registrationRepo.AddUser(registration);

            return Ok(createdUser);
        }
    }
}
