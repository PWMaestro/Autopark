using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopark
{
    public class Engine
    {
        public string TypeName { get; set; }
        public double TaxCoeffByEngineType { get; set; }

        public Engine(string engineType, double taxCoeffByEngineType)
        {
            TypeName = engineType;
            TaxCoeffByEngineType = taxCoeffByEngineType;
        }
    }
}
