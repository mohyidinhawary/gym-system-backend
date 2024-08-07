using GymSystemAPI.Models.Domain;

namespace GymSystemAPI.Services.Token
{
    public interface ITokenService
    {
        string CreateJWTToken(User user);
    }
}
