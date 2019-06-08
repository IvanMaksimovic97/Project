using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Movie_Actor : BaseEntity
    {
        
        public Movie Movie { get; set; }
        public Actor Actor { get; set; }
    }
}
