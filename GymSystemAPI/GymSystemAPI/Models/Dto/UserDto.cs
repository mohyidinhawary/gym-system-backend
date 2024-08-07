using GymSystemAPI.enums;
using GymSystemAPI.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace GymSystemAPI.Models.Dto
{
   
    public class UserDto
    {
        [Required,MaxLength(100)]
        public string FirstName { get; set; } = "";
        [Required,MaxLength(100)]
        public string LastName { get; set; } = "";
        [Required,EmailAddress,MaxLength(100)]
        public string Email { get; set; } = "";
        [Required, MaxLength(100)]
        public string? Phone { get; set; } 
        [Required, MaxLength(100)]
        public string? Address { get; set; } 
        [Required, MaxLength(100)]
        public string Password { get; set; } = "";
        [Required,MaxLength(20)]


        public string? Gender { get; set; }
       
        public string? Contract { get; set; }
       
        public string? Subscription { get; set; }
        [ MaxLength(100)]
        public string? Salary { get; set; }
       
        public string? Experince { get; set; } 


       
    }
}
