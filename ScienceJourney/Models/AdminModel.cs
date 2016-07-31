using ScienceJourney.DAL;


namespace ScienceJourney.Models
{
    public class AdminModel
    {
        public Scientist _Scientist { get; set; }
        public Address _Address { get; set; }
        public Museum _Museum { get; set; }
        public Artefact _Artefact { get; set; }
        public Article _Article { get; set; }
    }
}