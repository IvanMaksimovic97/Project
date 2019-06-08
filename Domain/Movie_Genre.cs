using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Movie_Genre : BaseEntity
    {
        public Movie Movie { get; set; }
        public Genre Genre { get; set; }
    }
}
