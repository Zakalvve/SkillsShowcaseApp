using System.ComponentModel.DataAnnotations;

namespace MVCSkillsShowcaseApp.Models.Events
{
    public class EventModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "You must provide a name for the event.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must provide a description for the event.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "You must let people know where this event will be held.")]
        public string Location { get; set; }

        [Required(ErrorMessage = "You must let people know when this event is being held")]
        public DateTime Time { get; set; }

        public PollModel Poll { get; set; } = null;
    }
}
