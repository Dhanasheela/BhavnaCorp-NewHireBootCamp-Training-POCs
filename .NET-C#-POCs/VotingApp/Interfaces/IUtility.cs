using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingApp.Interfaces
{
     public interface IUtility
    {
         void PrintDotAnimation(int timer = 10);
        string getConnection();
    }
}
