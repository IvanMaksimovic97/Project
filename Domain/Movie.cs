using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Movie : BaseEntity
    {
        public string Title { get; set; }
        public DateTime? StartShowingFrom { get; set; }
        public int DurationMins { get; set; }
        public string Country { get; set; }
        public int Year { get; set; }
        public string PictureUrl { get; set; }

        public ICollection<Movie_Genre> Movie_Genre { get; set; }
        public ICollection<Movie_Actor> Movie_Actor { get; set; }
        public ICollection<Movie_Cinema> Movie_Cinema { get; set; }
    }
}
