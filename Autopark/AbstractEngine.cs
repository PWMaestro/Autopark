using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopark
{
    public abstract class AbstractEngine
    {
        public string TypeName { get; }
        public double TaxCoeffByEngineType { get; }

        protected AbstractEngine(string engineType, double taxCoeffByEngineType)
        {
            TypeName = $"{engineType} {EngineTypes.basicName}";
            TaxCoeffByEngineType = taxCoeffByEngineType;
        }

        public abstract double GetMaxKilometers(double fuelTank);

        public override string ToString() => TypeName;
    }
}
