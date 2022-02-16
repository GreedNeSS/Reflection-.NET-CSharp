using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace VehicleDescriptionAttributeReaderLateBinding
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("********** Value of VehicleDescriptionAttribute **********");
            ReflectAttributesUsingLateBinding();
        }

        private static void ReflectAttributesUsingLateBinding()
        {
            try
            {
                Assembly asm = Assembly.Load("AttributedCarLibrary");
                Type vehicleDesc = asm.GetType("AttributedCarLibrary.VehicleDescriptionAttribute");
                PropertyInfo propDesc = vehicleDesc.GetProperty("Description");
                Type[] types = asm.GetTypes();

                foreach (Type t in types)
                {
                    object[] customAtts = t.GetCustomAttributes(vehicleDesc, false);

                    foreach (object obj in customAtts)
                    {
                        Console.WriteLine($"=> {t.Name}: {propDesc.GetValue(obj)}");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
