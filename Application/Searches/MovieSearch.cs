using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Searches
{
    public class MovieSearch
    {
        public DateTime? StartShowingDate { get; set; }
        public string Title { get; set; }
        public int? GenreId { get; set; }
        public int? CinemaId { get; set; }
    }
}
