using System;

namespace Autopark
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    class VechileType
    {
        private string typeName;
        private double taxCoefficient;

        public VechileType(string type, double taxCoefficient = 1.0)
        {
            this.typeName = type;
            this.taxCoefficient = taxCoefficient;
        }

        public string TypeName
        {
            get { return typeName; }
            set { this.typeName = value; }
        }

        public double TaxCoefficient
        {
            get { return taxCoefficient; }
            set { this.taxCoefficient = value; }
        }

        public void Display()
        {
            Console.WriteLine(
                "TypeName = {0}\nTaxCoefficient = {1}",
                this.typeName,
                this.taxCoefficient
            );
        }

        public override string ToString() => $"{typeName}, \"{taxCoefficient}\"";
    }
}