using GymSystemAPI.Models.Domain;
using GymSystemAPI.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace GymSystemAPI.Services.Settings
{
    public class ManagerSettings
    {
        private readonly ApplicationDbContext _context;
        public ManagerSettings(ApplicationDbContext context)
        {
            _context = context;
        }
       
    }
}
