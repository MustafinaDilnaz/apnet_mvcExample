using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Encodings.Web;
using MVCExample.Models;

namespace MVCExample.Controllers
{
  public class CityController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Create(string name, int population, double area)
    {
       
      //return Content($"{name} {population} {area}");
      List<NewUser> users = new()
      {
        new NewUser { Id = 1, Name = "Dilya", Age = 22 },
        new NewUser { Id = 2, Name = "Dami", Age = 20 }
      };
      ViewBag.Users = new SelectList( users, "Id", "Name");
      return View();
    }

  }
}
