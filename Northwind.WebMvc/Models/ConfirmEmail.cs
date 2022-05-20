namespace Northwind.WebMvc.Models
{
    public class ConfirmEmail
    {
        public string Email { get; set; }
        public string ErrorDescription { get; set; }
        public bool HasError { get; set; }
    }
}
