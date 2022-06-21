namespace MVCExample.Models
{
  public class BookOrder
  {
    public int BookOrderId { get; set; }
    public int BookId { get; set; }
    public string Name { get; set; }
    public string Author { get; set; }
    public Book Book { get; set; }
  }
}
