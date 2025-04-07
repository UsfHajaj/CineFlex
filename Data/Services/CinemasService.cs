using ETickets.Models;

namespace ETickets.Data.Services
{
    public class CinemasService :EntityBaseRepository<Cinema>,ICinemasService
    {
        public CinemasService(ApplicationDbContext context) : base(context)
        {
        }
    }
}
