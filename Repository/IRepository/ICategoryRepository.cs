using WebsiteMovies.Models;

namespace WebsiteMovies.Repository.IRepository
{
    public interface ICategoryRepository
    {
        List<Category> getAllItems();
        Category getItem(int id);
        Category getItem(string  name);
        List<Category> Search(string nameMovie);
        void CreateItem(Category item);

        void EditItem(Category item);
        void DeleteItem(Category item);
        List<Movie> gitItemsToItem(string name, int id);
    }
}
