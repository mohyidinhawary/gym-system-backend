using GymSystemAPI.Models.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using GymSystemAPI.Services.Token;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Web.Mvc;

namespace GymSystemAPI.Services.Login
{
    public class TraineeLogin:ILoginService
    {
        private readonly ApplicationDbContext _context;
        private readonly ITokenService _token;

        public TraineeLogin(ApplicationDbContext context, ITokenService token)
        {
            _context = context;
            _token = token;
        }

        public async  Task <bool> ValidateUserAsync(string email, string password)

        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email&&u.Password==password);
            if (user == null)
            {
                return false;
            }

           

           return true;
        }

        
    }
}
