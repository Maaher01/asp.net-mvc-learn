using Admin_Portal.Models;
using System;
using System.Linq;

namespace Admin_Portal
{
    internal class Program
    {
        static void Main()
        {
            ProductDbContext db = new ProductDbContext();

            ////Create a new product
            //Console.WriteLine("Product name: ");
            //string name = Console.ReadLine();

            //Console.WriteLine("Price: ");
            //decimal price = decimal.Parse(Console.ReadLine());

            //var product = new Product { ProductName = name, UnitPrice = price };
            //db.Products.Add(product);
            //db.SaveChanges();

            ////View all products
            //var q = from items in db.Products
            //        select items;

            //foreach (var item in q)
            //{
            //    Console.WriteLine($"Product: {item.ProductName}, Price: {item.UnitPrice}");
            //}

            ////Edit a product
            //var product = db.Products.Where(item => item.ProductId == 2).First();

            //product.UnitPrice = 55000;
            //db.SaveChanges();
            //Console.ReadLine();
        }
    }
}
