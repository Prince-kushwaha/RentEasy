using System.ComponentModel.DataAnnotations;

namespace CarRentalWebApi.Models
{
    public class LoginModel
    {
        [Required(AllowEmptyStrings = false)]
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
