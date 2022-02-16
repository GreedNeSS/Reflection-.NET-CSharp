using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttributedCarLibrary;

namespace VehicleDescriptionAttributeReader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("********** Value of VehicleDescriptionAttribute **********");
            ReflectOnAttributesWithEarlyBinding();
        }

        private static void ReflectOnAttributesWithEarlyBinding()
        {
            //Type t = typeof(Winnebago);

            string token = "3F 07 FE CB 6E BD CC 6A".Replace(" ", "");
            Type t = Type.GetType($"AttributedCarLibrary.Winnebago, AttributedCarLibrary," +
                $" Version=1.0.0.0, Culture=neutral, PublicKeyToken={token}");

            if (t != null)
            {
                object[] customAtts = t.GetCustomAttributes(false);

                foreach (VehicleDescriptionAttribute attribute in customAtts)
                {
                    Console.WriteLine($"=> Description: {attribute.Description}");
                }
            }
        }
    }
}
