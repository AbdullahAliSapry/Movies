using WebsiteMovies.Models;

namespace WebsiteMovies.Repository.IRepository
{
    public interface ICinemaRepository
    {
         List<Cinema> getAllItems();

        Cinema getItemWithId(int Id);

    }
}
