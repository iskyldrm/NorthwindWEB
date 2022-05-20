using System.ComponentModel.DataAnnotations;

namespace Northwind.WebMvc.Models
{
    public class LoginModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RemeberMe { get; set; } = false;
        public string Token { get; set; }

    }
}
