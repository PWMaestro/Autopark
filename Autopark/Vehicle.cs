using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopark
{
    public class Vehicle : IComparable<Vehicle>
    {
        public static readonly Vehicle[] vehicles = new Vehicle[] {
            new Vehicle(VehicleType.vehicleTypes[0], new GasolineEngine(2, 8.1),"VW Crafter", "5427 AX-7", 2022, 2015, 376000, Color.Blue),
            new Vehicle(VehicleType.vehicleTypes[0], new GasolineEngine(2, 8.5),"VW Crafter", "6427 AA-7", 2500, 2014, 227010, Color.White),
            new Vehicle(VehicleType.vehicleTypes[0], new ElectricalEngine(50),"Electric Bus E321", "6785 BA-7", 12080, 2019, 20451, Color.Green),
            new Vehicle(VehicleType.vehicleTypes[1], new DieselEngine(1.6, 7.2),"Golf 5", "8682 AX-7", 1200, 2006, 230451, Color.Gray),
            new Vehicle(VehicleType.vehicleTypes[1], new ElectricalEngine(25),"Tesla Model S 70 D", "E001 AA-7", 2200, 2019, 10454, Color.White),
            new Vehicle(VehicleType.vehicleTypes[2], new DieselEngine(3.2, 25),"Hamm HD 12 VV", null, 3000, 2016, 122, Color.Yellow),
            new Vehicle(VehicleType.vehicleTypes[3], new DieselEngine(4.75, 20.1),"МТЗ Беларус-1025.4", "1145 AB-7", 1200, 2020, 109, Color.Red)
        };
        public VehicleType Type { get; }
        public string ModelName { get; }
        public int ManufactureYear { get; }
        public string RegistrationNumber { get; set; }
        public double TankVolume { get; set; }
        public double Mileage { get; set; }
        public double Weight { get; set; }
        public Engine EngineType { get; set; }
        public Color Color { get; set; }

        public Vehicle()
        {
        }

        public Vehicle(
            VehicleType type,
            Engine engineType,
            string modelName,
            string registrationNumber,
            double weight,
            int manufactureYear,
            double mileage,
            Color color) 
        {
            Type = type;
            EngineType = engineType;
            ModelName = modelName;
            RegistrationNumber = registrationNumber;
            Weight = weight;
            ManufactureYear = manufactureYear;
            Mileage = mileage;
            Color = color;
        }

        public static Vehicle GetVehicleWithMinMileage()
        {
            int indexOfMinMileage = 0;
            double minMileage = vehicles[0].Mileage;

            for (int i = 0; i < vehicles.Length; i++)
            {
                if (minMileage > vehicles[i].Mileage)
                {
                    minMileage = vehicles[i].Mileage;
                    indexOfMinMileage = i;
                }
            }
            return vehicles[indexOfMinMileage];
        }

        public static Vehicle GetVehicleWithMaxMileage()
        {
            int indexOfMaxMileage = 0;
            double maxMileage = vehicles[0].Mileage;

            for (int i = 0; i < vehicles.Length; i++)
            {
                if (maxMileage < vehicles[i].Mileage)
                {
                    maxMileage = vehicles[i].Mileage;
                    indexOfMaxMileage = i;
                }
            }
            return vehicles[indexOfMaxMileage];
        }

        public double GetCalcTaxPerMonth()
        {   
            return this.Weight * 0.0013 + Type.TaxCoefficient * 30 + 5;
        }

        public override string ToString()
        {
            return String.Format(
                "{0},{1},{2},{3},{4},{5},{6},{7},{8}",
                Type.TypeName,
                ModelName,
                RegistrationNumber,
                Weight,
                ManufactureYear,
                Mileage,
                TankVolume,
                Color,
                GetCalcTaxPerMonth().ToString("0.00")
            );
        }

        public override bool Equals(object obj)
        {
            Vehicle vehicle = obj as Vehicle;
            return vehicle != null
                && Type.TypeName.Equals(vehicle.Type.TypeName)
                && ModelName.Equals(vehicle.ModelName);
        }

        public int CompareTo(Vehicle vehicle)
        {
            return GetCalcTaxPerMonth().CompareTo(vehicle.GetCalcTaxPerMonth());
        }
    }
}
