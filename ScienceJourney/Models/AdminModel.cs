using ScienceJourney.DAL;


namespace ScienceJourney.Models
{
    public class AdminModel
    {
        public Scientist Scientist { get; set; }
        public Address Address { get; set; }
        public Museum Museum { get; set; }
        public Artefact Artefact { get; set; }
        public Article Article { get; set; }
    }
}