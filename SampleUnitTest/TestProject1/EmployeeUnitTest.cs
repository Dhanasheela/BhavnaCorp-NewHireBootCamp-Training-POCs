using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleUnitTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    [TestClass]
    public class EmployeeUnitTest
    {
        [TestMethod]
        public void GetEmployee()
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
            Employee employee = new Employee();
            var actual= employee.GetEmployees().ToList().Count();
            var expected = emp.Count();
            Assert.AreEqual(actual,expected);
        }
    }
}
