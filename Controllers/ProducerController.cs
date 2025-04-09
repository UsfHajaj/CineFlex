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
    public class ProducerController : Controller
    {
        private readonly IProducersService _service;
        public ProducerController(IProducersService service)
        {
            _service = service;
        }
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> Index()
        {
            var Producers = await _service.GetAllAsync();
            return View(Producers);
        }
        [Authorize(Roles = UserRoles.Admin)]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> Create(ProducerDto producerDto)
        {
            if (!ModelState.IsValid)
            {
                return View(producerDto);
            }
            var producer = new Producer()
            {
                ProfilePictureUrl = producerDto.ProfilePictureUrl,
                FullName = producerDto.FullName,
                Bio = producerDto.Bio
            };
            await _service.AddAsync(producer);

            return RedirectToAction(nameof(Index));
        }
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var producer=await _service.GetByIdAsync(id);
            if (producer == null) 
            {
                return View("NotFound");
            }
            return View(producer);
        }
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> Edit(int id)
        {
            var producer = await _service.GetByIdAsync(id);
            if (producer == null)
            {
                return View("NotFound");
            }
            return View(producer);
        }
        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> Edit(int id,ProducerDto producerDto)
        {
            if (!ModelState.IsValid)
            {
                return View(producerDto);
            }
            var producer = await _service.GetByIdAsync(id);
            if (producer == null)
            {
                return View("NotFound");
            }
            producer.FullName = producerDto.FullName;
            producer.Bio=producerDto.Bio;
            producer.ProfilePictureUrl=producerDto.ProfilePictureUrl;
            await _service.UpdateAsync(producer);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> Delete(int id)
        {
            var producer = await _service.GetByIdAsync(id);
            if(producer== null)
            {
                return View("NotFound");
            }
            await _service.DeleteAsync(producer);
            return Json(new { success = true });
        }
    }
}
