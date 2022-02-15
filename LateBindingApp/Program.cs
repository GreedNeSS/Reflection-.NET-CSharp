using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LateBindingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Late Binding App *****");

            Assembly asm = null;

            try
            {
                asm = Assembly.Load("CarLibrary");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            if(asm != null)
            {
                CreateUsingLateBinding(asm);
                InvokeMethodWithArgsUsingLateBinding(asm);
            }
        }

        static void CreateUsingLateBinding(Assembly asm)
        {
            Type minivan = asm.GetType("CarLibrary.MiniVan");

            object obj = Activator.CreateInstance(minivan);
            Console.WriteLine($"\nCreated a {obj} using late binding!\n");

            MethodInfo m1 = minivan.GetMethod("TurboBust");

            m1.Invoke(obj, null);
        }

        static void InvokeMethodWithArgsUsingLateBinding(Assembly asm)
        {
            Type sportCar = asm.GetType("CarLibrary.SportCar");

            object obj = Activator.CreateInstance(sportCar);
            Console.WriteLine($"\nCreated a {obj} using late binding!\n");

            MethodInfo m1 = sportCar.GetMethod("TurnOnRadio");

            m1.Invoke(obj, new object[] { true, 2 });
        }
    }
}
