using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomatycznyPodlewacz.Services
{
    public class SensorService :ISensorService
    {
        Random r = new Random();
        public double GetTemperature()
        {
            return  r.NextDouble()*50 +10;
        }

        public double GetHumidity()
        {
            return r.NextDouble() * 100;
        }
    }
}
