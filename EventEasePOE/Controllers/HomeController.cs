using EventEasePOE.Data;
using EventEasePOE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventEasePOE.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var events = await _context.Events.Include(e => e.Venue).ToListAsync();
            var venues = await _context.Venues.ToListAsync();
            var bookings = await _context.Bookings.ToListAsync();

            ViewData["Events"] = events;
            ViewData["Venues"] = venues;
            ViewData["Bookings"] = bookings;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
