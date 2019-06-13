using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTO
{
    public class CreateGenreDTO
    {
        [Required]
        [RegularExpression("^[A-Z][a-z]{2,}$", ErrorMessage ="Zanr nije u dobrom formatu")]
        public string Name { get; set; }
    }
}
