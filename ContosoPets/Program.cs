using ContosoPets.Data;
using ContosoPets.Models;
using System;

namespace ContosoPets
{
    class Program
    {
        static void Main(string[] args)
        {
            using ContosoPetsContext context = new ContosoPetsContext();

            Product squeakyBone = new Product()
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

        }
    }
}
