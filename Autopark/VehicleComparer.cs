using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopark
{
    public class VehicleComparer : IComparer<Vehicle>
    {
        public int Compare(Vehicle first, Vehicle second) => first.ModelName.CompareTo(second.ModelName);
    }
}
