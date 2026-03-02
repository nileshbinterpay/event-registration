namespace WebApp.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class EventRegistration
    {
        public int EventId { get; set; }
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
    }
}