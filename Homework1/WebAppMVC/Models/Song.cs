using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppMVC.Models
{
    public partial class Song
    {
        [Required]
        public int ID { get; set; }

        [Required (ErrorMessage = "There is no data")]
        [Display (Name = "Song Name")]
        public string SongName { get; set; }
        [Required]
        public int Released { get; set; }

        [Required]
        [Display(Name = "Singer's FirstName")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Singer's LastName")]
        public string LastName { get; set; }
    }
}