using Azure;
using Microsoft.EntityFrameworkCore;
using WebsiteMovies.data;
using WebsiteMovies.Enums;
using WebsiteMovies.Models;
using WebsiteMovies.Repository.IRepository;
using WebsiteMovies.ViewModel;

namespace WebsiteMovies.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly AppllicationDbContext _context;

        public MovieRepository(AppllicationDbContext context)
        {
            this._context = context;
        }

        public List<Movie> getAllItems(int page, int CountToOnePage)
        {
            if (page < 1) page = 1;

            List<Movie> result = new List<Movie>();

            try
            {
                var movies = _context.Movies
                    .Include(e => e.Cinema)
                    .Include(p => p.Category)
                    .Skip((page - 1) * CountToOnePage)
                    .Take(CountToOnePage)
                    .ToList();
                return movies;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return result;
        }

        public Movie getItem(int MovieId)
        {
            var movie = _context.Movies.Include(e => e.Actors)
                     .FirstOrDefault(e => e.Id == MovieId);

            return movie;
        }


        public List<Movie> Search(string nameMovie)
        {
            var movies = _context.Movies.
                Where(e => e.Name.Contains(nameMovie)).
                Select(e => e).Include(e => e.Category).
                Include(e => e.Cinema).ToList();

            return movies;
        }


        public void CreateItem(Movie movie)
        {

            _context.Movies.Add(movie);
            _context.SaveChanges();
        }


        public void EditItem(Movie movie)
        {
            _context.Movies.Update(movie);
            _context.SaveChanges();
        }



        public void DeleteItem(Movie item)
        {
            throw new NotImplementedException();
        }


        public int GitCount()
        {
            var totalCount = _context.Movies.Count();

            return totalCount;
        }
    }
}
