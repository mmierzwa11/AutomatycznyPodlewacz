using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Iot.Device.DHTxx;

namespace AutomatycznyPodlewacz.Services
{
    public class SensorService :ISensorService
    {
	private readonly Dht11 _dht11;
	public SensorService(){
		_dht11 = new Dht11(17);
	}

        Random r = new Random();
        public double GetTemperature()
        {
            return _dht11.Temperature.Celsius;
        }

        public double GetHumidity()
        {
            return _dht11.Humidity;
        }
    }
}
