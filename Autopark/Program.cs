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

            int indexOfMinMileage = 0;
            int indexOfMaxMileage = 0;
            double minMileage = Vehicle.vehicles[0].Mileage;
            double maxMileage = Vehicle.vehicles[0].Mileage;

            for (int i = 0; i < Vehicle.vehicles.Length; i++)
            {
                if (maxMileage < Vehicle.vehicles[i].Mileage)
                {
                    maxMileage = Vehicle.vehicles[i].Mileage;
                    indexOfMaxMileage = i;
                }
                if (minMileage > Vehicle.vehicles[i].Mileage)
                {
                    minMileage = Vehicle.vehicles[i].Mileage;
                    indexOfMinMileage = i;
                }
            }
            Console.WriteLine("Vehicle with minimum maileage is:");
            Console.WriteLine(Vehicle.vehicles[indexOfMinMileage]);
            Console.WriteLine("Vehicle with maximum maileage is:");
            Console.WriteLine(Vehicle.vehicles[indexOfMaxMileage]);

        }
    }
}