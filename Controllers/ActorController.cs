using ETickets.Data;
using ETickets.Data.DTOs;
using ETickets.Data.Services;
using ETickets.Models;
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
            var data = await _services.GetAllAsync();
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ActorDto actorDto)
        {
            if (!ModelState.IsValid)
            {
                return View(actorDto);
            }
            var actor = new Actor()
            {
                ProfilePictureUrl = actorDto.ProfilePictureUrl,
                FullName = actorDto.FullName,
                Bio = actorDto.Bio
            };
            _services.AddAsync(actor);

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Details(int id)
        {
            var actor = await _services.GetByIdAsync(id);
            if(actor == null)
            {
                return View("NotFound");
            }
            return View(actor);
            
        }
        public async Task<IActionResult> Edit(int id)
        {
            var actor = await _services.GetByIdAsync(id);
            if (actor == null)
            {
                return View("NotFound");
            }
            return View(actor);
        }
        [HttpPost]
        public async Task<IActionResult> Edit([FromRoute] int id,ActorDto actorDto)
        {
            if (!ModelState.IsValid)
                return View(actorDto);
            var actor = await _services.GetByIdAsync(id);
            if (actor == null)
            {
                return View("NotFound");
            }

            actor.FullName = actorDto.FullName;
            actor.ProfilePictureUrl = actorDto.ProfilePictureUrl;
            actor.Bio = actorDto.Bio;
           
            await _services.UpdateAsync(actor);
            return RedirectToAction(nameof(Index));
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var actor = await _services.GetByIdAsync(id);
            if (actor == null)
            {
                return View("NotFound");
            }
            
            await _services.DeleteAsync(actor);
            return Json(new { success = true });
        }
    }
}
