using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebsiteMovies.data;
using WebsiteMovies.Models;

namespace WebsiteMovies.Controllers
{
    public class CategoryController : Controller
    {
        AppllicationDbContext _context = new AppllicationDbContext();
        public IActionResult AllCategory()
        {
            var categories= _context.Categories
                .Include(e=>e.Movies).ToList();
            return View(categories);
        }
        public IActionResult AllMoviesToCategory(string nameCategory)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Name == nameCategory);
            if (category == null)
            {  
                return View("/Views/Movie/AllMovies.cshtml", new List<Movie>());
            }

            var movies = _context.Movies
                .Where(e => e.CategoryId == category.Id)
                .Include(e => e.Category)
                .Include(e => e.Cinema)
                .ToList();

            return View("/Views/Movie/AllMovies.cshtml", movies);

        }
    }
}
