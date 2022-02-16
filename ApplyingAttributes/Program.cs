using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplyingAttributes
{
    class Program
    {
        static void Main(string[] args)
        {
            HorseAndBuggy horseAndBuggy = new HorseAndBuggy();
        }
    }

    [Serializable]
    public class Motorcycle
    {
        [NonSerialized]
        float weigthOfCurrentPassengers;
        bool hasRadioSystem;
        bool hasHeadSet;
        bool hasSissyBar;
    }

    [Serializable, Obsolete("Use another vehicle!")]
    public class HorseAndBuggy
    {

    }
}
