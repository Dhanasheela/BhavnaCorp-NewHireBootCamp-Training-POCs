using System;
using System.Collections.Generic;
using System.Text;

namespace Operatorlibrary
{
    public class Overload
    {

    public int number1, number2;
        public Overload(int num1, int num2)
        {
            number1 = num1;
            number2 = num2;
        }
        public static Overload operator -(Overload a1)
        {
            a1.number1 = -a1.number1;
            a1.number2 = -a1.number2;
            return a1;
        }
        public void Print()
        {
            Console.WriteLine("Number1 = " + number1);
            Console.WriteLine("Number2 = " + number2);
        }
    }
}
