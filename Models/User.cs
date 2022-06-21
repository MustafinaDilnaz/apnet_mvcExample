namespace MVCExample.Models
{
  public class User
  {
    public int UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public List<Book> books {get; set;}
  }
}
