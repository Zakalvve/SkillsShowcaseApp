using System.ComponentModel.DataAnnotations;

namespace MVCSkillsShowcaseApp.Models.Events
{
    public class PollOptionModel
    {
        public int Id { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int PollId { get; set; }

        [Required(ErrorMessage = "You must provide a name for this option")]
        public string Name { get; set; }

        public int Votes { get; set; }
    }
}
