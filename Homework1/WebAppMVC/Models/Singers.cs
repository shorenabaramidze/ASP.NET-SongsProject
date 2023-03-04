using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppMVC.Models
{
    public class Singers
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string SingerGender { get; set; }
        public string country { get; set; }
        public string genre { get; set; }
    }
    
}
public enum Gender
{
    Male,
    Female
}