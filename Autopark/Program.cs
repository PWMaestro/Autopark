using System;

namespace Autopark
{
    class Program
    {
        static void Main(string[] args)
        {
            Printer.PrintArray(Vehicle.vehicles);
            Array.Sort(Vehicle.vehicles);
            Console.WriteLine();
            Printer.PrintArray(Vehicle.vehicles);
            Console.WriteLine("\n");

            Console.WriteLine("Vehicle with minimum maileage is:");
            Console.WriteLine(Vehicle.GetVehicleWithMinMileage());
            Console.WriteLine("Vehicle with maximum maileage is:");
            Console.WriteLine(Vehicle.GetVehicleWithMaxMileage());
        }
    }
}