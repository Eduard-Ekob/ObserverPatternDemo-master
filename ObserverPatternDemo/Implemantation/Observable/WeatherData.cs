using System;
using System.Collections;
using System.Collections.Generic;

namespace ObserverPatternDemo.Implemantation.Observable
{
    public class WeatherData : IObservable<WeatherInfo>
    {
        private List<IObserver<WeatherInfo>> observers;

        public WeatherData()
        {
            observers = new List<IObserver<WeatherInfo>>();
        }

        public void Notify(IObservable<WeatherInfo> sender, WeatherInfo info)
        {            
            foreach (var obs in observers)
            {
                obs.Update(sender, info);
            }
        }

        public void Register(IObserver<WeatherInfo> observer) => observers.Add(observer);

        public void Unregister(IObserver<WeatherInfo> observer)
        {
            int i = observers.IndexOf(observer);
            if (i >= 0)
            {
                observers.Remove(observer);
            }
        }
    }
}