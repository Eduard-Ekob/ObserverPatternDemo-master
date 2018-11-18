using System;
using System.Threading;
using ObserverPatternDemo.Implemantation.Observable;
using ObserverPatternDemo.Implemantation.Observers;

namespace WeatherStation
{
    class Program
    {
        static void Main(string[] args)
        {
            WeatherData sender = new WeatherData();
            CurrentConditionsReport currentConditionsReport = 
                new CurrentConditionsReport(sender);
            currentConditionsReport.Subscribe(sender);
            StatisticReport statisticReport = new StatisticReport(sender);
            statisticReport.Subscribe(sender);
            WeatherInfo weatherInfo = new WeatherInfo(20, 740, 75);
            sender.Notify(sender, weatherInfo);
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(500);
                weatherInfo = new WeatherInfo(
                    rnd.Next(-3, 20), 
                    rnd.Next(730, 780), 
                    rnd.Next(60, 95));                                 
                sender.Notify(sender, weatherInfo);
                Console.WriteLine("Temperature {0}, Pressure {1}, Humidity {2}", 
                    currentConditionsReport.WthrInfo.Temperature,
                    currentConditionsReport.WthrInfo.Pressure,
                    currentConditionsReport.WthrInfo.Humidity);
            }

            Console.WriteLine();
            Console.WriteLine("Stat report:");
            Console.WriteLine("MinTemperature: {0}", statisticReport.GetTemperatureMin());
            Console.WriteLine("MaxTemperature: {0}", statisticReport.GetTemperatureMax());
            Console.WriteLine("MinPressure: {0}", statisticReport.GetPresureMin());
            Console.WriteLine("MaxPressure: {0}", statisticReport.GetPresureMax());
            Console.WriteLine("MinHumidity: {0}", statisticReport.GetHumidityMin());
            Console.WriteLine("MinHumidity: {0}", statisticReport.GetHumidityMax());
            Console.WriteLine("AverageTemperature: {0}", statisticReport.GetTemperatureAverage());
            Console.WriteLine("AveragePressure: {0}", statisticReport.GetPressureAverage());
            Console.WriteLine("AverageHumidity: {0}", statisticReport.GetHumidityAverage());

            currentConditionsReport.UnSubscribe(sender);
            sender.Notify(sender, weatherInfo);
            try
            {
                Console.WriteLine("Temperature: {0}", currentConditionsReport.WthrInfo.Temperature);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);                
            }

            Console.WriteLine("Try again!!!");
            Thread.Sleep(3000);
            currentConditionsReport.Subscribe(sender);
            sender.Notify(sender, weatherInfo);
            Console.WriteLine("Temperature: {0}", currentConditionsReport.WthrInfo.Temperature);

            Console.ReadLine();
        }
    }
}
