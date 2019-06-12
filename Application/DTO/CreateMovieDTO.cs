using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTO
{
    public class CreateMovieDTO
    {
        public CreateMovieDTO()
        {
            ActorsIds = new List<int>();
            GenresIds = new List<int>();
        }

        [RegularExpression("^[A-Z][a-z]{2,}$", ErrorMessage = "Ime filma nije u dobrom formatu")]
        public string Title { get; set; }
        //[Required]
        public DateTime? StartShowingFrom { get; set; }
        [Required]
        public int DurationMins { get; set; }
        //[Required]
        public string Country { get; set; }
        [Required]
        public int Year { get; set; }
        public string PictureUrl { get; set; }

        //[Required]
        public List<int> ActorsIds { get; set; }
        //[Required]
        public List<int> GenresIds { get; set; }
    }
}
