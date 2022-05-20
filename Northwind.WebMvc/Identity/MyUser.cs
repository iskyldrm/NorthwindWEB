using Microsoft.AspNetCore.Identity;

namespace Northwind.WebMvc.Identity
{
    public class MyUser : IdentityUser
    {
        public string TCKimlik { get; set; }
    }
}
