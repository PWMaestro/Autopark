﻿using System;

namespace Autopark
{
    class Program
    {
        static void Main(string[] args)
        {
            VehicleType[] vechiles = new VehicleType[] {
                new VehicleType("Bus", 1.2),
                new VehicleType("Car", 1.0),
                new VehicleType("Rink", 1.5),
                new VehicleType("Tractor", 1.2)
            };
            double maxTaxCoefficient = vechiles[0].TaxCoefficient;
            double sumTaxCoefficient = 0;

            for (int i = 0; i < vechiles.Length; i++)
            {
                if (vechiles[i].TaxCoefficient > maxTaxCoefficient)
                {
                    maxTaxCoefficient = vechiles[i].TaxCoefficient;
                }
                if (i == vechiles.Length - 1)
                {
                    vechiles[i].TaxCoefficient = 1.3;
                }
                sumTaxCoefficient += vechiles[i].TaxCoefficient;
                vechiles[i].Display();
            }
            double averageTaxCoefficient = sumTaxCoefficient * 1.0 / vechiles.Length;
            foreach (var vechile in vechiles)
            {
                Console.WriteLine(vechile);
            }
            Console.WriteLine($"Average tax coefficient is {averageTaxCoefficient:F2}.");
            Console.WriteLine($"Maximum tax coefficient is {maxTaxCoefficient}.");
        }
    }
}