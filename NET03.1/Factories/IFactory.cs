using NET03._1.States;
namespace NET03._1
{
    interface IFactory
    {
        ISensor CreateSensor(int interval, int measuredValue, SensorType sensorType, State sensorState);
    }
}
