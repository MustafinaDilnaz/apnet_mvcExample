using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCExample.Data;
using MVCExample.Models;


namespace MVCExample.Controllers
{
  public class UserController : Controller
  {
    private readonly MobileContext _db;

    public UserController(MobileContext context)
    {
      _db = context;
    }

    public IActionResult Index()
    {
      var users = _db.Users.ToList();
      return View(users);
    }
    public string Details(int id)
    {
      var newUser = _db.Users.Where(user => user.UserId == id).FirstOrDefault();
      return $"{newUser.FirstName} {newUser.LastName}";
    }
    [HttpGet]
    public IActionResult SeeBooks(int id)
    {
      ViewBag.UserId = id;
      var newUser = _db.Users
        .Where(user => user.UserId == id)
        .Include(x=>x.books)
        .FirstOrDefault();
      ViewBag.FirstName = newUser.FirstName;
      ViewBag.LastName = newUser.LastName;
      return View(newUser.books);
    }

    [HttpPost]
    public string SeeBooks(BookOrder bookOrder)
    {
      _db.BookOrders.Add(bookOrder);
      _db.SaveChanges();
      return $"Thanks for purchasing {bookOrder.Name} {bookOrder.Author} ";
    }

    //[HttpGet]
    //public IActionResult AddBookToUser(int id)
    //{
      
    //}

    //[HttpPost]
    //public string AddBookToUser(BookOrder bookOrder)
    //{
      
    //}

  }
}
