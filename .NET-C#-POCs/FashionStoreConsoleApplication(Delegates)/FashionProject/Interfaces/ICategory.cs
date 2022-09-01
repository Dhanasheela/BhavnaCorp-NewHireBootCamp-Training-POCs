using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionProject
{
     public interface ICategory
    {
        public string AddCat(string role);
        public void DisplayList();
        public void DeleteCat(int cid);
        public int UpdateCat(int cid);

    }
}
