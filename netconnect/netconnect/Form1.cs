// App to add a connection profile from XML file and 
// connect or disconnect from the specific WiFi network.

// Importing all the necessary classes for our client app

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Security;

namespace netconnect
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // button3 is the browse button to locate the xml file
        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "XML Files (.xml)|*.xml";  //to select XML files
            openFileDialog1.Multiselect = false;  // only one xml file is accepted
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }

            // using a cmd process to add the profile from XML file using netsh commands

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.CreateNoWindow = true;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C " + "netsh wlan add profile filename=" + "\"" + textBox1.Text + "\"";
            process.StartInfo = startInfo;
            process.Start();
            logbox.Text = logbox.Text + process.StandardOutput.ReadToEnd();
            logbox.Text = logbox.Text + process.StandardError.ReadToEnd();
            if (textBox1.Text!="")
            {
                XmlDocument doc = new XmlDocument(); // parsing the xml document to find the SSID of network
                doc.Load(textBox1.Text);

                XmlNodeList elemList = doc.GetElementsByTagName("name");
                textBox2.Text = elemList[0].InnerXml;
            }
        }

        // using a cmd process to connect to the Wifi Network using netsh commands

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.CreateNoWindow = true;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C "+ "netsh wlan connect name="+"\""+textBox2.Text+"\"";
            process.StartInfo = startInfo;
            process.Start();
            logbox.Text = logbox.Text + process.StandardOutput.ReadToEnd();
            logbox.Text = logbox.Text + process.StandardError.ReadToEnd();
        }

        // using a cmd process to disconnect from the Wifi Network using netsh commands

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError=true;
            startInfo.CreateNoWindow = true;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C " + "netsh wlan disconnect";
            process.StartInfo = startInfo;
            process.Start();
            logbox.Text = logbox.Text + process.StandardOutput.ReadToEnd();
            logbox.Text = logbox.Text + process.StandardError.ReadToEnd();
        }
    }
}
