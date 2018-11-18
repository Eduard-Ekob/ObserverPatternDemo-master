using System;
using ObserverPatternDemo.Implemantation.Observable;

namespace ObserverPatternDemo.Implemantation.Observers
{
    /// <summary>
    /// The obsercer which subscribe on weatherdata
    /// </summary>
    public class CurrentConditionsReport : IObserver<WeatherInfo>, ISubscriable
    {
        private IObservable<WeatherInfo> weatherData;
        private WeatherInfo wthrInfo;
        private WeatherInfo _wthrInfo;

        /// <summary>
        /// property contains current value for indication
        /// </summary>
        /// <exception cref="ArgumentNullException">If indicator not connected to sender
        /// throw ArgumentNullException</exception>
        public WeatherInfo WthrInfo
        {
            get
            {
                if (wthrInfo == null)
                {
                    throw new ArgumentNullException("Not connected to sender");
                }
                
                return wthrInfo;
            }
        }
    
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="sender">sender value from sensors</param>
        public CurrentConditionsReport(IObservable<WeatherInfo> sender)
        {
            weatherData = sender;
        }

        /// <summary>
        /// This method call by sender, when information from sensors is updated
        /// </summary>
        /// <param name="sender">sender value from sensors</param>
        /// <param name="info"></param>
        public void Update(IObservable<WeatherInfo> sender, WeatherInfo info)
        {
            wthrInfo = info;
        }

        /// <summary>
        /// Subscribe to sender
        /// </summary>
        /// <param name="sender">sender value from sensors</param>
        public void Subscribe(IObservable<WeatherInfo> sender) => sender.Register(this);

        /// <summary>
        /// Unsubscribe from sender
        /// </summary>
        /// <param name="sender">sender value from sensors</param>
        public void UnSubscribe(IObservable<WeatherInfo> sender)
        {
            sender.Unregister(this);
            wthrInfo = null;
        }
    }
}