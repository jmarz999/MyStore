using System;
using System.Collections.Generic;
using System.Text;

namespace MyStore.Services
{
    public class CreateUserDto
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }

    }
}
