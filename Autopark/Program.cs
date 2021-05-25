using System;

namespace Autopark
{
    class Program
    {
        static void Main(string[] args)
        {
            Vehicle[] vehicles = new Vehicle[] {
                new Vehicle(VehicleType.vehicleTypes[0],"VW Crafter", "5427 AX-7", 2022, 2015, 376000, Color.Blue),
                new Vehicle(VehicleType.vehicleTypes[0],"VW Crafter", "6427 AA-7", 2500, 2014, 227010, Color.White),
                new Vehicle(VehicleType.vehicleTypes[0],"Electric Bus E321", "6785 BA-7", 12080, 2019, 20451, Color.Green),
                new Vehicle(VehicleType.vehicleTypes[1],"Golf 5", "8682 AX-7", 1200, 2006, 230451, Color.Gray),
                new Vehicle(VehicleType.vehicleTypes[1],"Tesla Model S 70 D", "E001 AA-7", 2200, 2019, 10454, Color.White),
                new Vehicle(VehicleType.vehicleTypes[2],"Hamm HD 12 VV", null, 3000, 2016, 122, Color.Yellow),
                new Vehicle(VehicleType.vehicleTypes[2],"МТЗ Беларус-1025.4", "1145 AB-7", 1200, 2020, 109, Color.Red)
            };

            Printer.PrintArray(vehicles);
            Array.Sort(vehicles);
            Console.WriteLine();
            Printer.PrintArray(vehicles);
            Console.WriteLine("\n");

            int indexOfMinMileage = 0;
            int indexOfMaxMileage = 0;
            double minMileage = vehicles[0].Mileage;
            double maxMileage = vehicles[0].Mileage;

            for (int i = 0; i < vehicles.Length; i++)
            {
                if (maxMileage < vehicles[i].Mileage)
                {
                    maxMileage = vehicles[i].Mileage;
                    indexOfMaxMileage = i;
                }
                if (minMileage > vehicles[i].Mileage)
                {
                    minMileage = vehicles[i].Mileage;
                    indexOfMinMileage = i;
                }
            }
            Console.WriteLine("Vehicle with minimum maileage is:");
            Console.WriteLine(vehicles[indexOfMinMileage]);
            Console.WriteLine("Vehicle with maximum maileage is:");
            Console.WriteLine(vehicles[indexOfMaxMileage]);

        }
    }
}