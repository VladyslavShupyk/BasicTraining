using System;
using System.Threading;

namespace NET03._1.States
{
    interface State
    {
        void Start(ISensor sensor, CancellationToken token);
        State NextState(ISensor sensor);
    }
    class SimpleState : State
    {
        public void Start(ISensor sensor, CancellationToken token) { }
        public State NextState(ISensor sensor)
        {
            return new CalibrationState();
        }
    }
    class CalibrationState : State
    {
        public void Start(ISensor sensor, CancellationToken token)
        {
            for(;;)
            {
                if (token.IsCancellationRequested)
                    break;
                sensor.MeasuredValue++;
                sensor.NotifyObservers();
                Thread.Sleep(sensor.Interval * 1000);
            }
        }
        public State NextState(ISensor sensor)
        {
            return new WorkState();
        }
    }
    class WorkState : State
    {
        public void Start(ISensor sensor, CancellationToken token)
        {
            Random random = new Random();
            for (;;)
            {
                if (token.IsCancellationRequested)
                    break;
                sensor.MeasuredValue += random.Next(0, 100);
                sensor.NotifyObservers();
                Thread.Sleep(sensor.Interval * 1000);
            }
        }
        public State NextState(ISensor sensor)
        {
            return new SimpleState();
        }
    }
}
