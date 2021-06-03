using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopark
{
    public class VehicleType
    {
        public static readonly VehicleType[] vehicleTypes = new VehicleType[] {
            new VehicleType(1, "Bus", 1.2),
            new VehicleType(2, "Car", 1.0),
            new VehicleType(3, "Rink", 1.5),
            new VehicleType(4, "Tractor", 1.2)
        };
        public int Id { get; set; }
        public string TypeName { get; set; }
        public double TaxCoefficient { get; set; }

        public VehicleType()
        {
        }

        public VehicleType(int id, string type, double taxCoefficient = 1.0)
        {
            Id = id;
            TypeName = type;
            TaxCoefficient = taxCoefficient;
        }

        public void Display()
        {
            Console.WriteLine(
                "TypeName = {0}\nTaxCoefficient = {1}",
                TypeName,
                TaxCoefficient
            );
        }

        public override string ToString() => $"{TypeName}, \"{TaxCoefficient}\"";
    }
}