using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTO
{
    public class CreateCinemaDTO
    {
        [RegularExpression(@"[A-Z][a-z]+(\s[A-Z][a-z]+)*", ErrorMessage = "Ime nije u dobrom formatu")]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [RegularExpression("[0-9]+", ErrorMessage = "Telefon nije u dobrom formatu")]
        public string Phone { get; set; }
    }
}
