using MVCSkillsShowcaseDataLibrary.Models;

namespace DataAccessLibrary.Models
{
    public class EventModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime Time { get; set; }
        public PollModel Poll { get; set; }
    }
}
