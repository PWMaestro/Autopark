using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopark
{
    public class Collections
    {
        private const string FileExtension = ".csv";
        private const string FilePrefix = @"..\..\..\";
        private const string ErrorMessage = "Error! Can not find the file: ";

        private readonly string vehiclesFilePath;
        private readonly string rentsListFilePath;
        private readonly string vehicleTypesFilePath;

        public List<Rent> Rents { get; }
        public List<Vehicle> Vehicles { get; }
        public List<VehicleType> VehicleTypes { get; }

        public Collections(string vehicleTypesFileName, string vehiclesFileName, string rentsListFileName)
        {
            Rents = new List<Rent>();
            Vehicles = new List<Vehicle>();
            VehicleTypes = new List<VehicleType>();

            vehiclesFilePath = FilePrefix + vehiclesFileName + FileExtension;
            rentsListFilePath = FilePrefix + rentsListFileName + FileExtension;
            vehicleTypesFilePath = FilePrefix + vehicleTypesFileName + FileExtension;

            Rents = LoadRents(rentsListFilePath);
            Vehicles = LoadVehicles(vehiclesFilePath);
            VehicleTypes = LoadTypes(vehicleTypesFilePath);
        }

        public List<VehicleType> LoadTypes(string inFile)
        {
            var typesList = new List<VehicleType>();
            if (File.Exists(inFile))
            {
                using var sr = new StreamReader(File.Open(inFile, FileMode.Open), Encoding.Default);
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    typesList.Add(CreateType(line));
                }
            }
            else
            {
                Console.WriteLine(ErrorMessage + inFile);
            }
            return typesList;
        }
        
        public List<Vehicle> LoadVehicles(string inFile)
        {
            var vehicleList = new List<Vehicle>();
            if (File.Exists(inFile))
            {
                using var sr = new StreamReader(File.Open(inFile, FileMode.Open), Encoding.Default);
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    vehicleList.Add(CreateVechile(line));
                }
            }
            else
            {
                Console.WriteLine(ErrorMessage + inFile);
            }
            return vehicleList;
        }

        public List<Rent> LoadRents(string inFile)
        {
            var rentsList = new List<Rent>();
            if (File.Exists(inFile))
            {
                using var sr = new StreamReader(File.Open(inFile, FileMode.Open), Encoding.Default);
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    rentsList.Add(CreateRegisterEntry(line));
                }
            }
            else
            {
                Console.WriteLine(ErrorMessage + inFile);
            }
            return rentsList;
        }
        
        public VehicleType CreateType(string csvString)
        {
            string[] data = csvString.Split(',');

            return new VehicleType
            (
                int.Parse(data[0]),
                data[1],
                double.Parse(data[2])
            );
        }
        
        public Vehicle CreateVechile(string csvString)
        {
            string[] data = csvString.Split(',');
            var vehicle = new Vehicle
            (
                int.Parse(data[0]),
                GetVehicleTypeById(LoadTypes(vehicleTypesFilePath), int.Parse(data[1])),
                GetEngineByString(data[2]),
                data[3],
                data[4],
                double.Parse(data[5]),
                int.Parse(data[6]),
                double.Parse(data[7]),
                double.Parse(data[8]),
                Enum.Parse<Color>(data[9])
            );
            foreach (var rent in Rents)
            {
                if (rent.Id == vehicle.Id)
                {
                    vehicle.Rents.Add(rent);
                }
            }
            return vehicle;
        }

        public Rent CreateRegisterEntry(string csvString)
        {
            string[] data = csvString.Split(',');

            return new Rent
            (
                int.Parse(data[0]),
                DateTime.ParseExact(data[1], "dd.MM.yyyy", CultureInfo.CurrentCulture),
                double.Parse(data[2])
            );
        }

        private static AbstractEngine GetEngineByString(string engineString)
        {
            AbstractEngine engine = null;
            string[] engineStringPieces = engineString.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var engineType = Enum.Parse<EngineTypes>(engineStringPieces[0]);

            switch (engineType)
            {
                case EngineTypes.Gasoline:
                    engine = new GasolineEngine
                    (
                        double.Parse(engineStringPieces[1]),
                        double.Parse(engineStringPieces[2])
                    );
                    break;

                case EngineTypes.Diesel:
                    engine = new DieselEngine
                    (
                        double.Parse(engineStringPieces[1]),
                        double.Parse(engineStringPieces[2])
                    );
                    break;

                case EngineTypes.Electrical:
                    engine = new ElectricalEngine
                    (
                        double.Parse(engineStringPieces[1])
                    );
                    break;

                default:
                    break;
            }
            return engine;
        }
        
        private static VehicleType GetVehicleTypeById(List<VehicleType> typesList, int id)
        {
            foreach (var type in typesList)
            {
                if (type.Id == id)
                {
                    return type;
                }
            }
            return null;
        }
        
        public void Insert(int index, Vehicle v)
        {
            if (index > Vehicles.Count || index < 0)
            {
                Vehicles.Add(v);
            }
            else
            {
                Vehicles.Insert(index, v);
            }
        }

        public int Delete(int index)
        {
            if (index > Vehicles.Count)
            {
                return -1;
            }
            else
            {
                Vehicles.RemoveAt(index);
                return index;
            }
        }

        public double SumTotalProfit() => Vehicles.Sum(vehicle => vehicle.GetTotalProfit());

        public void Sort(IComparer<Vehicle> comparator) => Vehicles.Sort(comparator);

        public void Print()
        {
            Console.WriteLine("{0,-5}{1,-10}{2,-25}{3,-15}{4,-15}{5,-10}{6,-10}{7,-10}{8,-10}{9,-10}{10,-10}",
                "Id",
                "Type", 
                "ModelName",
                "Number", 
                "Weight (kg)",
                "Year",
                "Mileage",
                "Color",
                "Income",
                "Tax",
                "Profit"
            );
            foreach (Vehicle v in Vehicles)
            {
                Console.WriteLine("{0,-5}{1,-10}{2,-25}{3,-15}{4,-15}{5,-10}{6,-10}{7,-10}{8,-10}{9,-10}{10,-10}",
                    v.Id,
                    v.Type.TypeName,
                    v.ModelName,
                    v.RegistrationNumber,
                    v.Weight,
                    v.ManufactureYear,
                    v.Mileage,
                    v.Color,
                    v.GetTotalIncome().ToString("0.00"),
                    v.GetCalcTaxPerMonth().ToString("0.00"),
                    v.GetTotalProfit().ToString("0.00"));
            }
            Console.WriteLine($"{"Total",-5}{"",-115}{SumTotalProfit(),-10:0.00}");
        }
    }
}
