using GymSystemAPI.Models.Domain;
using GymSystemAPI.Models.Dto;

namespace GymSystemAPI.Services.Settings
{
    public class UserSettings : ISettingsService
    {
        private readonly ApplicationDbContext _context;
        public UserSettings(ApplicationDbContext context) {
            _context = context;
        }

        public async Task<User> UpdateUserAsync(int id, UserDto userDto)
        {
            var trainee = await _context.Users.FindAsync(id);
            if (trainee == null)
            {
                return null; // You might want to handle this case differently in a service
            }

            trainee.FirstName = userDto.FirstName;
            trainee.LastName = userDto.LastName;
            trainee.Email = userDto.Email;
            trainee.Phone = userDto.Phone ?? "";
            trainee.Address = userDto.Address;

            await _context.SaveChangesAsync();

            return trainee;
        }
    }
}
