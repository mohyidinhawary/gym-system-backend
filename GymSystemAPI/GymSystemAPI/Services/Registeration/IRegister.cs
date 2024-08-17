using GymSystemAPI.Models.Dto;

namespace GymSystemAPI.Services.Registeration
{
    public interface IRegistrationService
    {
        Task<(string jwt,UserProfileDto useProfile)> RegisterUserAsync(UserDto userDto);

    }
}
