using CustomerProject;
using ProductProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceConsoleProject
{
    public class Product:IProduct
    {
        List<ProductDetails> product = new List<ProductDetails>();
        public List<ProductDetails> AddProduct()
        {
            ProductDetails productDetails = new ProductDetails();
            Console.WriteLine("Enter following information to add new product:");
            Console.WriteLine("Enter product name");
            productDetails.ProductName = Console.ReadLine();
            Console.WriteLine("Enter product price");
            productDetails.Price = int.Parse(Console.ReadLine());
            Console.WriteLine( "Product Name:"  + productDetails.ProductName + "\n" + " Product Price:" + productDetails.Price+"\n");
            return product;
        }
       

    }
}
