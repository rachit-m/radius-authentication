using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PoziomLabs;

namespace test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Netsh obj = new Netsh();
            //textBox1.Text = obj.ProfileAdd(@"C:\Users\SAIKAT\Desktop\Wi-Fi-Uno_Test.xml");

            //textBox1.Text = obj.Connect("Uno_Test");

            //string[] a = obj.SavedProfileList().ToArray();

            //foreach (var item in a)
            //{
            //    textBox1.Text = textBox1.Text + item;

            //}

            //textBox1.Text = obj.GetProfilePassword("DIGISOL");

            Net_Stats obje = new Net_Stats();

            //textBox1.Text = obje.DownloadedKB().ToString();
            //textBox1.Text = obje.UploadedKB().ToString();

            Cert objec = new Cert();

            //objec.Add_p12(@"C:\Users\SAIKAT\Desktop\cert\contact@poziomlabs.com.p12","clientprivate");
            //objec.Add_der(@"C:\Users\SAIKAT\Desktop\cert\ca.der");

            XmlProfile object1 = new XmlProfile();

            //object1.Generate("Uno_Test", "CE2760F3BF6", "WPA2PSK", @"C:\Users\SAIKAT\Desktop\cert\test.xml");

            PostRequest object2 = new PostRequest();

            //textBox1.Text = object2.reg_api("9434348505", "password", "13707");
            //textBox1.Text = object2.otp_api("9434348505");



        }
    }
}
