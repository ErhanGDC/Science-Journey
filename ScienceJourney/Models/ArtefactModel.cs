using ScienceJourney.DAL;
using System;
using System.Collections.Generic;

namespace ScienceJourney.Models
{
    public class ArtefactModel
    {
        public int ArtefactID { get; set; }
        public Nullable<int> MuseumID { get; set; }
        public string ArtefactName { get; set; }
        public string ArtefactDescription { get; set; }

        public virtual Museum Museum { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
    }
}