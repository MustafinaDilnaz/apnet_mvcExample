using MVCExample.Data;
using MVCExample.Models;

namespace MVCExample
{
    public static class SampleData
    {
        public static void Initialize(MobileContext context)
        {
            if (!context.Phones.Any())
            {
                context.Phones.AddRange(
                    new Phone
                    {
                        Name = "Iphone 11",
                        Company = "Apple",
                        Price = 600
                    },
                    new Phone
                    {
                        Name = "S2",
                        Company = "Samsunng",
                        Price = 700
                    },
                    new Phone
                    {
                        Name = "A31",
                        Company = "Xiaomi",
                        Price = 400
                    }
                    );
                context.SaveChanges();
            }

            if (!context.Books.Any())
            {
              context.Books.AddRange(
                  new Book
                  {
                    Name = "Iphone 11",
                    Price = 600
              
                  },
                  new Book
                  {
                    Name = "S2",
                    Price = 700
                  },
                  new Book
                  {
                    Name = "A31",
                    Price = 400
                  }
                  );
              context.SaveChanges();
            }
            if (!context.Users.Any())
            {
              context.Users.AddRange(
                  new User
                  {
                    FirstName = "Dilnaz",
                    LastName = "Mustafina"

                  },
                  new User
                  {
                    FirstName = "Dami",
                    LastName = "MMM"
                  },
                  new User
                  {
                    FirstName = "DDD",
                    LastName = "DDD"
                  }
                  );
              context.SaveChanges();
            }
            if (!context.Categories.Any())
            {
                context.Categories.AddRange(
                    new Category
                    {
                      Name = "Clothes",
                      Description = "qwqqqqqq"
                    },
                    new Category
                    {
                      Name = "Furniture",
                      Description = "aaaaaaaa"
                    },
                    new Category
                    {
                      Name = "Technics",
                      Description = "zzzzzzzz"
                    },
                    new Category
                    {
                      Name = "Education",
                      Description = "mmmmm"
                    }

                    );
              context.SaveChanges();
            }
            if (!context.Products.Any())
            {
              context.Products.AddRange(
                  new Product
                  {
                    Name="T-shirt",
                    Price = 5000,
                    CategoryId = 1
                  },
                  new Product
                  {
                    Name = "Mobile",
                    Price = 100000,
                    CategoryId = 3
                  },
                  new Product
                  {
                    Name = "Watch",
                    Price = 50000,
                    CategoryId = 3
                  },
                  new Product
                  {
                    Name = "Fork",
                    Price = 400,
                    CategoryId = 2
                  },
                  new Product
                  {
                    Name = "Book",
                    Price = 1000,
                    CategoryId = 4
                  }

                  );
              context.SaveChanges();
            }
        }
  
    }
}
