using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Movie_Cinema : BaseEntity
    {
        public int MovieId { get; set; }
        public int CinemaId { get; set; }
        public string Ticket_Price { get; set; }

        public Movie Movie { get; set; }
        public Cinema Cinema { get; set; }
    }
}
