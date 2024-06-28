using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebsiteMovies.data;
using WebsiteMovies.Models;
using WebsiteMovies.Repository.IRepository;

namespace WebsiteMovies.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly AppllicationDbContext _context;


        public HomeController(ILogger<HomeController> logger,
            AppllicationDbContext context)
        {
            this._logger = logger;
            this._context = context;
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


    }
}
