using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using web.Models;
using System.Linq;

namespace web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public List<Event> Events { get; set; } = new();
        public Dictionary<int, List<StudentRegistration>> RegistrationsByEvent { get; set; } = new();

        [BindProperty]
        public StudentRegistration Registration { get; set; } = new();

        public string? ErrorMessage { get; set; }

        public void OnGet()
        {
            Events = EventDataStore.Events;
            RegistrationsByEvent = EventDataStore.Registrations
                .GroupBy(r => r.EventId)
                .ToDictionary(g => g.Key, g => g.ToList());
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                OnGet();
                return Page();
            }
            // Check for duplicate registration
            bool alreadyRegistered = EventDataStore.Registrations.Any(r =>
                r.EventId == Registration.EventId &&
                r.StudentEmail.Trim().ToLower() == Registration.StudentEmail.Trim().ToLower()
            );
            if (alreadyRegistered)
            {
                ErrorMessage = "You have already registered for this event with this email.";
                OnGet();
                return Page();
            }
            // Add registration
            EventDataStore.Registrations.Add(new StudentRegistration
            {
                EventId = Registration.EventId,
                StudentName = Registration.StudentName,
                StudentEmail = Registration.StudentEmail
            });
            return RedirectToPage();
        }
    }
}
