using NET03._1.States;
using System;

namespace NET03._1
{
    [Serializable]
    class SensorDataJson
    {
        public int Interval { get; set; }
        public int MeasuredValue { get; set; }
        public string Type { get; set; }
        public string Mode { get; set; }
    }
}
