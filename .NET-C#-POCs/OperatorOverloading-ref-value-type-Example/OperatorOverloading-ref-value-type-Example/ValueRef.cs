using System;

namespace Operatorlibrary
{
    public class ValueRef
    {
        AreaCal ac = new AreaCal();
        int i=0,area;
        public void Increment()
        {
            Console.WriteLine(i + "value of i");
            i = i + 1;
        }

        public void IncRef(ref int i)
        {
            ac.length = 15;
            ac.width = 20;
            area = ac.length * ac.width;
            i *= i;
        }
        public void display()
        {
            Console.WriteLine("the value of increment value:{0}", i);
        }
    }
    public class AreaCal
    {
        public int length;
        public int width;
    }
}
