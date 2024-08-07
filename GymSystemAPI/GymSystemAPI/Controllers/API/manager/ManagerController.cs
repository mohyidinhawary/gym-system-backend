using GymSystemAPI.Models.Domain;
using GymSystemAPI.Services;
using GymSystemAPI.Services.Login;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace GymSystemAPI.Controllers.API.manager
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {

        private readonly ILoginService _loginService;
        public ManagerController(ApplicationDbContext context, ILoginService loginService)
        {

            _loginService = loginService;
        }

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
                return Ok("Manager Login Success");
            }



        }
    }

}

