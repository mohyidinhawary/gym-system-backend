using GymSystemAPI.Models.Dto;

namespace GymSystemAPI.Services.Registeration
{
    public interface IRegistrationService
    {
        Task<string> RegisterUserAsync(UserDto userDto);

    }
}
