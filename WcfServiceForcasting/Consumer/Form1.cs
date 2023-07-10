using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Consumer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create a proxy to the WCF service
            var client = new WeatherServiceClient.ForcastServiceClient();

            try
            {
                // Call the GetWeather method on the WCF service
                var weather = client.GetWeatherForecast(textBox1.Text);
                 
                MessageBox.Show("Temperature: "+ weather.Temperature+
                    " °C\nCountry: " +weather.Country+
                    "\nWind Speed: "+weather.WindSpeed+
                    " km/h\nDescription: "+weather.Description);
            }
            catch (Exception ex)
            {
                // Display any errors from the WCF service in a message box
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Close the proxy to the WCF service
                client.Close();
            }
        }
    }
}
