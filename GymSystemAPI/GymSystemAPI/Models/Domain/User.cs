using GymSystemAPI.enums;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace GymSystemAPI.Models.Domain
{
   

   

    public class User
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string FirstName { get; set; } = "";
        [MaxLength(100)]
        public string LastName { get; set; } = "";
        [MaxLength(100)]
        public string Email { get; set; } = "";
        [MaxLength(100)]
        public string? Phone { get; set; }
        [MaxLength(100)]
        public string? Address { get; set; }
        [MaxLength(100)]
        public string Password { get; set; } = "";
        [MaxLength(20)]

        public string Role { get; set; } = "";
        public string ? Gender { get; set; }
        public string? Contract { get; set; }
        public string? Subscription { get; set; }
        [MaxLength(100)]
        public string? Salary { get; set; }
        public string? Experince { get; set; } 

        
        public DateTime? CreatedAt { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<QR> QRs { get; set; }

        public ICollection<Course> courses { get; set; }
    }
}
