using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Model
{
    public class MovieData
    {
        public int ID { get; set; }
        public string MovieName { get; set; }
        public int MovieYear { get; set; }
        public string MovieGenre { get; set; }
        public string MovieDirector { get; set; }
    }
}
