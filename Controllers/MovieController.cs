using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebsiteMovies.data;

namespace WebsiteMovies.Controllers
{
    public class MovieController : Controller
    {   
        AppllicationDbContext _context=new AppllicationDbContext();
        public IActionResult AllMovies()
        {
            var movies= _context.Movies.
                Include(e=>e.Cinema).Include(p=>p.Category).ToList();
            return View(movies);
        }     
        public IActionResult SingleMove(int MovieId)
        {
            var movie = _context.Movies.Include(e=>e.Cinema)
                .Include(p => p.Category).Include(a=>a.Actors).FirstOrDefault(e=>e.Id== MovieId);
                
            return View(movie);
        }
        public IActionResult FindMovie(string nameMovie)
        {
            Console.WriteLine(nameMovie);
            var movies = _context.Movies.Where(e=>e.Name==nameMovie).Select(e=>e).Include(e=>e.Category).Include(e=>e.Cinema).ToList();
            return View("AllMovies", movies);
        }
    }
}
