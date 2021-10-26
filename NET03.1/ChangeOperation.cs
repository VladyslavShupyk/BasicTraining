using NET03._1.Sensors;
using NET03._1.States;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NET03._1
{
    public partial class ChangeOperation : Form
    {
        SensorsContainer _container;
        int _id;
        public ChangeOperation(object obj,int id)
        {
            InitializeComponent();
            _container = (SensorsContainer)obj;
            _id = id;
            OperationComboBox.Items.Add("Simple");
            OperationComboBox.Items.Add("Calibration");
            OperationComboBox.Items.Add("Work");
            OperationComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            OperationComboBox.SelectedIndex = 0;
            foreach (ISensor sensor in _container.sensors)
                if (sensor.Id == _id)
                {
                    if(sensor.SensorState.GetType() == typeof(SimpleState))
                    {
                        OperationText.Text += "Simple";
                    }
                    else if(sensor.SensorState.GetType() == typeof(WorkState))
                    {
                        OperationText.Text += "Work";
                    }
                    else
                        OperationText.Text += "Calibration";
                }
        }

        private void ChangeButton_Click(object sender, EventArgs e)
        {
            if(OperationComboBox.SelectedItem.ToString() != OperationText.Text)
            {
                foreach (ISensor sensor in _container.sensors)
                {
                    if (sensor.Id == _id)
                    {
                        sensor.Stop();
                        string operation = OperationComboBox.SelectedItem.ToString();
                        switch (operation)
                        {
                            case "Simple": { sensor.ChangeState(new SimpleState()); } break;
                            case "Work": { sensor.ChangeState(new WorkState()); } break;
                            case "Calibration": { sensor.ChangeState(new CalibrationState()); } break;
                        }
                    }
                }
            }
            this.Close();
        }
    }
}
