using Operatorlibrary;
using System;

namespace Operators
{
    class Program
    {
        static void Main(string[] args)
        {
            AreaCal ac = new AreaCal();
            ValueRef cs = new ValueRef();
            int x = 5;
            Console.WriteLine(x + "value of x");
            cs.Increment();
            cs.IncRef(ref x);
            Console.WriteLine("display: x:{0}" , x);
            cs.display();

            Overload ovr = new Overload(-20, 35);
            ovr = -ovr;
            ovr.Print();
        }
    }

}
