using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace WebApp.Controllers
{
    public class EventController : Controller
    {
        private static List<Event> Events = new List<Event>
        {
            new Event { Id = 1, Name = "Tech Talk", Description = "A talk on latest technology trends.", Date = new DateTime(2024, 7, 10) },
            new Event { Id = 2, Name = "Workshop", Description = "Hands-on workshop for students.", Date = new DateTime(2024, 7, 15) }
        };
        private static List<EventRegistration> Registrations = new List<EventRegistration>();

        public IActionResult Register()
        {
            ViewBag.Events = Events;
            ViewBag.Registrations = Registrations;
            return View();
        }

        [HttpPost]
        public IActionResult Register(EventRegistration registration)
        {
            if (ModelState.IsValid)
            {
                bool isDuplicate = Registrations.Any(r => r.EventId == registration.EventId && r.StudentEmail.ToLower() == registration.StudentEmail.ToLower());
                if (isDuplicate)
                {
                    ViewBag.Events = Events;
                    ViewBag.Registrations = Registrations;
                    ViewBag.Error = "This student is already registered for the selected event.";
                    return View(registration);
                }
                Registrations.Add(registration);
                return RedirectToAction("Register");
            }
            ViewBag.Events = Events;
            ViewBag.Registrations = Registrations;
            return View(registration);
        }

        public IActionResult Dashboard()
        {
            var eventStats = Events.Select(e => new
            {
                EventName = e.Name,
                Count = Registrations.Count(r => r.EventId == e.Id)
            }).ToList();
            ViewBag.EventStats = eventStats;
            ViewBag.Events = Events;
            ViewBag.Registrations = Registrations;
            return View();
        }
    }
}