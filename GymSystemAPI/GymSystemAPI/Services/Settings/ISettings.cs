using GymSystemAPI.Models.Domain;
using GymSystemAPI.Models.Dto;

namespace GymSystemAPI.Services.Settings
{
    public interface ISettingsService
    {
        Task<User> UpdateUserAsync(int id,UserDto userDto);

    }
}
