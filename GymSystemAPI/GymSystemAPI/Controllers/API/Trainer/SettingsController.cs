using GymSystemAPI.Services.Settings;
using GymSystemAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GymSystemAPI.Models.Dto;

namespace GymSystemAPI.Controllers.API.Trainer
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        private readonly ISettingsService _settingsService;
        private readonly ApplicationDbContext _context;

        public SettingsController(ISettingsService settingsService,ApplicationDbContext context) {
            _settingsService = settingsService;
            _context = context;
        }
       
        [HttpPut("UpdateSettings/{id}")]
        public async Task<IActionResult> UpdateContact(int id, UserDto userDto)
        {
            var updatedSettings = await _settingsService.UpdateUserAsync(id, userDto);

            if (updatedSettings == null)
            {
                return NotFound();
            }

            return Ok(updatedSettings);
        }

    }
}
