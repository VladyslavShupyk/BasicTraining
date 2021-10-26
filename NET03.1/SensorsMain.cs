using NET03._1.Observer;
using NET03._1.Sensors;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace NET03._1
{
    public partial class SensorsMain : Form, IObserver
    {
        SensorsContainer _container;
        public SensorsMain()
        {
            InitializeComponent();
            _container = new SensorsContainer();
            try
            {
                SensorsListLoad(_container);
            }
            catch(Exception excaption)
            {
                MessageBox.Show(excaption.Message);
            }
        }
        private void ModeButton_Click(object sender, EventArgs e)
        {
            if (SensorsList.SelectedItem != null)
            {
                string item = SensorsList.SelectedItem.ToString();
                string[] items = item.Split(' ');
                int id = Convert.ToInt32(items[0]);
                ChangeOperation changeOperation = new ChangeOperation(_container, id);
                changeOperation.ShowDialog();
            }
            else
                MessageBox.Show("Please select sensor in list of sensors.", "Information", MessageBoxButtons.OK);
        }
        private void SensorsListLoad(SensorsContainer sensors)
        {
            SensorsList.Items.Clear();
            foreach (ISensor sensor in sensors.sensors)
            {
                sensor.RemoveObserver(this);
            }
            foreach (ISensor sensor in sensors.sensors)
            {
                SensorsList.Items.Add(sensor.Id + " " + sensor.SensorType);
                sensor.RegisterObserver(this);
            }
        }
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if(SensorsList.SelectedItem != null)
            {
                string item = SensorsList.SelectedItem.ToString();
                string[] items = item.Split(' ');
                int id = Convert.ToInt32(items[0]);
                _container.DeleteSensor(id);
                SensorsList.Items.Clear();
                SensorsListLoad(_container);
            }
            else
                MessageBox.Show("For delete select sensor in list of sensors.", "Information", MessageBoxButtons.OK);
        }
        private void CreateButton_Click(object sender, EventArgs e)
        {
            CreateSensor createSensor = new CreateSensor(_container);
            createSensor.ShowDialog();
            SensorsListLoad(_container);
        }

        private void StratButton_Click(object sender, EventArgs e)
        {
            foreach(ISensor sensor in _container.sensors)
            {
                sensor.Start();
            }
        }
        private void StopButton_Click(object sender, EventArgs e)
        {
            foreach (ISensor sensor in _container.sensors)
            {
                sensor.Stop();
            }
            Task.WaitAll();
        }
        public void Update(object ob)
        {
            SensorsStatusText.Invoke(new Action(() => SensorsStatusText.Text += DateTime.Now + ", " + ob.ToString() + "\n"));
        }

        private void SaveToJsonButton_Click(object sender, EventArgs e)
        {
            _container.SaveToJson();
        }

        private void SaveToXMLButton_Click(object sender, EventArgs e)
        {
            _container.SaveToXml();
        }

        private void LoadConfigurationButton_Click(object sender, EventArgs e)
        {
            LoadSensors loadSensors = new LoadSensors(_container);
            loadSensors.ShowDialog();
            SensorsListLoad(_container);
        }

        private void SwitchingModeButton_Click(object sender, EventArgs e)
        {
            if (SensorsList.SelectedItem != null)
            {
                string item = SensorsList.SelectedItem.ToString();
                string[] items = item.Split(' ');
                int id = Convert.ToInt32(items[0]);
                _container.SwitchMode(id);
            }
            else
                MessageBox.Show("For switching modes select sensor in list of sensors.", "Information", MessageBoxButtons.OK);
        }
    }
}
