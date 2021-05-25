using System;

namespace Autopark
{
    class Program
    {
        static void Main(string[] args)
        {
            Printer.PrintArray(Vehicle.vehicles);
            Console.WriteLine();
            var vehicles = Vehicle.GetSameVehicles();
            if (vehicles.Count != 0)
            {
                Printer.PrintArray(vehicles);
            }
            else
            {
                Console.WriteLine("There is no same vehicles!");
            }
        }
    }
}