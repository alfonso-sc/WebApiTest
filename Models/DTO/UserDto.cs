using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTest.Models.DTO
{
    public class UserDto
    {
        public int? Id { get; set; }

        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        public int ManagerId { get; set; }

        public short ExpectedHours { get; set; }

        public bool Active { get; set; }

        public string? PhoneNumber { get; set; }

        public List<int> ProjectIds { get; set; } = new List<int>();
        public List<String> Roles { get; set; } = new List<String>();

    }
}