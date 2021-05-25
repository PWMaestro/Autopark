using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopark
{
    class CombustionEngine : Engine
    {
        public double EngineVolume { get; set; }
        public double FuelConsumptionPer100Km { get; set; }

        public CombustionEngine(string typeName, double taxCoefficient)
            : base(typeName, taxCoefficient)
        {
        }

        public double GetMaxKilometers(double fuelTankCapacity) => fuelTankCapacity * 100.0 / FuelConsumptionPer100Km;
    }
}
