using GymSystemAPI.Models.Domain;
using GymSystemAPI.Models.Dto;
using GymSystemAPI.Services;
using GymSystemAPI.Services.Login;
using GymSystemAPI.Services.Registeration;
using GymSystemAPI.Services.Token;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GymSystemAPI.Controllers.API.manager
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainersManagmentController : ControllerBase
    {
        private readonly IEnumerable<  IRegistrationService > _registrationService;
        private readonly ILoginService _loginService;
        private readonly ApplicationDbContext _context;
        public TrainersManagmentController(IEnumerable<IRegistrationService> registrationService, ILoginService loginService, ApplicationDbContext context)
        {

            _registrationService = registrationService;
            _loginService = loginService;
            _context = context;
        }

        [HttpPost("Regsiter")]
        public async Task<IActionResult> Register(UserDto userDto)
        {
            try
            {
                var registrationService = _registrationService.FirstOrDefault(x=>x.GetType()==typeof(TrainerRegisteration));
                var jwt = await registrationService.RegisterUserAsync(userDto);

                var response = new
                {
                   jwt= jwt,
                    User = userDto
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex.Message);
                return BadRequest(ModelState);
            }
        }
        [Authorize(Roles = "Trainer")]
        [HttpPost("login")]

        public async Task<IActionResult> Login(string email, string password)
        {

            var loginservice = await _loginService.ValidateUserAsync(email, password);
           
            if (!loginservice )
            {

                ModelState.AddModelError("Error", "Invalid email or password.");
                return BadRequest(ModelState);
            }
            else
            {
return Ok("Trainer Login Success");
            }
        }



        [HttpGet("Trainers")]
        public IActionResult GetTrainers()
        {
            var listtrainers = _context.Users.Where(u=>u.Role== "Trainer").ToList();
            return Ok(listtrainers);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTrainer(int id)
        {
            var trainer = _context.Users.FirstOrDefault(u => u.Id == id && u.Role == "Trainer");
            if (trainer == null)
            {
                return NotFound();

            }
            _context.Users.Remove(trainer);
            _context.SaveChanges();
            return Ok("Trainer Removed Success");
        }
    }
}
