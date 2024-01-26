using Microsoft.EntityFrameworkCore;
using System.Numerics;
using static System.Net.WebRequestMethods;

namespace WebApplication5.Models
{
    public class ProductContext : DbContext
    {
        //ProductContext db;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Price> Prices { get; set; } = null!;


        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Price pr1 = new Price { /*Id = 1, */MarketName = "Чайник", MarketPrice = 1, Date = DateTime.Now };
            //Price pr2 = new Price { /*Id = 2, */MarketName = "Смартфон", MarketPrice = 2, Date = DateTime.Now };
            //Price pr3 = new Price { /*Id = 3, */MarketName = "Часы", MarketPrice = 3, Date = DateTime.Now };

            Price pr1 = new Price { /*Id = 1, */MarketName = "Чайник", MarketPrice = 1, Date = DateTime.Now };
            Price pr2 = new Price { /*Id = 2, */MarketName = "Смартфон", MarketPrice = 2, Date = DateTime.Now };
            Price pr3 = new Price { /*Id = 3, */MarketName = "Часы", MarketPrice = 3, Date = DateTime.Now };


            //modelBuilder.Entity<Price>().HasData(pr1, pr2, pr3);

            //modelBuilder.Entity<Price>().HasData(
            //    new Price { Id = 1, MarketName = "Чайник", MarketPrice = 1, Date = DateTime.Now },
            //    new Price { Id = 2, MarketName = "Смартфон", MarketPrice = 2, Date = DateTime.Now },
            //    new Price { Id = 3, MarketName = "Часы", MarketPrice = 3, Date = DateTime.Now }
            //    );


            modelBuilder.Entity<Product>().HasData(
            //new Product { Id = 1, Name = "Чайник", Url = "https://metanit.com/sharp/aspnet6/12.2.php", Price = 1, Date = DateTime.Now, MarketName = "Чайник" },
            //new Product { Id = 2, Name = "Смартфон", Url = "https://metanit.com/sharp/aspnet6/12.2.php", Price = 1, Date = DateTime.Now, MarketName = "Смартфон" },
            //new Product { Id = 3, Name = "Часы", Url = "https://metanit.com/sharp/aspnet6/12.2.php", Price = 1, Date = DateTime.Now, MarketName = "Часы" }

            //new Product { Id = 1, Name = "Чайник", Url = "https://metanit.com/sharp/aspnet6/12.2.php", Price = 1 },
            //new Product { Id = 2, Name = "Смартфон", Url = "https://metanit.com/sharp/aspnet6/12.2.php", Price = 1 },
            //new Product { Id = 3, Name = "Часы", Url = "https://metanit.com/sharp/aspnet6/12.2.php", Price = 1 }

            new Product { Id = 1, Name = "Чайник", Url = "https://metanit.com/sharp/aspnet6/12.2.php", Prices = { pr1 } },
            new Product { Id = 2, Name = "Смартфон", Url = "https://metanit.com/sharp/aspnet6/12.2.php", Prices = { pr2 } },
            new Product { Id = 3, Name = "Часы", Url = "https://metanit.com/sharp/aspnet6/12.2.php", Prices = { pr3 } }

            //new Product { Id = 1, Name = "Чайник", Url = "https://metanit.com/sharp/aspnet6/12.2.php", Price = 1 },
            //new Product { Id = 2, Name = "Смартфон", Url = "https://metanit.com/sharp/aspnet6/12.2.php", Price = 1 },
            //new Product { Id = 3, Name = "Часы", Url = "https://metanit.com/sharp/aspnet6/12.2.php", Price = 1 }


            //new Product { Id = 1, Name = "Чайник", Url = "https://metanit.com/sharp/aspnet6/12.2.php", Prices = { Price[0] } },
            //new Product { Id = 2, Name = "Смартфон", Url = "https://metanit.com/sharp/aspnet6/12.2.php", Prices = { pr2 } },
            //new Product { Id = 3, Name = "Часы", Url = "https://metanit.com/sharp/aspnet6/12.2.php", Prices = { pr3 } }

            );

        }

    }
}
