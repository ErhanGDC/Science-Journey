
using ScienceJourney.DAL;
using System;
using System.Collections.Generic;
namespace ScienceJourney.Models
{
    public class MuseumModel
    {
        public int MuseumID { get; set; }
        public Nullable<int> AddressID { get; set; }
        public Nullable<bool> Shop { get; set; }
        public Nullable<bool> Smoking { get; set; }
        public Nullable<int> AnnualVisitorCount { get; set; }
        public Nullable<System.DateTime> DateBuilt { get; set; }
        public Nullable<System.TimeSpan> OpeningHours { get; set; }
        public string MuseumName { get; set; }
        public string MuseumDescription { get; set; }

        public virtual Address Address { get; set; }
        public virtual ICollection<Artefact> Artefacts { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
    }
}