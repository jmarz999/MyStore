using System;
using System.Collections.Generic;
using System.Text;

namespace MyStore.Services
{
    public class UserDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }
        public string Gender { get; set; }

        public DateTime? DateOfBirth { get; set; }
    }
}
