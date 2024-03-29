﻿using System.ComponentModel.DataAnnotations;

namespace ShopApi.Resources
{
    public class SaveClientResource
    {
        [Required] [MaxLength(50)] public string Login { get; set; }

        [Required] [MaxLength(50)] public string Name { get; set; }

        [Required] [MaxLength(50)] public string Surname { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Phone] public string Phone { get; set; }
    }
}