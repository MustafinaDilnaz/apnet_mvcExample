using Microsoft.EntityFrameworkCore;
using MVCExample.Models;

namespace MVCExample.Data
{
    public class MobileContext : DbContext
    {
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookOrder> BookOrders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }


    public MobileContext(DbContextOptions<MobileContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }
    }
}
