using Microsoft.AspNetCore.Mvc;
using EventSystem.ViewModels;
using EventSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using EventSystem.Models;
using Microsoft.AspNetCore.Identity;

namespace EventSystem.Controllers
{
    public class EventsController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public EventsController(ApplicationDbContext context,
            UserManager<IdentityUser> userManager) 
        { 
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> GetAllEvents()
        {
            var allEvents = await _context.Events
                .ToListAsync();

            return View(allEvents);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> RegisterEvent(int eventId)
        {
            var events = await _context.Events
            .Where(e => e.Id == eventId)
            .FirstOrDefaultAsync();


            var viewModel = new EventViewModel
            {
                EventId = eventId,
                EventName = events.Name,
                EventDescription = events.Description,
                EventDate = events.Date,
                TotalSeats = events.TotalSeats,
                SeatsAvailable = events.SeatsAvailable
            };

            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterEevent(EventViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);

                var newRegistration = new Registration
                {
                    EventId = viewModel.EventId,
                    UserId = user.Id,
                    EmailAddress = user.Email,
                    ReferenceNumber = Guid.NewGuid().ToString(),
                };

                _context.Add(newRegistration);
                await _context.SaveChangesAsync();

                return RedirectToPage("BookingSubmittedSuccessfully", "Events");
            }
            return View(viewModel);
        }


        [Authorize]
        public async Task<IActionResult> BookingSubmittedSuccessfully()
        {
            return View();
        }

    }
}
