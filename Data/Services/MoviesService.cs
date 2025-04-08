using ETickets.Models;
using Microsoft.EntityFrameworkCore;

namespace ETickets.Data.Services
{
    public class MoviesService : EntityBaseRepository<Movie>, IMoviesService
    {
        private readonly ApplicationDbContext _context;

        public MoviesService(ApplicationDbContext context):base(context)
        {
            _context = context;
        }

        public async Task AddMovieAsync(MovieVM movieVM)
        {
            var movie = new Movie()
            {
                Title = movieVM.Title,
                Description = movieVM.Description,
                Price = movieVM.Price,
                StartDate = movieVM.StartDate,
                EndDate = movieVM.EndDate,
                ImageUrl = movieVM.ImageURL,
                CinemaId = movieVM.CinemaID,
                ProducerId = movieVM.ProdcerID,
                ReleaseDate= movieVM.ReleaseDate,
                MovieCategory = movieVM.MovieCategory
            };
            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();

            foreach(var actorid in movieVM.ActorIDs)
            {
                var actorMovie = new MovieActors()
                {
                    MovieId = movie.Id,
                    ActorId = actorid

                };
                await _context.MovieActors.AddAsync(actorMovie);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var movie= await _context.Movies
                .Include(m=>m.Cinema)
                .Include(m=>m.Producer)
                .Include(m=>m.MovieActors)
                .ThenInclude(ma=>ma.Actor)
                .FirstOrDefaultAsync(m => m.Id == id);
            return movie;
        }

        public async Task<MovieDropDownsVM> GetMovieDropDownsValues()
        {
            var response=new MovieDropDownsVM();
            response.Actors=await _context.Actors.OrderBy(m=>m.FullName).ToListAsync();
            response.Producers = await _context.Producers.OrderBy(m => m.FullName).ToListAsync();
            response.Cinemas = await _context.Cinemas.OrderBy(m => m.Name).ToListAsync();
            return response;
        }

        public async Task UpdateMovieAsync(MovieVM movieVM)
        {
            var moviedbyid = await _context.Movies.FirstOrDefaultAsync(m => m.Id == movieVM.ID);
            if (moviedbyid != null)
            {
                moviedbyid.Title = movieVM.Title;
                moviedbyid.Description = movieVM.Description;
                moviedbyid.Price = movieVM.Price;
                moviedbyid.StartDate = movieVM.StartDate;
                moviedbyid.EndDate = movieVM.EndDate;
                moviedbyid.ImageUrl = movieVM.ImageURL;
                moviedbyid.CinemaId = movieVM.CinemaID;
                moviedbyid.ProducerId = movieVM.ProdcerID;
                moviedbyid.ReleaseDate = movieVM.ReleaseDate;
                moviedbyid.MovieCategory = movieVM.MovieCategory;


                var exexistingActorLinks = await _context.MovieActors
                    .Where(m => m.MovieId == movieVM.ID)
                    .ToListAsync();
                _context.MovieActors.RemoveRange(exexistingActorLinks);

                foreach(var actorId in movieVM.ActorIDs)
                {
                    var actorMovie = new MovieActors
                    {
                        MovieId = movieVM.ID,
                        ActorId = actorId
                    };
                    await _context.MovieActors.AddAsync(actorMovie);
                }
                await _context.SaveChangesAsync();
            }
        }
    }
}
