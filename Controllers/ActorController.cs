using Microsoft.AspNetCore.Mvc;
using WebsiteMovies.data;

namespace WebsiteMovies.Controllers
{
    public class ActorController : Controller
    {
        AppllicationDbContext _context=new AppllicationDbContext();

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetOneActor(int ActorId)
        {
            var Actor = _context.Actors.Find(ActorId);
            return View(Actor);
        }
    }
}
