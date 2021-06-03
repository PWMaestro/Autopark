using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopark
{
    public class GasolineEngine : AbstractCombustionEngine
    {
        public GasolineEngine(double engineVolume, double fuelConsumptionPer100Km)
            : base(EngineTypes.Gasoline, 1.0)
        {
            EngineVolume = engineVolume;
            FuelConsumptionPer100Km = fuelConsumptionPer100Km;
        }
    }
}
