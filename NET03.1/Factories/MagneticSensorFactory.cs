using NET03._1.States;

namespace NET03._1
{
    class MagneticSensorFactory : IFactory
    {
        public ISensor CreateSensor(int interval, int measuredValue, SensorType sensorType, State sensorState)
        {
            return new MagneticSensor(interval, measuredValue, sensorType, sensorState);
        }
    }
}
