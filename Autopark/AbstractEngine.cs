using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopark
{
    public abstract class AbstractEngine
    {
        public EngineTypes TypeName { get; }
        public double TaxCoeffByEngineType { get; }

        protected AbstractEngine(EngineTypes engineType, double taxCoeffByEngineType)
        {
            TypeName = engineType;
            TaxCoeffByEngineType = taxCoeffByEngineType;
        }

        public abstract double GetMaxKilometers(double fuelTank);

        public override string ToString() => TypeName.ToString();
    }
}
