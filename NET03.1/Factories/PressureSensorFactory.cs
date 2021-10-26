using NET03._1.States;

namespace NET03._1
{
    class PressureSensorFactory : IFactory
    {
        public ISensor CreateSensor(int interval,int measuredValue, SensorType sensorType, State sensorState)
        {
            return new PressureSensor(interval, measuredValue, sensorType, sensorState);
        }
    }
}
