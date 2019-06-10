using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTO
{
    public class CreateActorDTO
    {
        [RegularExpression("^[A-Z][a-z]{2,}$", ErrorMessage = "Ime nije u dobrom formatu")]
        public string FirstName { get; set; }
        [RegularExpression("^[A-Z][a-z]{2,}$", ErrorMessage = "Ime nije u dobrom formatu")]
        public string LastName { get; set; }
    }
}
