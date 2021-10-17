using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RaceTimes.Models
{
    public class Racer
    {
        public int RacerID { get; set; }

        [Required(ErrorMessage = "The First Name field is required."), MaxLength(30)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The Last Name field is required."), MaxLength(40)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The field Hours must be between 0 and 23."), Range(0, 23)]
        public int? Hours { get; set; }

        [Required(ErrorMessage = "The field Minutes must be between 0 and 59."), Range(0, 59)]
        public int? Minutes { get; set; }

        [Required(ErrorMessage = "The field Seconds must be between 0 and 59."), Range(0, 59)]
        public int? Seconds { get; set; }

        [Required(ErrorMessage = "The field Milliseconds must be between 0 and 999."), Range(0, 999)]
        public int? Milliseconds { get; set; }
    }
}
