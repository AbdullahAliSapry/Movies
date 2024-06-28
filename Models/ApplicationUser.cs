using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebsiteMovies.Models
{
    public class ApplicationUser:IdentityUser
    {
        [MaxLength(450)]
        public string Address {  get; set; }
    }
}
