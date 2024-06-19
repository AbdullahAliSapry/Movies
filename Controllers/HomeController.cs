using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebsiteMovies.data;
using WebsiteMovies.Models;

namespace WebsiteMovies.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        AppllicationDbContext _context = new AppllicationDbContext();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var Movies = _context.Movies.ToList();
            ViewData["Movies"] = Movies;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //public IActionResult PopularFilms()
        //{
        //    var Movies = _context.Movies.ToList();
        //    ViewData["Movies"]=Movies;
        //    return View("Index");
        //}
    }
}
