using ObserverPatternDemo.Implemantation.Observable;

namespace ObserverPatternDemo.Implemantation.Observers
{
    public interface ISubscriable
    {
        void Subscribe(IObservable<WeatherInfo> sender);
        void UnSubscribe(IObservable<WeatherInfo> sender);
    }
}