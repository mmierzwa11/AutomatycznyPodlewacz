using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Iot.Device.DCMotor;


namespace AutomatycznyPodlewacz.Services
{
    public class PumpService :IPumpService
    {
	private readonly DCMotor _pump;

	public PumpService(){
		_pump = DCMotor.Create(24,23,18);
	}


        public bool Pump(int duration)
        {
            _pump.Speed = 1.0;
		Thread.Sleep(duration);
		_pump.Speed = 0;
            return true;
        }
    }
}
