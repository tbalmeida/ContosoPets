using ContosoPets.Data;
using ContosoPets.Models;
using System;
using System.Linq;

namespace ContosoPets
{
    class Program
    {
        static void Main(string[] args)
        {
            using ContosoPetsContext context = new ContosoPetsContext();

            var squeakyBone = context.Products
                .Where(p => p.Name == "Squeaky Dog Bone")
                .FirstOrDefault();

            if (squeakyBone is Product)
            {
                // step 3 - update the price
                // squeakyBone.Price = 7.99M;

                context.Remove(squeakyBone);
            }
            context.SaveChanges();

            // step 1 - Product creation
            /* 
             * Product squeakyBone = new Product()
             {
                 Name = "Squeacky Dog Bone",
                 Price = 4.99M
             };
             context.Products.Add(squeakyBone);

             Product tennisBalls = new Product()
             {
                 Name = "Tennis Ball 3-Pack",
                 Price = 9.99M
             };
             context.Add(tennisBalls);

             context.SaveChanges();
             */
             // end step 1

             // step 2 - read and output to console.
            var products = context.Products
                .Where(p => p.Price >= 5.00M)
                .OrderBy(p => p.Name);
            /*
            // alternative using LINQ. Use the one above OR below, not both
            
            var products = from product in context.Products
                           where product.Price > 5.00M
                           orderby product.Name
                           select product;
            
            */
            foreach (Product p in products)
            {
                Console.WriteLine($"Id: {p.Id}");
                Console.WriteLine($"Name: {p.Name}");
                Console.WriteLine($"Price: {p.Price}");
                Console.WriteLine(new String('-', 20));
            }
            
            // end step 2
        }
    }
}
