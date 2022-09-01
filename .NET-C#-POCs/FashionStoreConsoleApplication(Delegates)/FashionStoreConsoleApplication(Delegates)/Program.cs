using FashionProject;
using System;

namespace FashionStoreConsoleApplication_Delegates_
{
    class Program
    {
        static void Main(string[] args)
        {
            Product product = new Product();
            Category cat = new Category();
            Console.WriteLine("Enter Ur Option");
            Console.WriteLine("1:Enter ur role");
            int option = int.Parse(Console.ReadLine());
            Console.WriteLine("enter role");
            string role = Console.ReadLine();
                      
            switch (option)
            {
             case 1:
                    if(role=="category")
                    {
                        Func<string, string> func = cat.AddCat;
                        func(role);
                    }
                    else if(role=="product")
                    {
                        Action<string> action = product.AllProducts;
                        action(role);
                    }
                    else
                    {
                        Console.WriteLine("Invalid role");
                    }
                   
                    break;
                default:
                    Console.WriteLine("invalid options");
                    break;
            }
        }
    }
}
