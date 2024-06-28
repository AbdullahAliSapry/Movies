using Microsoft.AspNetCore.Mvc;

namespace WebsiteMovies.Controllers
{
    public class ShoppingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
