using System;
using System.Reflection;

namespace ExtendalAssemblyReflector
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("******External Assembly Viewer******");

            string asmName;

            do
            {
                Console.WriteLine("\nEnter an assembly to evaluate");
                Console.Write("or enter Q to quit: ");

                asmName = Console.ReadLine();

                if (asmName.Equals("Q", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                try
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Assembly assembly = Assembly.LoadFrom(asmName);
                    DisplayTypesInAsm(assembly);
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Sorry, can't find assembly!");
                }

                Console.ResetColor();

            } while (true);
        }

        public static void DisplayTypesInAsm(Assembly asm)
        {
            Console.WriteLine("\n****** Types in Assembly ******");
            Console.WriteLine($"-> {asm.FullName}");

            Type[] types = asm.GetTypes();

            foreach (var type in types)
            {
                Console.WriteLine($"{type.FullName} {type.Name}");
            }
        }
    }
}
