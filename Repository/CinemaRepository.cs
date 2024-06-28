using Microsoft.EntityFrameworkCore;
using WebsiteMovies.data;
using WebsiteMovies.Models;
using WebsiteMovies.Repository.IRepository;

namespace WebsiteMovies.Repository
{
    public class CinemaRepository: ICinemaRepository
    {
        private AppllicationDbContext _context;

        public CinemaRepository(AppllicationDbContext _context)
        {
            this._context = _context;
        }
        public List<Cinema> getAllItems()
        {  
            var result=_context.Cinemas.ToList();
            return result;
            
        }
        public Cinema getItemWithId(int id)
        {
            var item = _context.Cinemas.Find(id);
            return item;
        }

    }
}
