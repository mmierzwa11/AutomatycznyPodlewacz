namespace AutomatycznyPodlewacz.Services
{
    public interface ISensorService
    {
        double GetTemperature();
        double GetHumidity();
    }
}
