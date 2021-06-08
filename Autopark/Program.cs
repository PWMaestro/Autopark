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

            Console.WriteLine(Environment.NewLine + "-------- -------- QUEUE -------- --------");
            var queue = new CustomQueue<Vehicle>();

            Console.WriteLine();
            foreach (var vehicle in Vehicle.vehicles)
            {
                Console.WriteLine("Car gets into car wash:");
                Console.WriteLine(vehicle);
                queue.Enqueue(vehicle);
            }

            Console.WriteLine();
            foreach (var vehicle in queue)
            {
                Console.WriteLine($"Vehicle {vehicle} is washing now.");
            }

            Console.WriteLine();
            while (queue.Count != 0)
            {
                Console.WriteLine("Car lefts a car wash:");
                Console.WriteLine(queue.Dequeue());
            }

            Console.WriteLine(Environment.NewLine + "-------- -------- STACK -------- --------");
            var stack = new CustomStack<Vehicle>();

            Console.WriteLine();
            foreach (var vehicle in Vehicle.vehicles)
            {
                Console.WriteLine("Car gets into garage:");
                Console.WriteLine(vehicle);
                stack.Push(vehicle);
            }

            var mySuperCar = Vehicle.vehicles[3];
            Console.WriteLine();
            Console.WriteLine($"Does garage contain this car:\n{mySuperCar}\n???");
            Console.WriteLine(stack.Contains(mySuperCar));
            Console.WriteLine();

            while (stack.Count != 0)
            {
                Console.WriteLine("Car lefts a garage:");
                Console.WriteLine(stack.Pop());
            }

            Console.WriteLine(Environment.NewLine
                + "-------- -------- DICTIONARY -------- --------");
            var sparePartsList = new SparePartsDictionary("orders");

            sparePartsList.Print();
        }
    }
}