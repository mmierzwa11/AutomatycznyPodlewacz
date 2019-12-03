namespace AutomatycznyPodlewacz.Models
{
    public class SystemState
    {
        public SystemState()
        {
            IsRunning = false;
        }

        public SystemState(bool isWatering, double currentTemperature, double currentHumidity)
        {
            IsRunning = true;
            IsWatering = isWatering;
            CurrentTemperature = currentTemperature;
            CurrentHumidity = currentHumidity;
        }

        public bool IsRunning { get; }
        public  bool IsWatering { get; }
        public  double CurrentTemperature { get; }
        public  double CurrentHumidity { get; }
    }
}
