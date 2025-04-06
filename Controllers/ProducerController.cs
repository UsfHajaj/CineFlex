using ETickets.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ETickets.Controllers
{
    public class ProducerController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProducerController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var Producers = await _context.Producers.ToListAsync();
            return View(Producers);
        }
    }
}
