using FranchiseeConsoleApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranchiseeConsoleApplication.Interfaces
{
    public interface IFranchisee
    {
        public string AddFranchisee(string role);
        public void DisplayDetails();
        public string DisplayCodeWiseDetails(string code);
        public string DisplayDateDetails(DateTime date);
        public void TotalSales(string username);
    }
}
