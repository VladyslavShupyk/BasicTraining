using NET03._1.Observer;
using NET03._1.States;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NET03._1
{
    class MagneticSensor : ISensor
    {
        public int Id { get; set; }
        public int Interval { get; set; }
        public int MeasuredValue { get; set; }
        public SensorType SensorType { get; set; }
        public State SensorState { get; set; }
        public CancellationTokenSource CancellationTokenSource { get; set; }
        public List<IObserver> observers { get ; set; }

        public MagneticSensor(int interval, int measuredValue, SensorType sensorType, State sensorState)
        {
            Id = IDGenerator.GetInstance().GetId();
            Interval = interval;
            MeasuredValue = measuredValue;
            SensorType = sensorType;
            SensorState = sensorState;
            CancellationTokenSource = new CancellationTokenSource();
            observers = new List<IObserver>();
        }
        public void Start()
        {
            CancellationTokenSource = new CancellationTokenSource();
            Task task = new Task(() => SensorState.Start(this, CancellationTokenSource.Token));
            task.Start();
        }
        public void Stop()
        {
            CancellationTokenSource.Cancel();
        }
        public void ChangeState(State sensorState)
        {
            Stop();
            SensorState = sensorState;
        }

        public void RegisterObserver(IObserver o)
        {
            observers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            observers.Remove(o);
        }

        public void NotifyObservers()
        {
            foreach(IObserver o in observers)
            {
                o.Update("ID - " + Id + " " + SensorType + " - " + MeasuredValue);
            }
        }
        public void SwitchingState()
        {
            Stop();
            SensorState = new SimpleState();
            SensorState = SensorState.NextState(this);
            SensorState = SensorState.NextState(this);
            SensorState = SensorState.NextState(this);
        }
    }
}
