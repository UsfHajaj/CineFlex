using ETickets.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ETickets.Data.Services
{
    public class ActorServices : EntityBaseRepository<Actor>,IActorServices
    {
        

        public ActorServices(ApplicationDbContext context) : base(context) { }
        
    }

}
