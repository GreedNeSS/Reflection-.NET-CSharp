using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SharedAsmReflector
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("****** The Shared Asm Reflector App ******");
            
            string displayName = "System.Windows.Forms, " +
                "Version=4.0.0.0, " + "PublicKeyToken=b77a5c561934e089, " +
                @"Culture=""";

            Assembly assembly = Assembly.Load(displayName);

            DisplayInfo(assembly);
            Console.WriteLine("Done!");
        }

        public static void DisplayInfo(Assembly asm)
        {
            Console.WriteLine("****** Info About Assembly ******");
            Console.WriteLine($"Loaded from GAC? {asm.GlobalAssemblyCache}");
            Console.WriteLine($"Asm Name: {asm.GetName().Name}");
            Console.WriteLine($"Asm Version: {asm.GetName().Version}");
            Console.WriteLine($"Asm Culture: {asm.GetName().CultureName}");
            Console.WriteLine("\nHere are the public enums:");

            Type[] types = asm.GetTypes();
            var pEnums = from pe in types
                         where pe.IsEnum && pe.IsPublic
                         select pe;

            foreach (var pe in pEnums)
            {
                Console.WriteLine(pe);
            }
        }
    }
}
