
namespace MVCSkillsShowcaseDataLibrary.Models
{
    public class PollOptionModel
    {
        public int Id { get; set; }
        public int PollId { get; set; }
        public string Name { get; set; }
        public int Votes { get; set; }
    }
}
