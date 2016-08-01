using ScienceJourney.DAL;


namespace ScienceJourney.Models
{
    public class AdminModel
    {
        public Scientist scientist { get; set; }
        public Address address { get; set; }
        public Museum museum { get; set; }
        public Artefact artefact { get; set; }
        public Article article { get; set; }
    }
}