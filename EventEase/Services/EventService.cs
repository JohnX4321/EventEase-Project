using EventEase.Models;

namespace EventEase.Services
{
    public class EventService
    {
        private List<Event> _events = new()
        {
            new Event{ Id=1, Name="Annual Conference", Date=DateTime.Now.AddDays(30), Location="New York"},
            new Event{ Id=2, Name="Team Building Retreat", Date=DateTime.Now.AddDays(60), Location="Lakeview"},
            new Event{ Id=3, Name="Product Launch", Date=DateTime.Now.AddDays(10), Location="San Francisco"}
        };

        // attendance store: eventId -> list of registrations
        private readonly Dictionary<int, List<Models.Registration>> _attendance = new();

        public IEnumerable<Event> GetAll() => _events;

        public Event? GetById(int id) => _events.FirstOrDefault(e => e.Id == id);

        public IReadOnlyList<Models.Registration> GetAttendees(int eventId)
        {
            if (_attendance.TryGetValue(eventId, out var list)) return list;
            return Array.Empty<Models.Registration>();
        }

        public void RegisterAttendee(int eventId, Models.Registration registration)
        {
            if (!_events.Any(e => e.Id == eventId)) return;
            if (!_attendance.TryGetValue(eventId, out var list))
            {
                list = new List<Models.Registration>();
                _attendance[eventId] = list;
            }
            registration.RegisteredAt = DateTime.UtcNow;
            list.Add(registration);
        }
    }
}