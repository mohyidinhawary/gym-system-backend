using GymSystemAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymSystemAPI.Controllers.API.Trainee
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public TrainerController(ApplicationDbContext context) {
            _context = context;
        }
        [HttpGet("{id}")]
        public IActionResult TrainerProfile(int id)
        {
            var trainer = _context.Users.FirstOrDefault(c => c.Id == id&& c.Role == "Trainer");
            if (trainer == null)
            {
                return NotFound();
            }
            return Ok(trainer);

        }
    }
}
