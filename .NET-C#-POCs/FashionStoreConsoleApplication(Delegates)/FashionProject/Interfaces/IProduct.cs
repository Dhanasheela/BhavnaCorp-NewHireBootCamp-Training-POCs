using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionProject
{
    public interface IProduct
    {
       
        public string AddProduct(ProductDetails products);
        public void AllProducts(string role);
        public void DisplayList();
        public void DeleteProduct(int pid);
        public int UpdateProduct(int pid);
        public bool Search(string name);
    }
}
