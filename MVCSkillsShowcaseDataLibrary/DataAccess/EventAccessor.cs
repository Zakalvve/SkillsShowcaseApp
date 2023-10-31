using MVCSkillsShowcaseDataLibrary.Models;

namespace MVCSkillsShowcaseDataLibrary.DataAccess
{
    public class EventAccessor
    {
        private readonly DbAccessor _accessor;

        public EventAccessor(string dbConnectionString)
        {
            _accessor = new DbAccessor(dbConnectionString);
        }

        public int CreateEvent(string name, string description, string location, DateTime time)
        {
            EventModel data = new EventModel() { Name = name, Description = description, Location = location, Time = time };

            string sql = @"INSERT INTO dbo.Event (Name, Description, Location, Time)
                           VALUES (@Name, @Description, @Location, @Time);";

            return _accessor.SaveData(sql, data);
        }

        public int CreatePoll(int eventId, DateTime deadline)
        {
            PollModel data = new PollModel() { EventId = eventId, Deadline = deadline };

            string sql = @"INSERT INTO dbo.Poll (EventId, Deadline)
                           VALUES (@EventId, @Deadline)";

            return _accessor.SaveData(sql, data);
        }

        public int CreatePollOption(int pollId, string name)
        {
            PollOptionModel data = new PollOptionModel() { PollId = pollId, Name = name };

            string sql = @"INSERT INTO dbo.PollOption (PollId, Name)
                           VALUES(@PollId, @Name)";

            return _accessor.SaveData(sql, data);
        }

        public IEnumerable<EventModel> LoadEvents()
        {
            string sql = @"SELECT Id, Name, Description, Location, Time
                           FROM dbo.Event;";

            return _accessor.LoadData<EventModel>(sql);
        }

        public EventModel LoadEvent(int eventId)
        {
            string sql = @$"SELECT e.Id, e.Name, e.Description, e.Location, e.Time, p.Id, p.EventId, p.Deadline
                           FROM dbo.Event AS e
                           LEFT JOIN dbo.Poll AS p ON e.Id = p.EventId
                           WHERE e.Id = {eventId};";

            var evt = _accessor
                .MultiMapLoadData<EventModel, PollModel, EventModel>(sql, (e, p) => { e.Poll = p; return e; }, "Id")
                .FirstOrDefault();

            if (evt.Poll != null)
            {
                var pollOptions = LoadPollOptions(evt.Poll.Id);
                evt.Poll.Options = pollOptions;
            }

            return evt;
        }

        public IEnumerable<PollOptionModel> LoadPollOptions(int pollId)
        {
            string sql = @$"SELECT po.Id, po.PollId, po.Name, po.Votes
                            FROM dbo.PollOption as po
                            INNER JOIN dbo.Poll as p ON po.PollId = p.Id
                            WHERE p.Id = {pollId}";

            return _accessor.LoadData<PollOptionModel>(sql);
        }
    }
}
