using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCExample.Data;
using MVCExample.Models;

namespace MVCExample.Controllers
{
  public class BookController : Controller
  {

    private readonly MobileContext _db;

    public BookController(MobileContext context)
    {
      _db = context;
    }

    public IActionResult Index()
    {
      var books = _db.Books.ToList();

      return View(books);
    }

    [HttpGet]
    public IActionResult Create(int id)
    {
      ViewBag.BookId = id;
      return View();
    }
    [HttpPost]
    public string Create(Book book)
    {
      _db.Books.Add(book);
      _db.SaveChanges();
      return $"Thanks for purchasing {book.Name} {book.Price} ";
    }


    public string Details(int id)
    {
      var newBook = _db.Books.Where(book => book.Id == id).FirstOrDefault();
      return $"{newBook.Name} {newBook.Price}";
    }



    [HttpGet]
    public IActionResult Buy(int id)
    {
      ViewBag.BookId = id;
      return View();
    }

    [HttpPost]
    public string Buy(BookOrder bookOrder)
    {
      _db.BookOrders.Add(bookOrder);
      _db.SaveChanges();  
      return $"Thanks for purchasing {bookOrder.Name} {bookOrder.Author} ";
    }

    public string Delete(int id)
    {
      var newBook = _db.Books.Where(book => book.Id == id).FirstOrDefault();
      _db.Remove(newBook);
      _db.SaveChanges();
      return $"Deleted successfully {newBook.Id} {newBook.Price}";

    }

    [HttpGet]
    public IActionResult Update(int id)
    {
      ViewBag.BookId = id;
      return View();
    }

    [HttpPost]
    public string Update(int BookId, String Name, int Price)
    {
      //int bookId = ViewBag.BookId; 
      var newBook = _db.Books.Where(book => book.Id == BookId).FirstOrDefault();
      newBook.Name = Name;
      newBook.Price = Price;
      _db.SaveChanges();
      return $"Deleted successfully {newBook.Id} {newBook.Price}";

    }

  }


}
