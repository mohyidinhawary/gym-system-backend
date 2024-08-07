using GymSystemAPI.Models.Domain;
using GymSystemAPI.Models.Dto;
using GymSystemAPI.Services.Token;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics.Contracts;
using System.Text.Json.Serialization;
namespace GymSystemAPI.Services.Registeration
{
    public class TraineeRegisteration: IRegistrationService
    {
        private readonly ApplicationDbContext _context;
       private readonly ITokenService _tokenService;

        public TraineeRegisteration(ApplicationDbContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        public async Task<string> RegisterUserAsync(UserDto userDto)
        {
            // Check if the email address is already in use
            if (await _context.Users.AnyAsync(u => u.Email == userDto.Email))
            {
                throw new Exception("Email address is already in use.");
            }

            // Encrypt password
            var passwordHasher = new PasswordHasher<User>();
            var encryptedPassword = passwordHasher.HashPassword(new User(), userDto.Password);

            // Create new account
            User user = new User
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                Phone = userDto.Phone ?? "",
                Address = userDto.Address,
                Password = encryptedPassword,
                Role = "Trainee",
                Gender = userDto.Gender,
                Subscription= userDto.Subscription,
                
                CreatedAt = DateTime.Now
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            var jwt = _tokenService.CreateJWTToken(user);

            return jwt;

        }
    }
}
