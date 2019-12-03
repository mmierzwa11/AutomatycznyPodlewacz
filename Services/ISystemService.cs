namespace AutomatycznyPodlewacz.Services
{
    public interface ISystemService
    {
        void Initialize();
        bool IsInitialized { get; }
        bool IsWatering { get; }
        double CurrentTemperature { get; }
        double CurrentHumidity { get; }
    }
}
