using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScienceJourney.Models
{
    public class CityModel
    {
        public Nullable<int> id { get; set; }
        public string name { get; set; }
        public int country_id { get; set; }
    }
}