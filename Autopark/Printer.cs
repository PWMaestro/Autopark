using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopark
{
    public static class Printer
    {
        public static void PrintArray(Array arr)
        {
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }

        public static void PrintHashSet(HashSet<Vehicle> hashSet)
        {
            foreach (var item in hashSet)
            {
                Console.WriteLine(item);
            }
        }
    }
}
