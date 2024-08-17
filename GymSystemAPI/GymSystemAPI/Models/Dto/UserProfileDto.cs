﻿using System.ComponentModel.DataAnnotations;

namespace GymSystemAPI.Models.Dto
{
    public class UserProfileDto
    {

        public int Id { get; set; }
       
        public string FirstName { get; set; } = "";
    
        public string LastName { get; set; } = "";
    
        public string Email { get; set; } = "";

        public string Phone { get; set; } = "";

        public string Address { get; set; } = "";

      
        

    
        public string? Gender { get; set; }
       
    }
}
