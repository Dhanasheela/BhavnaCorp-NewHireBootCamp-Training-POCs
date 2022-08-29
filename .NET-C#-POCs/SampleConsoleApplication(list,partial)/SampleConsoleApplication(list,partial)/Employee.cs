using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConsoleApplication_list_partial_
{
    class Employee
    {
        public int empid { get; set; }
        public string ename { get; set; }
        public string gender { get; set; }
        public double salary { get; set; }

        //Declaring a private variable  
        private string _company;
        public  string company
        {
            get { return _company; }
            set { _company = "BhavnaCorp"; }
        }
    }
}
