using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Genre : BaseEntity
    {
        
        public string Name { get; set; }

        public ICollection<Movie_Genre> Movie_Genre { get; set; }
    }
}
