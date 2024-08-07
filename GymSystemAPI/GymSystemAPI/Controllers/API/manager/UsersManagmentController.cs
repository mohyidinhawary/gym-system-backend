using GymSystemAPI.Services;
using GymSystemAPI.Services.Login;
using GymSystemAPI.Services.Registeration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymSystemAPI.Controllers.API.manager
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersManagmentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsersManagmentController( ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet("Users")]
        public IActionResult GetUsers()
        {
            var listusers = _context.Users.ToList();
            return Ok(listusers);
        }

    }
}
