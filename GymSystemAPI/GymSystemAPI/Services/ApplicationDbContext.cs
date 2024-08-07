
using GymSystemAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;


namespace GymSystemAPI.Services
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options):base(options) 
        {

        }
        public DbSet<User> Users { get; set; }
       
    }
}
