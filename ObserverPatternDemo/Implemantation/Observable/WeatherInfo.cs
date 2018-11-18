namespace ObserverPatternDemo.Implemantation.Observable
{
    public class WeatherInfo : EventInfo
    {
        public WeatherInfo(int temperature, int pressure, int humidity)
        {
            Temperature = temperature;
            Pressure = pressure;
            Humidity = humidity;
        }

        public int Temperature { get; set; }
        public int Humidity { get; set; }
        public int Pressure { get; set; }
    }
}