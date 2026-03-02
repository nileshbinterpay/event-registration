namespace web.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }

    public class StudentRegistration
    {
        public int EventId { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public string StudentEmail { get; set; } = string.Empty;
    }

    public static class EventDataStore
    {
        public static List<Event> Events { get; } = new List<Event>
        {
            new Event { Id = 1, Name = "Tech Talk", Description = "A talk on latest technology trends." },
            new Event { Id = 2, Name = "Workshop", Description = "Hands-on workshop on web development." },
            new Event { Id = 3, Name = "Networking", Description = "Meet and network with professionals." },
            new Event { Id = 4, Name = "Fresher Party - Welcome Ceremony", Description = "Kick-off event to welcome new students." },
            new Event { Id = 5, Name = "Fresher Party - Talent Show", Description = "Showcase your talent at the fresher party." }
        };

        public static List<StudentRegistration> Registrations { get; } = new List<StudentRegistration>();
    }
}
