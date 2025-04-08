using ETickets.Models;

namespace ETickets.Data.Services
{
    public interface IMoviesService:IEntityBaseRepository<Movie>
    {
        Task<Movie> GetMovieByIdAsync(int id);
        Task<MovieDropDownsVM> GetMovieDropDownsValues();
        Task AddMovieAsync(MovieVM movieVM);
        Task UpdateMovieAsync(MovieVM movieVM);
    }
}
