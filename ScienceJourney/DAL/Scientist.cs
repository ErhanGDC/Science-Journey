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
    
    public partial class Scientist
    {
        public Scientist()
        {
            this.Articles = new HashSet<Article>();
        }
    
        public int ScientistID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public Nullable<int> AddressID { get; set; }
        public string Title { get; set; }
        public string MiddleName { get; set; }
        public Nullable<System.DateTime> createTime { get; set; }
    
        public virtual ICollection<Article> Articles { get; set; }
    }
}
