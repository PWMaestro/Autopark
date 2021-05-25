using System;

namespace Autopark
{
    class Program
    {
        static void Main(string[] args)
        {
            Printer.PrintArray(Vehicle.vehicles);
            Console.WriteLine();
            if (Vehicle.IsSameVehiclesExist())
            {
                Printer.PrintArray(Vehicle.GetSameVehicles());
            }
            else
            {
                Console.WriteLine("There is no same vehicles!");
            }
        }
    }
}