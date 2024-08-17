using GymSystemAPI.Models.Domain;
using GymSystemAPI.Models.Dto;
using GymSystemAPI.Services;
using GymSystemAPI.Services.Login;
using GymSystemAPI.Services.Registeration;
using GymSystemAPI.Services.Settings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymSystemAPI.Controllers.API.Trainee
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IEnumerable<IRegistrationService> _registrationService;
        private readonly ILoginService _loginService;
        private readonly ISettingsService _settingsService;
        private readonly ApplicationDbContext _context;
        public AccountController(IEnumerable<IRegistrationService> registrationServiceFactory, ILoginService loginService,ISettingsService settingsService,ApplicationDbContext context)
        {

            _registrationService = registrationServiceFactory;
            _loginService = loginService;
            _settingsService = settingsService;
            _context = context;
        }

        [HttpPost("Regsiter")]
        public async Task<IActionResult> Register(UserDto userDto)
        {
            try
            {

                var registrationService = _registrationService.FirstOrDefault(x => x.GetType() == typeof(TraineeRegisteration));
                var (jwt,userprofile) = await registrationService.RegisterUserAsync(userDto);
                
                var response = new
                {
                    jwt = jwt,
                    User = userprofile,
                    
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex.Message);
                return BadRequest(ModelState);
            }
        }
        [Authorize (Roles = "Trainee")]
        [HttpPost("login")]
        public async Task<IActionResult> Login(string email, string password)
        {

            var loginservice = await _loginService.ValidateUserAsync(email, password);

            if (!loginservice)
            {

                ModelState.AddModelError("Error", "Invalid email or password.");
                return BadRequest(ModelState);
            }
            else
            {
                return Ok("Trainee Login Success");
            }
        }

        [HttpPut("UpdateSettings/{id}")]
        public async Task <IActionResult> UpdateContact(int id, UserDto userDto)
        {
            var updatedSettings = await _settingsService.UpdateUserAsync(id, userDto);

            if (updatedSettings == null)
            {
                return NotFound();
            }

            return Ok(updatedSettings);
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteTrainee(int id)
        {
            var trainee = _context.Users.FirstOrDefault(u => u.Id == id && u.Role == "Trainee");
            if (trainee == null)
            {
                return NotFound();

            }
            _context.Users.Remove(trainee);
            _context.SaveChanges();
            return Ok("Trainee Removed Success");
        }

    }
}
