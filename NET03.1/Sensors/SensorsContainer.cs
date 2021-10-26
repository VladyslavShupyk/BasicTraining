using NET03._1.States;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace NET03._1.Sensors
{
    class SensorsContainer
    {
        const string DEFAULT_PATH_XML = @"..\..\..\Configuration/sensors.xml";
        const string DEFAULT_PATH_JSON = @"..\..\..\Configuration/sensors.json";
        public List<ISensor> sensors;
        public SensorsContainer()
        {
            sensors = new List<ISensor>();
        }
        public void GetSensorsFromXml()
        {
            XmlDocument document = new XmlDocument();
            document.Load(DEFAULT_PATH_XML);
            SensorType sensorType = SensorType.Temperature;
            State sensorState = new SimpleState();
            int interval = 0;
            int measuredValue = 0;
            XmlElement rootNode = document.DocumentElement;
            try
            {
                foreach (XmlNode node in rootNode)
                {
                    foreach (XmlNode childNode in node)
                    {
                        if (childNode.Name == "type")
                        {
                            if (childNode.InnerText == "Temperature")
                                sensorType = SensorType.Temperature;
                            else if (childNode.InnerText == "Magnetic")
                                sensorType = SensorType.Magnetic;
                            else if (childNode.InnerText == "Pressure")
                                sensorType = SensorType.Pressure;
                            else
                                throw new Exception("Incorrect type of sensor.");
                        }
                        if (childNode.Name == "interval")
                            interval = Convert.ToInt32(childNode.InnerText);
                        if (childNode.Name == "mode")
                        {
                            if (childNode.InnerText == "Simple")
                                sensorState = new SimpleState();
                            else if (childNode.InnerText == "Work")
                                sensorState = new WorkState();
                            else if (childNode.InnerText == "Calibration")
                                sensorState = new CalibrationState();
                            else
                                throw new Exception("Incorrect operation mode of sensor.");
                        }
                        if (childNode.Name == "measuredValue")
                            measuredValue = Convert.ToInt32(childNode.InnerText);
                    }
                    AddSensor(interval, measuredValue, sensorType, sensorState);
                }
            }
            catch(Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
        public void GetSensorsFromJson()
        {
            string jsonString = File.ReadAllText(DEFAULT_PATH_JSON);
            var sensorList = JsonConvert.DeserializeObject<List<SensorDataJson>>(jsonString);
            SensorType type = SensorType.Temperature;
            State state = new SimpleState();
            foreach(var sensor in sensorList)
            {
                if (sensor.Mode == "Calibration")
                    state = new CalibrationState();
                else if (sensor.Mode == "Work")
                    state = new WorkState();
                else
                    state = new SimpleState();
                if (sensor.Type == SensorType.Magnetic.ToString())
                    type = SensorType.Magnetic;
                else if (sensor.Type == SensorType.Pressure.ToString())
                    type = SensorType.Pressure;
                else
                    type = SensorType.Temperature;
                AddSensor(sensor.Interval, sensor.MeasuredValue, type, state);
            }
        }
        public void AddSensor(int interval, int measuredValue, SensorType sensorType, State sensorState)
        {
            IFactory factory;
            ISensor sensor;
            if (sensorType == SensorType.Temperature)
            {
                factory = new TemperatureSensorFactory();
                sensor = factory.CreateSensor(interval, measuredValue, sensorType, sensorState);
                sensors.Add(sensor);
            }
            else if (sensorType == SensorType.Magnetic)
            {
                factory = new MagneticSensorFactory();
                sensor = factory.CreateSensor(interval, measuredValue, sensorType, sensorState);
                sensors.Add(sensor);
            }
            else
            {
                factory = new PressureSensorFactory();
                sensor = factory.CreateSensor(interval, measuredValue, sensorType, sensorState);
                sensors.Add(sensor);
            }
        }
        public void SaveToXml()
        {
            XDocument doc = new XDocument();
            XElement RootElement = new XElement("sensors");
            XElement sensor, sensorType, sensorInterval, sensorMode, sensorMeasuredValue;
            foreach (ISensor s in sensors)
            {
                sensor = new XElement("sensor");
                sensorType = new XElement("type", s.SensorType);
                sensorInterval = new XElement("interval", s.Interval);
                if(s.SensorState.GetType() == typeof(CalibrationState))
                    sensorMode = new XElement("mode", "Calibration");
                else if(s.SensorState.GetType() == typeof(WorkState))
                    sensorMode = new XElement("mode", "Work");
                else
                    sensorMode = new XElement("mode", "Simple");
                sensorMeasuredValue = new XElement("measuredValue", s.MeasuredValue);
                sensor.Add(sensorType);
                sensor.Add(sensorInterval);
                sensor.Add(sensorMode);
                sensor.Add(sensorMeasuredValue);
                RootElement.Add(sensor);
            }
            doc.Add(RootElement);
            doc.Save(DEFAULT_PATH_XML);
        }
        public void SaveToJson()
        {
            List<SensorDataJson> sensors = new List<SensorDataJson>();
            string mode = String.Empty;
            string type = String.Empty;
            foreach(ISensor s in this.sensors)
            {
                if (s.SensorState.GetType() == typeof(SimpleState))
                    mode = "Simple";
                else if (s.SensorState.GetType() == typeof(WorkState))
                    mode = "Work";
                else
                    mode = "Calibration";
                sensors.Add(new SensorDataJson { Interval = s.Interval, MeasuredValue = s.MeasuredValue, Mode = mode, Type = s.SensorType.ToString()});
            }
            var sensorsJson = JsonConvert.SerializeObject(sensors);
            using (StreamWriter file = File.CreateText(DEFAULT_PATH_JSON))
            {
                file.WriteLine(sensorsJson);
            }
        }
        public void DeleteSensor(int Id)
        {
            ISensor findedSensor = null;
            foreach(ISensor sensor in sensors)
            {
                if(sensor.Id == Id)
                {
                    sensor.Stop();
                    findedSensor = sensor;
                }
            }
            if(findedSensor != null)
            {
                sensors.Remove(findedSensor);
            }
        }
        public void SwitchMode(int Id)
        {
            foreach (ISensor sensor in sensors)
            {
                if (sensor.Id == Id)
                {
                    sensor.SwitchingState();
                }
            }
        }
    }
}
