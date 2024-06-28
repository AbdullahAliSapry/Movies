using WebsiteMovies.Models;

namespace WebsiteMovies.Repository.IRepository
{
    public interface IMovieRepository
    {
        List<Movie> getAllItems(int page,int n );
        Movie getItem(int id);
        List<Movie> Search(string nameMovie);
        void CreateItem(Movie item);

        void EditItem(Movie item);
        void DeleteItem(Movie item);
        int GitCount();

    }
}
