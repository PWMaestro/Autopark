using System;

namespace Autopark
{
    class Program
    {
        static void Main(string[] args)
        {
            Printer.PrintArray(Vehicle.vehicles);
            Console.WriteLine();
            Console.WriteLine(Vehicle.GetVehicleWithMaxMileageOnOneFilling());
        }
    }
}