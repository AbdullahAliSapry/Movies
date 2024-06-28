using System.ComponentModel.DataAnnotations;
using WebsiteMovies.Models;

namespace WebsiteMovies.ViewModel
{
    public class MovieVm
    {
        [Key]
        public int Id { get; set; }
        [MinLength(4),MaxLength(100)]
        public string Name { get; set; }
        [MinLength(10)]
        public string Description { get; set; }
        [Url(ErrorMessage ="Please Enter Correct Url")]
        public string ImgUrl { get; set; }

        [Url(ErrorMessage = "Pleas e Enter Correct Url")]
        public string TrailerUrl { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        public int Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CinemaId { get; set; }
        public int CategoryId { get; set; }

    }
}
