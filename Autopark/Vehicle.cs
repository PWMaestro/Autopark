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
        public static readonly Vehicle[] vehicles = new Vehicle[] {
            new Vehicle(VehicleType.vehicleTypes[0],"VW Crafter", "5427 AX-7", 2022, 2015, 376000, Color.Blue),
            new Vehicle(VehicleType.vehicleTypes[0],"VW Crafter", "6427 AA-7", 2500, 2014, 227010, Color.White),
            new Vehicle(VehicleType.vehicleTypes[0],"Electric Bus E321", "6785 BA-7", 12080, 2019, 20451, Color.Green),
            new Vehicle(VehicleType.vehicleTypes[1],"Golf 5", "8682 AX-7", 1200, 2006, 230451, Color.Gray),
            new Vehicle(VehicleType.vehicleTypes[1],"Tesla Model S 70 D", "E001 AA-7", 2200, 2019, 10454, Color.White),
            new Vehicle(VehicleType.vehicleTypes[2],"Hamm HD 12 VV", null, 3000, 2016, 122, Color.Yellow),
            new Vehicle(VehicleType.vehicleTypes[2],"МТЗ Беларус-1025.4", "1145 AB-7", 1200, 2020, 109, Color.Red)
        };
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
