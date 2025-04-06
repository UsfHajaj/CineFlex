using ETickets.Models;

namespace ETickets.Data.Services
{
    public interface IActorServices
    {
        Task<IEnumerable<Actor>> GetAll();
        Actor GerById(int id);
        void Add(Actor actor);
        void Update(int id,Actor actor);
        void Delete(int id);
    }
}
