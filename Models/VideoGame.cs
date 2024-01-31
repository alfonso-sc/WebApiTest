using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTest.Models
{
    public class VideoGame
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Studio { get; set; }
        public string Genre { get; set; }

        public string Rating { get; set; }

        public Decimal Price { get; set; }

        public DateOnly ReleaseDate { get; set; }

        public int CurrentRanking { get; set; }
    }
}