using System.ComponentModel.DataAnnotations;

namespace WebsiteMovies.ViewModel
{
    public class ApplicationUserVm
    {
        public int Id { get; set; }

        [MinLength(5,ErrorMessage ="Min Length to Name is 5")]
        [MaxLength(50, ErrorMessage = "Max Length to Name is 50")]
        [Required(ErrorMessage = "Name is Required")]
        public string userName { get; set;}
        [DataType(DataType.EmailAddress)]
        public string email { get; set;}
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string PasswordConfirmed { get; set;}
        public string? Address { get; set;}

    }
}
