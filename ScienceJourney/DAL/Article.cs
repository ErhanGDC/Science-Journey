//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ScienceJourney.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Article
    {
        public int ArticleID { get; set; }
        public Nullable<int> MuseumID { get; set; }
        public Nullable<int> ScientistID { get; set; }
        public Nullable<int> ArtefactID { get; set; }
        public string Article1 { get; set; }
        public Nullable<System.DateTime> createTime { get; set; }
    
        public virtual Artefact Artefact { get; set; }
        public virtual Museum Museum { get; set; }
        public virtual Scientist Scientist { get; set; }
    }
}