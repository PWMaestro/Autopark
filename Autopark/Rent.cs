using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopark
{
    public class Rent
    {
        public int Id { get; }
        public DateTime Date { get; set; }
        public double Cost { get; set; }

        public Rent() {}

        public Rent(int id, DateTime rentDate, double rentCost)
        {
            Id = id;
            Date = rentDate;
            Cost = rentCost;
        }
    }
}
