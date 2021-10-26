using NET03._1.States;

namespace NET03._1
{
    class TemperatureSensorFactory : IFactory
    {
        public ISensor CreateSensor(int interval, int measuredValue, SensorType sensorType, State sensorState)
        {
            return new TemperatureSensor(interval, measuredValue,sensorType, sensorState);
        }
    }
}
