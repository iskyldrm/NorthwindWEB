using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Northwind.DAL.Abstract;

namespace Northwind.WebMvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class CustomerController : Controller
    {

        private readonly ICustomerDal db;

        public CustomerController(ICustomerDal db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            var result = db.GetAll();
            return View(result);
        }
    }
}
