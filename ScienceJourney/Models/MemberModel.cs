using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScienceJourney.Models
{
    public class MemberModel
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int countryName { get; set; }
        public int cityName { get; set; }
        public string interests { get; set; }
        public string gender { get; set; }
    }
}