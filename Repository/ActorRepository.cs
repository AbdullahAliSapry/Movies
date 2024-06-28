using WebsiteMovies.data;
using WebsiteMovies.Models;
using WebsiteMovies.Repository.IRepository;

namespace WebsiteMovies.Repository
{
    public class ActorRepository:IActorRepsitory
    {
        private readonly AppllicationDbContext _context;

        public ActorRepository(AppllicationDbContext context)
        {
            this._context = context;
        }
        public Actor gitItem(int id)
        {
            var Actor = _context.Actors.Find(id);

            return Actor;
        }

    }
}
