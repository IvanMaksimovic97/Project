using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class MovieDTO
    {
        public MovieDTO()
        {
            Actors = new List<ActorDTO>();
            Genres = new List<GenreDTO>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? StartShowingFrom { get; set; }
        public int DurationMins { get; set; }
        public string Country { get; set; }
        public int Year { get; set; }
        public string PictureUrl { get; set; }

        public List<ActorDTO> Actors { get; set; }
        public List<GenreDTO> Genres { get; set; }
    }
}
