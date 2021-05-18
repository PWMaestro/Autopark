using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopark
{
    class VechileType
    {
        public string TypeName { get; set; }
        public double TaxCoefficient { get; set; }

        public VechileType(string type, double taxCoefficient = 1.0)
        {
            this.TypeName = type;
            this.TaxCoefficient = taxCoefficient;
        }

        public void Display()
        {
            Console.WriteLine(
                "TypeName = {0}\nTaxCoefficient = {1}",
                this.TypeName,
                this.TaxCoefficient
            );
        }

        public override string ToString() => $"{TypeName}, \"{TaxCoefficient}\"";
    }
}