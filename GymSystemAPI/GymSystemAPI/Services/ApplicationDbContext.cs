
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
        public DbSet<Payment> Payments { get; set; }
        public DbSet<QR> QRs { get; set; }
        public DbSet<Exersice> exersices { get; set; }
        public DbSet<Course> courses { get; set; }


    }
}

