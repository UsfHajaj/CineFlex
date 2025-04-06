using ETickets.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ETickets.Controllers
{
    public class CinemaController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CinemaController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var Cinemas = await _context.Cinemas.ToListAsync();
            return View(Cinemas);
        }
    }
}
