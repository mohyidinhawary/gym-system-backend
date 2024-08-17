using GymSystemAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymSystemAPI.Controllers.API.Trainer
{
    [Route("api/[controller]")]
    [ApiController]
    public class TraineeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public TraineeController(ApplicationDbContext context) {
            _context = context;
        }
        [HttpGet("{id}")]
        public IActionResult TraineeProfile(int id)
        {
            var trainee = _context.Users.FirstOrDefault(c => c.Id == id && c.Role == "Trainee");
            if (trainee == null)
            {
                return NotFound();
            }
            return Ok(trainee);

        }

        [HttpGet("Trainees")]
        public IActionResult GetTrainees()
        {
            var listtrainees = _context.Users.Where(u => u.Role == "Trainee").ToList();
            return Ok(listtrainees);
        }

    }
}
