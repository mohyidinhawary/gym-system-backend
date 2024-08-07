

using Microsoft.EntityFrameworkCore;

namespace GymSystemAPI.Services.Login
{
    public class ManagerLogin : ILoginService
    {
        private readonly ApplicationDbContext _context;


        public ManagerLogin(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ValidateUserAsync(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null || user.Password != password)
            {
                return false;
            }



            return false;

        }


    }
}

