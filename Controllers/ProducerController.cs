using ETickets.Data;
using ETickets.Data.DTOs;
using ETickets.Data.Services;
using ETickets.Models;
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
        public async Task<IActionResult> Index()
        {
            var Producers = await _service.GetAllAsync();
            return View(Producers);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
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
        public async Task<IActionResult> Details(int id)
        {
            var producer=await _service.GetByIdAsync(id);
            if (producer == null) 
            {
                return View("NotFound");
            }
            return View(producer);
        }
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
