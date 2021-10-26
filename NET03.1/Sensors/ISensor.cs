using NET03._1.Observer;
using NET03._1.States;
using System.Collections.Generic;
using System.Threading;

namespace NET03._1
{
    interface ISensor : IObservable
    {
        List<IObserver> observers { get; set; }
        int Id { get; set; }
        int Interval { get; set; }
        int MeasuredValue { get; set; }
        SensorType SensorType { get; set; }
        State SensorState { get; set; }
        CancellationTokenSource CancellationTokenSource { get; set; }
        void Start();
        void Stop();
        void ChangeState(State sensorState);
        void SwitchingState();
    }
}
