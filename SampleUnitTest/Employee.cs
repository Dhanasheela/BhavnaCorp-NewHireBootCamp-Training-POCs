using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleUnitTest
{
    public class Employee
    {
        List<EmployeeModel> emp = new List<EmployeeModel>()
        {
            new EmployeeModel()
            {
                id=1,name="dhanu"
            },
            new EmployeeModel()
            {
                id=2,name="sanju"
            },
             new EmployeeModel()
            {
                id=3,name="Raju"
            },
        };

        public IEnumerable<EmployeeModel> GetEmployees()
        {
            int count = emp.Count();
            Console.WriteLine("count of employees:"+count);
            return emp.ToList();
        }
    }
}
