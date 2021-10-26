using NET03._1.Sensors;
using System;
using System.Windows.Forms;

namespace NET03._1
{
    public partial class LoadSensors : Form
    {
        SensorsContainer _container;
        public LoadSensors(object obj)
        {
            InitializeComponent();
            _container = (SensorsContainer)obj;
        }
        private void XMLButton_Click(object sender, EventArgs e)
        {
            try
            {
                _container.GetSensorsFromXml();
                this.Close();
            }
            catch { }
            
        }
        private void JsonButton_Click(object sender, EventArgs e)
        {
            try
            {
                _container.GetSensorsFromJson();
                this.Close();
            }
            catch { }
        }
    }
}
