using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopark
{
    public class Vehicle : IComparable<Vehicle>
    {
        private const int TaxMultiplier = 30;
        private const int TaxBasicShift = 5;
        private const double WeightCoefficient = 0.0013;

        public static readonly Vehicle[] vehicles = new Vehicle[] {
            new Vehicle(1, VehicleType.vehicleTypes[0], new GasolineEngine(2, 8.1),"VW Crafter", "5427 AX-7", 2022, 2015, 376000, 75, Color.Blue),
            new Vehicle(2, VehicleType.vehicleTypes[0], new GasolineEngine(2, 8.5),"VW Crafter", "6427 AA-7", 2500, 2014, 227010, 75, Color.White),
            new Vehicle(3, VehicleType.vehicleTypes[0], new ElectricalEngine(50),"Electric Bus E321", "6785 BA-7", 12080, 2019, 20451, 150, Color.Green),
            new Vehicle(4, VehicleType.vehicleTypes[1], new DieselEngine(1.6, 7.2),"Golf 5", "8682 AX-7", 1200, 2006, 230451, 55, Color.Gray),
            new Vehicle(5, VehicleType.vehicleTypes[1], new ElectricalEngine(25),"Tesla Model S 70 D", "E001 AA-7", 2200, 2019, 10454, 70, Color.White),
            new Vehicle(6, VehicleType.vehicleTypes[2], new DieselEngine(3.2, 25),"Hamm HD 12 VV", null, 3000, 2016, 122, 20, Color.Yellow),
            new Vehicle(7, VehicleType.vehicleTypes[3], new DieselEngine(4.75, 20.1),"МТЗ Беларус-1025.4", "1145 AB-7", 1200, 2020, 109, 135, Color.Red)
        };
        public VehicleType Type { get; }
        public string ModelName { get; }
        public int ManufactureYear { get; }
        public int Id { get; }
        public string RegistrationNumber { get; set; }
        public double TankVolume { get; set; }
        public double Mileage { get; set; }
        public double Weight { get; set; }
        public AbstractEngine EngineType { get; set; }
        public List<Rent> Rents { get; set; }
        public Color Color { get; set; }

        public Vehicle()
        {
        }

        public Vehicle(
            int id,
            VehicleType type,
            AbstractEngine engineType,
            string modelName,
            string registrationNumber,
            double weight,
            int manufactureYear,
            double mileage,
            double tankVolume,
            Color color) 
        {
            Id = id;
            Type = type;
            EngineType = engineType;
            ModelName = modelName;
            RegistrationNumber = registrationNumber;
            Weight = weight;
            ManufactureYear = manufactureYear;
            Mileage = mileage;
            TankVolume = tankVolume;
            Color = color;
            Rents = new List<Rent>();
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

        public static HashSet<(Vehicle, Vehicle)> GetSameVehicles()
        {
            HashSet<(Vehicle, Vehicle)> vehicles = new();
            for (int i = 0; i < Vehicle.vehicles.Length; i++)
            {
                for (int j = i + 1; j < Vehicle.vehicles.Length; j++)
                {
                    if (Vehicle.vehicles[i].Equals(Vehicle.vehicles[j]))
                    {
                        vehicles.Add((Vehicle.vehicles[i], Vehicle.vehicles[j]));
                    }
                }
            }
            return vehicles;
        }

        public static Vehicle GetVehicleWithMaxMileageOnOneFilling()
        {
            var vehicleWithMaxMileage = vehicles[0];
            for (int i = 1; i < vehicles.Length; i++)
            {
                if (vehicles[i].GetMaxKilometers() > vehicleWithMaxMileage.GetMaxKilometers())
                {
                    vehicleWithMaxMileage = vehicles[i];
                }
            }
            return vehicleWithMaxMileage;
        }

        public double GetMaxKilometers() => EngineType.GetMaxKilometers(TankVolume);

        public double GetTotalIncome() => Rents.Sum(rent => rent.Cost);

        public double GetTotalProfit() => GetTotalIncome() - GetCalcTaxPerMonth();

        public double GetCalcTaxPerMonth()
        {   
            return Weight * WeightCoefficient
                 + Type.TaxCoefficient * EngineType.TaxCoeffByEngineType * TaxMultiplier
                 + TaxBasicShift;
        }

        public override string ToString()
        {
            return String.Format(
                "{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}",
                Id,
                Type.TypeName,
                EngineType,
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
            return obj is Vehicle vehicle
                && Type.TypeName.Equals(vehicle.Type.TypeName)
                && ModelName.Equals(vehicle.ModelName);
        }

        public int CompareTo(Vehicle vehicle) => GetCalcTaxPerMonth().CompareTo(vehicle.GetCalcTaxPerMonth());
    }
}
