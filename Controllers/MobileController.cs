using Microsoft.AspNetCore.Mvc;
using MVCExample.Data;
using MVCExample.Models;

namespace MVCExample.Controllers
{
    public class MobileController : Controller
    {
        private readonly MobileContext _db;

        public MobileController(MobileContext context)
        {
            _db = context;
        }

        public IActionResult Index()
        {
            var phones = _db.Phones.ToList();

            return View(phones);
        }

        [HttpGet]
        public IActionResult Buy(int id)
        {
            ViewBag.PhoneId = id;
            return View();
        }

        [HttpPost]
        public string Buy(Order order)
        {
            _db.Orders.Add(order);
            _db.SaveChanges();
            return $"Thanks for purchasing {order.User}";
        }
    }
}
