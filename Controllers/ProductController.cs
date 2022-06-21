using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCExample.Data;
using MVCExample.Models;
using MVCExample.Repositories;

namespace MVCExample.Controllers
{
  public class ProductController : Controller
  {
    private IWebHostEnvironment _webHostEnvironment; 
    private IProductRepository _repo; 

     public ProductController(IProductRepository repo, IWebHostEnvironment webHostEnvironment)
     {
        _repo = repo;
      this._webHostEnvironment = webHostEnvironment;
     }
    // GET: ProductController
    public ActionResult Index()
    {
      var products = _repo.GetAllProducts();
      return View(products);
    }

    public ActionResult Details(int id)
    {
      ViewBag.Product = _repo.GetProduct(id);
      return View();
    }

    public IActionResult Update(IFormFile img)
    {
      var path = $"{_webHostEnvironment.ContentRootPath}\\Img{img.FileName}";
      using var stream = System.IO.File.Create(path);
      img.CopyTo(stream);

      var product = _repo.GetProduct(1);
      product.ImgUrl = $"~/Img/{img.FileName}";
      _repo.Update(1,product);
      return Ok($"~/Img/{img.FileName}");
    }

  }
}
