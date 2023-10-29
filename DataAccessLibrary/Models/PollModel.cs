
namespace MVCSkillsShowcaseDataLibrary.Models
{
    public class PollModel
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public DateTime Deadline { get; set; }
        public IEnumerable<PollOptionModel> Options { get; set; }
    }
}
