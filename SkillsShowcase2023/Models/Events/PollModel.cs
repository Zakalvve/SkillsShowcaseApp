using System.ComponentModel.DataAnnotations;

namespace MVCSkillsShowcaseApp.Models.Events
{
    public class PollModel
    {
        public int Id { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int EventId { get; set; }

        [Required(ErrorMessage = "You must set a deadline for the poll")]
        public DateTime Deadline { get; set; }

        public List<PollOptionModel> Options { get; set; }
    }
}
