using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymSystemAPI.Services.Login
{
   
        public interface ILoginService
        {
         Task< bool> ValidateUserAsync(string email, string password);
        }

        
        }

    

