using ETickets.Data;
using ETickets.Data.DTOs;
using ETickets.Data.Services;
using ETickets.Data.Static;
using ETickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ETickets.Controllers
{
    public class CinemaController : Controller
    {
        private readonly ICinemasService _service;
        public CinemaController(ICinemasService service)
        {
            _service = service;
        }

        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> Index()
        {
            var Cinemas = await _service.GetAllAsync();
            return View(Cinemas);
        }


        [Authorize(Roles = UserRoles.Admin)]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> Create(CinemaDto cinemaDto)
        {
            if (!ModelState.IsValid)
            {
                return View(cinemaDto);
            }
            var cinema = new Cinema()
            {
                Logo = cinemaDto.Logo,
                Name = cinemaDto.Name,
                Description = cinemaDto.Description
            };
            await _service.AddAsync(cinema);

            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var cinema = await _service.GetByIdAsync(id);
            if (cinema == null)
            {
                return View("NotFound");
            }
            return View(cinema);
        }
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> Edit(int id)
        {
            var cinema = await _service.GetByIdAsync(id);
            if (cinema == null)
            {
                return View("NotFound");
            }
            return View(cinema);
        }
        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> Edit(int id, CinemaDto cinemaDto)
        {
            if (!ModelState.IsValid)
            {
                return View(cinemaDto);
            }
            var cinema = await _service.GetByIdAsync(id);
            if (cinema == null)
            {
                return View("NotFound");
            }
            cinema.Name = cinemaDto.Name;
            cinema.Description = cinemaDto.Description;
            cinema.Logo = cinemaDto.Logo;
            await _service.UpdateAsync(cinema);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> Delete(int id)
        {
            var cinema = await _service.GetByIdAsync(id);
            if (cinema == null)
            {
                return View("NotFound");
            }
            await _service.DeleteAsync(cinema);
            return Json(new { success = true });
        }
    }
}
