using GymSystemAPI.Models.Dto;
using GymSystemAPI.Services.Login;
using GymSystemAPI.Services.Registeration;
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
        public AccountController(IEnumerable<IRegistrationService> registrationServiceFactory, ILoginService loginService)
        {

            _registrationService = registrationServiceFactory;
            _loginService = loginService;
        }

        [HttpPost("Regsiter")]
        public async Task<IActionResult> Register(UserDto userDto)
        {
            try
            {

                var registrationService = _registrationService.FirstOrDefault(x => x.GetType() == typeof(TraineeRegisteration));
                var jwt = await registrationService.RegisterUserAsync(userDto);

                var response = new
                {
                    jwt = jwt,
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
    }
}
