using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AutomatycznyPodlewacz.Services
{
    public class PumpService :IPumpService
    {
        public bool Pump(int duration)
        {
            Thread.Sleep(duration);
            return true;
        }
    }
}
