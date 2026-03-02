using System;
using System.Diagnostics.Metrics;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.VisualBasic;
using web.Models;

namespace web.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime EventTime { get; set; }
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
            // DateTime is created without specifying DateTimeKind, which defaults to DateTimeKind.Unspecified. This can cause issues with time zone conversions and comparisons. Specify DateTimeKind.Utc or DateTimeKind.Local explicitly, e.g., new DateTime(2026, 3, 10, 10, 0, 0, DateTimeKind.Utc), or consider using DateTimeOffset for better time zone handling.
            new Event
            {
                Id = 1,
                Name = "Tech Talk",
                Description = "A talk on the latest technology trends by industry experts. Q&A session included.",
                EventTime = new DateTime(2026, 3, 10, 10, 0, 0, DateTimeKind.Local)
            },
            new Event
            {
                Id = 2,
                Name = "Workshop",
                Description = "Hands-on workshop on modern web development using .NET 8 and Razor Pages.",
                EventTime = new DateTime(2026, 3, 11, 14, 0, 0, DateTimeKind.Local)
            },
            new Event
            {
                Id = 3,
                Name = "Networking",
                Description = "Meet and network with professionals and peers. Refreshments will be served.",
                EventTime = new DateTime(2026, 3, 12, 16, 30, 0, DateTimeKind.Local)
            },
            new Event
            {
                Id = 4,
                Name = "Fresher Party - Welcome Ceremony",
                Description = "Kick-off event to welcome new students with music, games, and snacks.",
                EventTime = new DateTime(2026, 3, 15, 18, 0, 0, DateTimeKind.Local)
            },
            new Event
            {
                Id = 5,
                Name = "Fresher Party - Talent Show",
                Description = "Showcase your talent at the fresher party. Open stage for all performances.",
                EventTime = new DateTime(2026, 3, 15, 20, 0, 0, DateTimeKind.Local)
            }
        };

        public static List<StudentRegistration> Registrations { get; } = new List<StudentRegistration>();
        public static List<StudentRegistration> Registrations { get; } = new List<StudentRegistration>(); 

        public static string MaskEmail(this string email)
        {
            if (string.IsNullOrEmpty(email))
                return email;

            var parts = email.Split('@');
            if (parts.Length != 2)
                return email;

            string name = parts[0];
            string domain = parts[1];

            if (name.Length <= 2)
                return name[0] + "*" + "@" + domain;

            string maskedName = name.Substring(0, 2)
                                + new string('*', name.Length - 4)
                                + name.Substring(name.Length - 2);

            return maskedName + "@" + domain;
        }
    }
}
