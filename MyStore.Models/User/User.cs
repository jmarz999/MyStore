using System;
using Microsoft.AspNetCore.Identity;

namespace MyStore.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public Gender Gender { get; set; }
    }
}