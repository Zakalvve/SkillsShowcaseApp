using MVCSkillsShowcaseApp.Models.Events;

namespace MVCSkillsShowcaseApp.Services
{
    public interface IDbContext
    {
        List<EventModel> LoadEvents();
        EventModel LoadEvent(int id);

        int CreateEvent(EventModel model);
        int CreatePoll(int eventId, PollModel model);
        int CreatePollOption(int pollId, PollOptionModel model);
    }
}
