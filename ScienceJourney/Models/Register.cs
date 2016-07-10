using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScienceJourney.Models
{
    public class Register
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public string interests { get; set; }
        public string gender { get; set; }
        public string skills { get; set; }
    }
}