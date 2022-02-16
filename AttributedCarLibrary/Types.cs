using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: CLSCompliant(true)]

namespace AttributedCarLibrary
{
    [System.AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, Inherited = false, AllowMultiple = false)]
    public sealed class VehicleDescriptionAttribute : Attribute
    {
        readonly string description;

        // This is a positional argument
        public VehicleDescriptionAttribute(string vehicalDescription)
        {
            this.description = vehicalDescription;
        }

        public string Description
        {
            get { return description; }
        }
    }

    [Serializable]
    [VehicleDescription("My rocking Harley")]
    public class Motorcycle
    {
    }

    [VehicleDescription("A very long, slow, but feature-rich auto")]
    public class Winnebago
    {
    }

    [SerializableAttribute]
    [ObsoleteAttribute("Use another vehicle!")]
    [VehicleDescriptionAttribute("The old gray mare, she ain't what she used to be...")]
    public class HorseAndBuggy
    {
    }
}