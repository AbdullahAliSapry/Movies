using Microsoft.AspNetCore.Mvc;
using WebsiteMovies.data;
using WebsiteMovies.Repository.IRepository;

namespace WebsiteMovies.Controllers
{
    public class ActorController : Controller
    {
        private IActorRepsitory actorRepo;

        public ActorController(IActorRepsitory actor)
        {
            this.actorRepo = actor;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetOneActor(int ActorId)
        {
          var Actor = actorRepo.gitItem(ActorId);
            return View(Actor);
        }
    }
}
