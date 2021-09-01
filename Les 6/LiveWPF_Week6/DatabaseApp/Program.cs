using LiveWPF_Week6.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DatabaseApp
{
    class Program
    {



        static void Main(string[] args)
        {
            using (var context = new ShoppingCardContext())
            {
                /*context.Database.EnsureCreated();

                var catCPU = new ItemCatogory { Code = "CPU" };
                context.ItemCatogories.Add(catCPU);

                context.ShoppingItem.Add(new ShoppingItem
                {
                    ItemCatogory = catCPU,
                    Name = "I7-9700k",
                    Description = "Fast CPU"
                });
                context.ShoppingItem.Add(new ShoppingItem
                {
                    ItemCatogory = catCPU,
                    Name = "I7-9900k",
                    Description = "Super Fast CPU"
                });

                context.SaveChanges();*/


                var results = context.ShoppingItem.Include(c => c.ItemCatogory).ToList();

              foreach(var r in context.ShoppingItem)
                {
                    Console.WriteLine(r + $" {r.ItemCatogory}");
                }
                           

            }
        }
    }
}
