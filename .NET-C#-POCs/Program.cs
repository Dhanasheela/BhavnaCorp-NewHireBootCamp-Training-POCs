using System;
using System.Reflection;

namespace Reflection_Console_APP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Reflection.MemINFO");
            Type type = Type.GetType("System.Reflection.FieldInfo");
            MemberInfo[] info = type.GetMembers();
            Console.WriteLine("\n there are {0}memebers in {1}.", info.Length, type.FullName);
            Console.WriteLine("{0}.", type.FullName);
            if (type.IsPublic)
            {
                Console.WriteLine("{0} is public.", type.FullName);
            }

            //exAMPLE2
            Console.WriteLine("=======================Example2==========================");

            Console.WriteLine("Reflection.MethodInfo");
            // Gets and displays the Type.
            Type myType = Type.GetType("System.Reflection.FieldInfo");
            // Specifies the member for which you want type information.
            MethodInfo myMethodInfo = myType.GetMethod("GetValue");
            Console.WriteLine(myType.FullName + "." + myMethodInfo.Name);
            // Gets and displays the MemberType property.
            MemberTypes myMemberTypes = myMethodInfo.MemberType;
            if (MemberTypes.Constructor == myMemberTypes)
            {
                Console.WriteLine("MemberType is of type All");
            }
            else if (MemberTypes.Custom == myMemberTypes)
            {
                Console.WriteLine("MemberType is of type Custom");
            }
            else if (MemberTypes.Event == myMemberTypes)
            {
                Console.WriteLine("MemberType is of type Event");
            }
            else if (MemberTypes.Field == myMemberTypes)
            {
                Console.WriteLine("MemberType is of type Field");
            }
            else if (MemberTypes.Method == myMemberTypes)
            {
                Console.WriteLine("MemberType is of type Method");
            }
            else if (MemberTypes.Property == myMemberTypes)
            {
                Console.WriteLine("MemberType is of type Property");
            }
            else if (MemberTypes.TypeInfo == myMemberTypes)
            {
                Console.WriteLine("MemberType is of type TypeInfo");
            }

            ///reflection example 2
            Console.WriteLine("=======================Example3==========================" );
           
            // Specifies the class.
            Type t = typeof(System.IO.BufferedStream);
            Console.WriteLine("Listing all the members (public and non public) of the {0} type", t);

            // Lists static fields first.
            FieldInfo[] fi = t.GetFields(BindingFlags.Static |
                BindingFlags.NonPublic | BindingFlags.Public);
            Console.WriteLine("// Static Fields");
            PrintMembers(fi);

            // Static properties.
            PropertyInfo[] pi = t.GetProperties(BindingFlags.Static |
                BindingFlags.NonPublic | BindingFlags.Public);
            Console.WriteLine("// Static Properties");
            PrintMembers(pi);

            // Static events.
            EventInfo[] ei = t.GetEvents(BindingFlags.Static |
                BindingFlags.NonPublic | BindingFlags.Public);
            Console.WriteLine("// Static Events");
            PrintMembers(ei);

            // Static methods.
            MethodInfo[] mi = t.GetMethods(BindingFlags.Static |
                BindingFlags.NonPublic | BindingFlags.Public);
            Console.WriteLine("// Static Methods");
            PrintMembers(mi);

            // Constructors.
            ConstructorInfo[] ci = t.GetConstructors(BindingFlags.Instance |
                BindingFlags.NonPublic | BindingFlags.Public);
            Console.WriteLine("// Constructors");
            PrintMembers(ci);

            // Instance fields.
            fi = t.GetFields(BindingFlags.Instance | BindingFlags.NonPublic |
                BindingFlags.Public);
            Console.WriteLine("// Instance Fields");
            PrintMembers(fi);

            // Instance properites.
            pi = t.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic |
                BindingFlags.Public);
            Console.WriteLine("// Instance Properties");
            PrintMembers(pi);

            // Instance events.
            ei = t.GetEvents(BindingFlags.Instance | BindingFlags.NonPublic |
                BindingFlags.Public);
            Console.WriteLine("// Instance Events");
            PrintMembers(ei);

            // Instance methods.
            mi = t.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic
                | BindingFlags.Public);
            Console.WriteLine("// Instance Methods");
            PrintMembers(mi);

            Console.WriteLine("\r\nPress ENTER to exit.");
            Console.Read();
        }
        public static void PrintMembers(MemberInfo[] ms)
        {
            foreach (MemberInfo m in ms)
            {
                Console.WriteLine("{0}{1}", "     ", m);
            }
            Console.WriteLine();
        }

    }
}
