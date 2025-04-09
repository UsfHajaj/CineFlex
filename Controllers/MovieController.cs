using ETickets.Data;
using ETickets.Data.Services;
using ETickets.Data.Static;
using ETickets.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ETickets.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMoviesService _service;
        public MovieController(IMoviesService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index(MovieCategory? category)
        {
            var movies = await _service.GetAllAsync(m=>m.Cinema);
            if (category.HasValue)
            {
                ViewBag.SelectedCategory = category;
                movies = movies.Where(m => m.MovieCategory == category).ToList();
            }
            else
            {
                ViewBag.SelectedCategory = null;
            }
            return View("Index", movies);
        }
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var movie=await _service.GetMovieByIdAsync(id);
            if (movie == null)
            {
                return View("NotFound");
            }
            return View(movie);
        }
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> Create()
        {
            var movieDropDownValue = await _service.GetMovieDropDownsValues();
            ViewBag.Cinemas = new SelectList(movieDropDownValue.Cinemas,  "Id", "Name" );
            ViewBag.Producers = new SelectList(movieDropDownValue.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropDownValue.Actors, "Id", "FullName");
            return View();
        }

        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> Create(MovieVM movieVM)
        {
            if (!ModelState.IsValid)
            {
                var movieDropDownValue = await _service.GetMovieDropDownsValues();
                ViewBag.Cinemas = new SelectList(movieDropDownValue.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(movieDropDownValue.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(movieDropDownValue.Actors, "Id", "FullName");
            }
            await _service.AddMovieAsync(movieVM);
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> Edit(int id)
        {
            var movie = await _service.GetMovieByIdAsync(id);
            if (movie == null)
                return View("NotFound");
            var response = new MovieVM()
            {
                ID = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                Price = movie.Price,
                StartDate = movie.StartDate,
                EndDate = movie.EndDate,
                ImageURL = movie.ImageUrl,
                CinemaID = movie.CinemaId,
                ProdcerID = movie.ProducerId,
                MovieCategory = movie.MovieCategory,
                ReleaseDate = movie.ReleaseDate,
                ActorIDs = movie.MovieActors.Select(n => n.ActorId).ToList(),
            };
            var movieDropDownValue = await _service.GetMovieDropDownsValues();
            ViewBag.Cinemas = new SelectList(movieDropDownValue.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropDownValue.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropDownValue.Actors, "Id", "FullName");
            return View(response);
        }
        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> Edit(int id,MovieVM movieVM)
        {
            if (id!=movieVM.ID)
                return View("NotFound");
            if (!ModelState.IsValid)
            {
                var movieDropDownValue = await _service.GetMovieDropDownsValues();
                ViewBag.Cinemas = new SelectList(movieDropDownValue.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(movieDropDownValue.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(movieDropDownValue.Actors, "Id", "FullName");
                return View(movieVM);
            }
            await _service.UpdateMovieAsync(movieVM);
            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchTerm)
        {
            var movies = await _service.GetAllAsync(m => m.Cinema);

            if (!string.IsNullOrEmpty(searchTerm))
            {
                ViewData["SearchTerm"] = searchTerm;
                searchTerm = searchTerm.Trim().ToLower();
                movies = movies.Where(m =>
                    m.Title.ToLower().Contains(searchTerm) ||
                    m.Description.ToLower().Contains(searchTerm) ||
                    m.MovieCategory.ToString().ToLower().Contains(searchTerm)
                ).ToList();
            }
            return View("Filter", movies);
        }

    }
}
