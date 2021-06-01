using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopark
{
    public abstract class AbstractCombustionEngine : AbstractEngine
    {
        public double EngineVolume { get; protected set; }
        public double FuelConsumptionPer100Km { get; protected set; }

        protected AbstractCombustionEngine(string typeName, double taxCoefficient)
            : base(typeName, taxCoefficient)
        {
        }

        public override double GetMaxKilometers(double fuelTankCapacity) => fuelTankCapacity * 100.0 / FuelConsumptionPer100Km;

        public override string ToString() => string.Format
        (
            $"{base.ToString()} {EngineVolume} {FuelConsumptionPer100Km}".Replace(",", ".")
        );
    }
}
