using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApp.Interfaces;

namespace VotingApp.Models
{
    public class Utilitiy : IUtility
    {
        void IUtility.PrintDotAnimation(int timer = 10)
        {
            for (int i = 0; i < timer; i++)
            {
                Console.Write(".");
                Thread.Sleep(200);
            }

        }

        string IUtility.getConnection()
        {
            string con = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
            return con;
        }
    }
}
