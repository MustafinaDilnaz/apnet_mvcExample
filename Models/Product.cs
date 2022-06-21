namespace MVCExample.Models
{
  public class Product
  {
    public int ProductId { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public int CategoryId { get; set; }
    public Category category { get; set; }
    public string? ImgUrl { get; set; }
  }
}
