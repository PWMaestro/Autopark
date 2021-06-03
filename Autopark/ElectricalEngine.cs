using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopark
{
    public class ElectricalEngine : AbstractEngine
    {
        public double ElectricityConsumption { get; }

        public ElectricalEngine(double electricityConsumption)
            : base(EngineTypes.Electrical, 0.1)
        {
            ElectricityConsumption = electricityConsumption;
        }

        public override double GetMaxKilometers(double batterySize) => batterySize / ElectricityConsumption;

        public override string ToString() => $"{base.ToString()} {ElectricityConsumption}";
    }
}
