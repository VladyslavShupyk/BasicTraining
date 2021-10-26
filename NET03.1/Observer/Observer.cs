using System;

namespace NET03._1.Observer
{
    interface IObserver
    {
        void Update(Object ob);
    }
    interface IObservable
    {
        void RegisterObserver(IObserver o);
        void RemoveObserver(IObserver o);
        void NotifyObservers();
    }
}
