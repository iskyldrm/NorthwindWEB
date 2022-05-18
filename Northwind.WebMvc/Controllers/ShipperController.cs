using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Northwind.DAL.Abstract;

namespace Northwind.WebMvc.Controllers
{
    [Authorize]
    public class ShipperController : Controller
    {
        private readonly IShippersDal db;

        public ShipperController(IShippersDal db)
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
