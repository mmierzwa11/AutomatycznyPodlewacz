using System;
using System.Threading.Tasks;

namespace AutomatycznyPodlewacz.Services
{
    public class SystemService : ISystemService
    {
        private const double CriticalHumidity = 50.0;
        private const double CriticalTemperature = 40.0;

        private readonly ISensorService _sensorService;
        private readonly IPumpService _pumpService;

        public SystemService(ISensorService sensorService, IPumpService pumpService)
        {
            _sensorService = sensorService;
            _pumpService = pumpService;
        }

        public void Initialize()
        {
            ObserveSensor();
            IsInitialized = true;
        }

        public bool IsInitialized { get; private set; }
        public bool IsWatering { get; private set; }
        public double CurrentTemperature { get; private set; }
        public double CurrentHumidity { get; private set; }

        private Task ObserveSensor()
        {
            return Task.Run(async () =>
           {
               while (true)
               {
		   var currentTemperature = _sensorService.GetTemperature();
                   while(!double.IsFinite(currentTemperature)){
			await Task.Delay(100);
			currentTemperature = _sensorService.GetTemperature();
	           }
	           CurrentTemperature = currentTemperature;


			var currentHumidity = _sensorService.GetHumidity();
			
			while(!double.IsFinite(currentHumidity)){
				await Task.Delay(100);
				currentHumidity = _sensorService.GetHumidity();
			}
			CurrentHumidity = currentHumidity;
			

                   if (CurrentHumidity < CriticalHumidity || CurrentTemperature > CriticalTemperature)
                   {
                       await Water();
                   }
                   await Task.Delay(6000);
               }
           });
        }

        private readonly object _waterLock = new object();
        private Task Water(int period = 5000)
        {
            return Task.Run(() =>
            {
                lock (_waterLock)
                {
                    IsWatering = true;
                    _pumpService.Pump(period);
                    IsWatering = false;
                }
            });
        }
    }
}
