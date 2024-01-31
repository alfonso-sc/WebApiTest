using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTest.EntityModels;

namespace WebApiTest.Models.DTO
{
    public class ProjectDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public decimal ChargingRate { get; set; }

        public bool Active { get; set; }

        public int CompanyId { get; set; }

        public int? ManagerId { get; set; }

        public bool FixedBid { get; set; }

        public List<int> SubprojectIds { get; set; } = new List<int>();

    }
}