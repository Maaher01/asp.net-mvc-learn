using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Admin_Portal.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required, StringLength(40)]
        public string ProductName { get; set; }

        [Required, Column(TypeName = "money")]
        public decimal UnitPrice { get; set; }
    }

    public class ProductDbContext: DbContext
    {
        public ProductDbContext() {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ProductDbContext>());
        }

        public DbSet<Product> Products { get; set; }
    }
}
