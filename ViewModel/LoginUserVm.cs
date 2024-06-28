using System.ComponentModel.DataAnnotations;

namespace WebsiteMovies.ViewModel
{
    public class LoginUserVm
    {
        public int Id { get; set; }

        [MinLength(5, ErrorMessage = "Min Length to Name is 5")]
        [MaxLength(50, ErrorMessage = "Max Length to Name is 50")]
        [Required(ErrorMessage = "User Name is Required")]
        public string userName { get; set; }
        [DataType(DataType.Password,ErrorMessage ="Password Must Be strong")]
        public string Password { get; set; }
        public bool rememberMe { get; set; }
    }
}
