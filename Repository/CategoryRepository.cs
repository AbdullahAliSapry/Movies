using Microsoft.EntityFrameworkCore;
using WebsiteMovies.data;
using WebsiteMovies.Models;
using WebsiteMovies.Repository.IRepository;
using WebsiteMovies.ViewModel;

namespace WebsiteMovies.Repository
{

    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppllicationDbContext _context;

        public CategoryRepository(AppllicationDbContext context)
        {
            this._context = context;
        }


        public List<Category> getAllItems()
        {
            var categories = _context.Categories
                .Include(e => e.Movies).ToList();
            return categories;
        }

        public Category getItem(string nameCategory)
        {
            var category = _context.Categories.
                 FirstOrDefault(c => c.Name == nameCategory);

            return category;
        }
        public void CreateItem(Category category)
        {

            _context.Categories.Add(category);
            _context.SaveChanges();
        }
        public Category getItem(int id)
        {
            var item = _context.Categories.Find(id);
            return item;
        }



        public void EditItem(Category item)
        {
            throw new NotImplementedException();
        }

        public void DeleteItem(Category item)
        {
            throw new NotImplementedException();
        }

        public List<Movie> gitItemsToItem(string name,int id)
        {
            var movies = _context.Movies
                 .Where(e => e.CategoryId ==id)
                 .Include(e => e.Category)
                .Include(e => e.Cinema)
                 .ToList();

            return movies;
        }

        public List<Category> Search(string nameMovie)
        {
            throw new NotImplementedException();
        }
    }
}
