using ETickets.Data;
using ETickets.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ETickets.Controllers
{
    public class ActorController : Controller
    {
        private readonly IActorServices _services;
        public ActorController(IActorServices services)
        {
            _services = services;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _services.GetAll();
            return View(data);
        }
    }
}
