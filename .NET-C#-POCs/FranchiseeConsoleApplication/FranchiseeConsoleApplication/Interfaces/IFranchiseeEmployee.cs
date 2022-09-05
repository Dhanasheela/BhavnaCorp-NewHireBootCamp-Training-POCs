using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranchiseeConsoleApplication.Interfaces
{
    public interface IFranchiseeEmployee
    {
        public void AddEmployee(string role);
        public string SalaryDistribution();

        public string PizzaSales(string salestype);

    }
}
