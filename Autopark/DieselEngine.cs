﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopark
{
    class DieselEngine : CombustionEngine
    {
        public DieselEngine(double engineVolume, double fuelConsumptionPer100Km)
                : base("Diesel", 1.2)
        {
            EngineVolume = engineVolume;
            FuelConsumptionPer100Km = fuelConsumptionPer100Km;
        }
    }
}