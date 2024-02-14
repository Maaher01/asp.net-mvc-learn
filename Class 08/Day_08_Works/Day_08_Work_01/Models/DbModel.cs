using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Day_08_Work_01.Models
{
        public class Category
        {
            public int CategoryId { get; set; }
            [Required, StringLength(50)]
            public string CategoryName { get; set; }
            //Navigation
            public ICollection<Product> Products { get; set; } = new List<Product>();
        }

        public class Product
        {
            public int ProductId { get; set;}
            [Required, StringLength(50)]
            public string ProductName { get; set;}
            [Required, Column(TypeName ="money")]
            public decimal Price { get; set; }
            [Required, ForeignKey("Category")]
            public int CategoryId { get; set; }
            //Navigation
            public Category Category { get; set;}
        }

        public class ProductDbContext : DbContext
        {
            public ProductDbContext() 
            { 
                Database.SetInitializer(new DbInitializer());
            }

            public DbSet<Product> Products { get; set; }
            public DbSet<Category> Categories { get; set; }
        }

        public class DbInitializer: DropCreateDatabaseIfModelChanges<ProductDbContext>
        {
            protected override void Seed(ProductDbContext context)
            {
                Category c = new Category { CategoryName="Beverages" };
                c.Products.Add(new Product { ProductName = "Coca Cola", Price = 30.00M });
                c.Products.Add(new Product { ProductName = "Sprite", Price = 25.50M });
                context.Categories.Add(c);
                context.SaveChanges();
            }
        }
}