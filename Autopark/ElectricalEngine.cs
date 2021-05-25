using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopark
{
    class ElectricalEngine : Engine
    {
        public double ElectricityConsumption { get; set; }

        public ElectricalEngine(double electricityConsumption)
            : base("Electrical", 0.1)
        {
            ElectricityConsumption = electricityConsumption;
        }

        public double GetMaxKilometers(double batterySize)
        {
            return batterySize / ElectricityConsumption;
        }
    }
}
