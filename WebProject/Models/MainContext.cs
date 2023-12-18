using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

using static System.Net.Mime.MediaTypeNames;

using System.Xml.Linq;

namespace WebProject.Models
{
    public class MainContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }

        public MainContext(DbContextOptions options) : base(options)
        {
            
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    Product que = new Product()
        //    {
        //        Id = 1,
        //        Name = "AllHero_Poster",
        //        Cost = 3312,
        //        Description = "Museum-quality posters made on thick matte paper. Add a wonderful accent to your room and office with these posters that are sure to brighten any environment",
        //        Count = 5
        //    };
        //    que.Image = @$"img\{que.Name}.png";


        //    Product que2 = new Product()
        //    {
        //        Id = 2,
        //        Name = "ChibiMirana_mousepad",
        //        Cost = 3596,
        //        Description = "With its large size and quality edge stitching, this gaming mouse pad turns your gaming setup into a professional gaming station ready for Dota, CSGO, and more. Don’t worry about jerky mouse movements ever again, as the under layer features a reliable non-slip surface that keeps the entire mat firmly rooted to your table.",
        //        Count = 2
        //    };
        //    que2.Image = @$"img\{que2.Name}.png";
        //    modelBuilder.Entity<Product>().HasData(que, que2);
        //}
    }
}
