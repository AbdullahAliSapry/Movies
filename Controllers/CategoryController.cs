using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebsiteMovies.data;
using WebsiteMovies.Models;
using WebsiteMovies.Repository;
using WebsiteMovies.Repository.IRepository;
using WebsiteMovies.ViewModel;

namespace WebsiteMovies.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryRepository categoryRepo;

        public CategoryController(ICategoryRepository categoryRepo)
        {
            this.categoryRepo = categoryRepo;
        }
        public IActionResult AllCategory()
        {
            var categories= categoryRepo.getAllItems();
            return View(categories);
        }
        public IActionResult AllMoviesToCategory(string nameCategory)
        {
            var category = categoryRepo.getItem(nameCategory);
            if (category == null)
            {  
                return View("/Views/Movie/AllMovies.cshtml", new List<Movie>());
            }

            var movies = categoryRepo.gitItemsToItem(category.Name,category.Id);

            return View("/Views/Movie/AllMovies.cshtml", movies);

        }


        public IActionResult AddCategory()
        {

            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(CategoryVm category)
        {

            if (ModelState.IsValid)
            {
                // mapping
                var newCategory = new Category()
                {
                    Name = category.Name,

                };
                categoryRepo.CreateItem(newCategory);

                TempData["messageCategory"] = "Category Created successfully";
                return RedirectToAction("AllCategory");
            }

            return View();
        }
    }
}
