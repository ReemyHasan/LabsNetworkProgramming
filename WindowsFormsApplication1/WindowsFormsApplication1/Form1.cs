using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private string res = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void Search_Click(object sender, EventArgs e)
        {
            string searchText = searchTextBox.Text;
            string url = "https://de.search.yahoo.com/search?p=" + searchText;
            string result = string.Empty;
            // Show message in label
            searchStatusLabel.Text = "Searching...";
            searchStatusLabel.Visible = true;
            try
            {
                //WebClient client = new WebClient();
                //result = client.DownloadString(url);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                using (HttpWebResponse resp = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(resp.GetResponseStream());
                    result = reader.ReadToEnd();
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            res = result;
            
            // Display the response in a message box
            MessageBox.Show(result);
            searchStatusLabel.Visible = false;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.html)|*.html";
            saveFileDialog.Title = "Save search results to a file";
            DialogResult result = saveFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                    string filePath = saveFileDialog.FileName;

                    try
                    {
                        if (res != "")
                        {
                            File.WriteAllText(filePath, res);
                            MessageBox.Show("File saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else {
                            MessageBox.Show("No Search results to save.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
            }
        }


    }
}
