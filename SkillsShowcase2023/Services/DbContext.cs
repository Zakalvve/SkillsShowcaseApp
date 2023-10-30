using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MVCSkillsShowcaseApp.Models;
using MVCSkillsShowcaseApp.Models.Events;
using MVCSkillsShowcaseDataLibrary.DataAccess;

namespace MVCSkillsShowcaseApp.Services
{
    public class DbContext : IDbContext
    {
        private readonly DatabaseSettings _dbSettings;
        private readonly EventAccessor _eventAccessor;

        public DbContext(IOptions<DatabaseSettings> options)
        {
            _dbSettings = options.Value;
            _eventAccessor = new EventAccessor(_dbSettings.ConnectionString);
        }

        public int CreateEvent(EventModel model)
        {
            return _eventAccessor.CreateEvent(model.Name, model.Description, model.Location, model.Time);
        }

        public int CreatePoll(int eventId, PollModel model)
        {
            return _eventAccessor.CreatePoll(eventId, model.Deadline);
        }

        public int CreatePollOption(int pollId, PollOptionModel model)
        {
            return _eventAccessor.CreatePollOption(pollId,model.Name);
        }

        public List<EventModel> LoadEvents()
        {
            var data = _eventAccessor.LoadEvents();

            List<EventModel> events = data
                .Select(row => new EventModel() { Id = row.Id, Name = row.Name, Description = row.Description, Location = row.Location, Time = row.Time })
                .ToList();

            return events;
        }

        public EventModel LoadEvent(int id)
        {
            var row = _eventAccessor.LoadEvent(id);

            PollModel poll = null;

            if (row.Poll != null)
            {
                poll = new PollModel() { Id = row.Poll.Id, EventId = row.Poll.EventId, Deadline = row.Poll.Deadline };

                if (!row.Poll.Options.IsNullOrEmpty())
                {
                    poll.Options = row.Poll.Options
                        .Select(option => new PollOptionModel() { Id = option.Id, PollId = option.PollId, Name = option.Name,Votes = option.Votes })
                        .ToList();
                }
            }
            
            return new EventModel() { Id = row.Id, Name = row.Name,Description = row.Description,Location = row.Location,Time = row.Time,Poll = poll };
        }
    }
}
