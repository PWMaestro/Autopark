using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopark
{
    public class GasolineEngine : CombustionEngine
    {
        public GasolineEngine(double engineVolume, double fuelConsumptionPer100Km)
            : base("Gasoline", 1.0)
        {
            EngineVolume = engineVolume;
            FuelConsumptionPer100Km = fuelConsumptionPer100Km;
        }
    }
}
