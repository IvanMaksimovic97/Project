using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Cinema : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public ICollection<Movie_Cinema> Movie_Cinema { get; set; }
    }
}
