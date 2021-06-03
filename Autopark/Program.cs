using System;
using System.IO;
using System.Linq;
using System.Globalization;

namespace Autopark
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo.CurrentCulture = new CultureInfo("en-US", false);

            var autopark = new Collections("types", "vehicles", "rents");

            autopark.Print();
            Console.WriteLine(autopark.Vehicles.Count);
            Console.WriteLine();

            autopark.Insert
            (
                -1,
                new Vehicle
                (
                    8, VehicleType.vehicleTypes[1],
                    new GasolineEngine(4.8, 12.3),
                    "Lamborghini Diablo",
                    "7777 TT-0",
                    1530,
                    2021,
                    500,
                    80,
                    Color.Blue
                )
            );
            
            Console.WriteLine(autopark.Vehicles.Count);
            for (int i = 0; i < 4; i++)
            {
                if (autopark.Delete(1) != -1)
                {
                    Console.WriteLine($"Deletion of element {i} successfully done!");
                }
            }
            Console.WriteLine();
            
            autopark.Print();
            Console.WriteLine();

            autopark.Sort(new VehicleComparer());
            autopark.Print();
            
        }
    }
}