using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeProject
{
    interface IEmployee
    {
        public List<EmployeeModel> AddEmployee();
       // public int DisplayMainMenu();
        public void DisplayList();
        public int update(int empId);
        public List<EmployeeModel> Search(string name);
        public int DeleteEmployee(int empid);
        

    }
}
