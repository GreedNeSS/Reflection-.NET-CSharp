using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarLibrary;

namespace TypeViewer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------- Write Type -------");
            string typeName;

            do
            {
                Console.WriteLine("\nEnter a type name to evaluate");
                Console.Write("or enter Q to quit: ");

                typeName = Console.ReadLine();

                if (typeName.Equals("Q", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                Type type = Type.GetType(typeName);

                if (type != null)
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;

                    ListVariousStats(type);
                    ListFields(type);
                    ListProperties(type);
                    ListMethods(type);
                    ListInterfaces(type);

                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine("Sorry, can't find type");
                }
                
            } while (true);
        }

        //static void ListMethods(Type t)
        //{
        //    Console.WriteLine("***** Methods *****");
        //    var methods = from m in t.GetMethods() select m.Name;
        //    foreach (var method in methods)
        //        Console.WriteLine($"=> {method}");
        //    Console.WriteLine();
        //}

        static void ListMethods(Type t)
        {
            Console.WriteLine("***** Methods *****");

            var methods = t.GetMethods().Select(m =>
           {
               string result = m.ReturnType.FullName;
               result += $" {m.Name}(";
               foreach (var p in m.GetParameters())
               {
                   result += p.ParameterType;
                   result += $" {p.Name}" +
                   $"{((p.Position == m.GetParameters().Length - 1) ? "" : ", ")}";
               }
               result += ")";
               return result;
           });

            foreach (var method in methods)
                Console.WriteLine($"=> {method}");
            Console.WriteLine();
        }

        //static void ListMethods(Type t)
        //{
        //    Console.WriteLine("***** Methods *****");
        //    var methods = from m in t.GetMethods() select m;
        //    foreach (var method in methods)
        //        Console.WriteLine($"=> {method}");
        //    Console.WriteLine();
        //}

        static void ListFields(Type t)
        {
            Console.WriteLine("***** Fields *****");
            var fields = from f in t.GetFields() select f.Name;
            foreach (var field in fields)
                Console.WriteLine($"=> {field}");
            Console.WriteLine();
        }

        static void ListProperties(Type t)
        {
            Console.WriteLine("***** Properties *****");
            var properties = from p in t.GetProperties() select p.Name;
            foreach (var prop in properties)
                Console.WriteLine($"=> {prop}");
            Console.WriteLine();
        }

        static void ListInterfaces(Type t)
        {
            Console.WriteLine("***** Interfaces *****");
            var interfaces = from i in t.GetInterfaces() select i;
            foreach (var i in interfaces)
                Console.WriteLine($"=> {i.Name}");
            Console.WriteLine();
        }

        static void ListVariousStats(Type t)
        {
            Console.WriteLine("***** Various Statistics *****");
            Console.WriteLine($"Base class is: {t.BaseType}");
            Console.WriteLine($"Is type abstract? {t.IsAbstract}");
            Console.WriteLine($"Is type sealed? {t.IsSealed}");
            Console.WriteLine($"Is type generic? {t.IsGenericTypeDefinition}");
            Console.WriteLine($"Is type a class type? {t.IsClass}");
            Console.WriteLine();
        }
    }
}
