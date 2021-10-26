using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
