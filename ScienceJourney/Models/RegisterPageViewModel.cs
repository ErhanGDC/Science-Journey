using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScienceJourney.Models
{
    public class RegisterPageViewModel
    {
        public MemberModel Member;
        public List<CountryModel> Countries;
        public List<CityModel> Cities;
    }
}