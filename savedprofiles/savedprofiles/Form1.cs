using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security;

namespace savedprofiles
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.CreateNoWindow = true;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C " + "netsh wlan show profiles";
            process.StartInfo = startInfo;
            process.Start();
            string outp = process.StandardOutput.ReadToEnd();
            string test = outp;
            int start, end;
            string test2;
            test = test.Substring(test.IndexOf("User"), test.Length - test.IndexOf("User"));
            //int len = outp.Length;
            //MessageBox.Show(len.ToString());
            //MessageBox.Show(test);
            while (test.Length > 5)
            {
                start = test.IndexOf(": ") + 2;
                test2 = test.Substring(start+2);
                end = test2.IndexOf('\r');
                comboBox1.Items.Add(test.Substring(start, end+2));
                test = test.Substring(start+end+2);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.CreateNoWindow = true;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C " + "netsh wlan show profile name=\"" + comboBox1.SelectedItem.ToString() + "\" key=\"clear\"";
            process.StartInfo = startInfo;
            process.Start();
            string pass = process.StandardOutput.ReadToEnd();
            pass = pass.Substring(pass.IndexOf("Key Content"));
            pass = pass.Substring(pass.IndexOf(": ")+2,pass.IndexOf('\r')-(pass.IndexOf(": ") + 2));
            MessageBox.Show(pass);
        }
    }
}
