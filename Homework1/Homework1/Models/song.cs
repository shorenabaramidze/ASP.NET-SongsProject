using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Homework1.Models
{
    public class song
    {
        [Required]
        public int ID { get; set; }
        [Required(ErrorMessage = "There is no data")]
        public string SongName { get; set; }
        [Required(ErrorMessage = "There is no data")]
        public int Released { get; set; }
        [Required(ErrorMessage = "There is no data")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "There is no data")]
        public string LastName { get; set; }

    }
}