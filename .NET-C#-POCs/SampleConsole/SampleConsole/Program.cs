using System;
using System.Collections.Generic;

namespace SampleConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter option");
            int option =int.Parse(Console.ReadLine());
                 //  int option1 = int.Parse(Console.ReadLine());

            int empId =0;
            string Ename="";
            switch (option )
            {
                case 1:
                     Console.WriteLine("enter Id");
                    empId = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Employee Name");
                    Ename = Console.ReadLine();
                    goto case 2;
                case 2:
                    Console.WriteLine("");
                    Console.WriteLine("---Employee Details---");
                    Console.WriteLine("Employee ID:" + empId + " Name:" + Ename);
                    goto case 3 ;
                case 3:
                    string s, revs = "";
                    Console.WriteLine(" Enter string");
                    s = Console.ReadLine();
                    for (int i = s.Length - 1; i >= 0; i--) //String Reverse  
                    {
                        revs += s[i].ToString();
                    }
                    if (revs == s) // Checking whether string is palindrome or not  
                    {
                        Console.WriteLine("String is Palindrome \n Entered String Was {0} and reverse string is {1}", s, revs);
                    }
                    else
                    {
                        Console.WriteLine("String is not Palindrome \n Entered String Was {0} and reverse string is {1}", s, revs);
                    }
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("invalid input ");
                     break;
            }

           
        }

       
    }
}
