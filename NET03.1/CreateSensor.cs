using NET03._1.Sensors;
using NET03._1.States;
using System;
using System.Windows.Forms;

namespace NET03._1
{
    public partial class CreateSensor : Form
    {
        SensorsContainer _container;
        public CreateSensor(object obj)
        {
            InitializeComponent();
            TypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            OperationComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            IntervalComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            TypeComboBox.Items.Add("Temperature");
            TypeComboBox.Items.Add("Pressure");
            TypeComboBox.Items.Add("Magnetic");
            OperationComboBox.Items.Add("Simple");
            OperationComboBox.Items.Add("Calibration");
            OperationComboBox.Items.Add("Work");
            for (int i = 1; i <= 50; i++)
            {
                IntervalComboBox.Items.Add(i);
            }
            TypeComboBox.SelectedIndex = 0;
            OperationComboBox.SelectedIndex = 0;
            IntervalComboBox.SelectedIndex = 0;
            _container = (SensorsContainer)obj;
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            int interval = Convert.ToInt32(IntervalComboBox.SelectedItem.ToString());
            SensorType sensorType = SensorType.Temperature;
            State sensorState = new SimpleState();
            if (TypeComboBox.SelectedItem.ToString() == SensorType.Temperature.ToString())
                sensorType = SensorType.Temperature;
            else if (TypeComboBox.SelectedItem.ToString() == SensorType.Pressure.ToString())
                sensorType = SensorType.Pressure;
            else
                sensorType = SensorType.Magnetic;
            if (OperationComboBox.SelectedItem.ToString() == "Simple")
                sensorState = new SimpleState();
            else if (OperationComboBox.SelectedItem.ToString() == "Work")
                sensorState = new WorkState();
            else
                sensorState = new CalibrationState();
            _container.AddSensor(interval, 0, sensorType, sensorState);
            this.Close();
        }
    }
}
