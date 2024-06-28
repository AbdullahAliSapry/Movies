using System.ComponentModel.DataAnnotations;

namespace WebsiteMovies.ViewModel
{
    public class CategoryVm
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please Enter Name To Category")]            
        public string Name { get; set; }
    }
}

