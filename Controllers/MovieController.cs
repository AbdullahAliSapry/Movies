using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebsiteMovies.data;
using WebsiteMovies.Enums;
using WebsiteMovies.Models;
using WebsiteMovies.Repository;
using WebsiteMovies.Repository.IRepository;
using WebsiteMovies.ViewModel;

namespace WebsiteMovies.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieRepository movieRepo;
        private readonly ICategoryRepository CategoryRepo;
        private readonly ICinemaRepository CinemaRepo;
        public MovieController(IMovieRepository movierepo
            , ICategoryRepository CategoryRepo
            , ICinemaRepository cinemaRepo)
        {
            this.movieRepo = movierepo;
            this.CategoryRepo = CategoryRepo;
            this.CinemaRepo = cinemaRepo;

        }
        public IActionResult AllMovies(int page)
        {
            const int CountToOnePage = 6;
            var Data = movieRepo.getAllItems(page, CountToOnePage);
            
            ViewData["count"] =(int)Math.Floor((double)movieRepo.GitCount() / CountToOnePage);


            return View(Data);
        }

        public IActionResult SingleMove(int MovieId)
        {
            ViewData["Categories"] = CategoryRepo.getAllItems();
            ViewData["Cinemas"] = CinemaRepo.getAllItems(); ;

            var movie = movieRepo.getItem(MovieId);
            if (movie != null)
            {
                ViewData["Category"] =
                    CategoryRepo.getItem(movie.CategoryId);

                ViewData["Cinema"] = CinemaRepo
                    .getItemWithId(movie.CinemaId);
                ViewData["Actors"] = movie.Actors.ToList();
            }
            var newMovie = new MovieVm()
            {
                Id = movie.Id,
                EndDate = movie.EndDate,
                StartDate = movie.StartDate,
                CategoryId = movie.CategoryId,
                CinemaId = movie.CinemaId,
                Description = movie.Description,
                ImgUrl = movie.ImgUrl,
                Name = movie.Name,
                Price = movie.Price,
                TrailerUrl = movie.TrailerUrl

            };
            return View(newMovie);
        }
        public IActionResult FindMovie(string nameMovie)
        {
            var movies = movieRepo.Search(nameMovie);
            return View("AllMovies", movies);
        }

        public IActionResult CreateMovie()
        {
            ViewData["Categories"] = CategoryRepo.getAllItems();
            ViewData["Cinemas"] = CinemaRepo.getAllItems();

            return View();
        }

        [HttpPost]
        public IActionResult CreateMovie(MovieVm movie)
        {

            if (ModelState.IsValid)
            {
                // handling status
                var DateNow = DateTime.Now;
                var movieValid = new Movie()
                {
                    ImgUrl = movie.ImgUrl,
                    TrailerUrl = movie.TrailerUrl,
                    Name = movie.Name,
                    Price = movie.Price,
                    CategoryId = movie.CategoryId,
                    CinemaId = movie.CinemaId,
                    Description = movie.Description,
                };
                if (DateNow.CompareTo(movie.StartDate) == -1)
                {
                    movieValid.MovieStatus = MovieStatus.UpComing;
                }
                else if (DateNow.CompareTo(movie.StartDate) == 1 &&
                    DateNow.CompareTo(movie.EndDate) == -1)
                {
                    movieValid.MovieStatus = MovieStatus.Avlailable;

                }
                else
                {
                    movieValid.MovieStatus = MovieStatus.Expired;
                }

                movieRepo.CreateItem(movieValid);
                TempData["message"] = "Movie Created Successfully";
                return RedirectToAction("AllMovies");

            }

            return View();
        }
        [HttpPost]
        public IActionResult EditMovie(MovieVm movie)
        {

            if (ModelState.IsValid)
            {
                var movieValid = new Movie()
                {
                    Id = movie.Id,
                    ImgUrl = movie.ImgUrl,
                    TrailerUrl = movie.TrailerUrl,
                    Name = movie.Name,
                    Price = movie.Price,
                    CategoryId = movie.CategoryId,
                    CinemaId = movie.CinemaId,
                    Description = movie.Description,
                };
                movieRepo.EditItem(movieValid);
            }

            return RedirectToAction("SingleMove", new { MovieId = movie.Id });
        }
    }
}
