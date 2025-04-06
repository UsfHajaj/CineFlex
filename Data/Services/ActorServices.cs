using ETickets.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ETickets.Data.Services
{
    public class ActorServices : IActorServices
    {
        private readonly ApplicationDbContext _context;
        public ActorServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(Actor actor)
        {
            _context.Add(actor);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Actor actor=_context.Actors.FirstOrDefault(m=>m.Id == id);
            _context.Remove(actor);
        }

        public Actor GerById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Actor>> GetAll()
        {
            return await _context.Actors.ToListAsync();
        }

        public void Update(int id, Actor actor)
        {
            throw new NotImplementedException();
        }
    }
}
