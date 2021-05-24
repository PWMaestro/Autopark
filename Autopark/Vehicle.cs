using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopark
{
    public enum Color
    {
        Black,
        Red,
        Orange,
        Yellow,
        Green,
        Cyan,
        Blue,
        Violet,
        Gray,
        White
    }

    public class Vehicle : IComparable<Vehicle>
    {
        public readonly VehicleType type;
        public readonly int manufactureYear;
        public readonly string modelName;
        public string RegistrationNumber { get; set; }
        public double TankVolume { get; set; }
        public double Mileage { get; set; }
        public double Weight { get; set; }
        public Color Color { get; set; }

        public Vehicle()
        {
        }

        public Vehicle(
            VehicleType type,
            string modelName,
            string registrationNumber,
            double weight,
            int manufactureYear,
            double mileage,
            Color color) 
        {
            this.type = type;
            this.modelName = modelName;
            this.RegistrationNumber = registrationNumber;
            this.Weight = weight;
            this.manufactureYear = manufactureYear;
            this.Mileage = mileage;
            this.Color = color;
        }

        public double GetCalcTaxPerMonth()
        {   
            return this.Weight * 0.0013 + type.TaxCoefficient * 30 + 5;
        }

        public override string ToString()
        {
            return String.Format(
                "{0},{1},{2},{3},{4},{5},{6},{7},{8}",
                type.TypeName,
                modelName,
                RegistrationNumber,
                Weight,
                manufactureYear,
                Mileage,
                TankVolume,
                Color,
                GetCalcTaxPerMonth().ToString("0.00")
            );
        }

        public int CompareTo(Vehicle vehicle)
        {
            return GetCalcTaxPerMonth().CompareTo(vehicle.GetCalcTaxPerMonth());
        }
    }
}
