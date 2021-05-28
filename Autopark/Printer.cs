using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopark
{
    public static class Printer
    {
        public static void PrintArray(IEnumerable<Vehicle> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }

        public static void PrintTurpleArray(IEnumerable<(Vehicle, Vehicle)> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item.Item1);
                Console.WriteLine(item.Item2);
            }
        }
    }
}
