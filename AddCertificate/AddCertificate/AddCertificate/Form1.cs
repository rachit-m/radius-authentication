﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;

namespace AddCertificate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "p12 Files (.p12)|*.p12";  //to select p12 files
            openFileDialog1.Multiselect = false;  // only one p12 file is accepted
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "der Files (.der)|*.der";  //to select der files
            openFileDialog1.Multiselect = false;  // only one der file is accepted
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = openFileDialog1.FileName;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            X509Certificate2 certificate = new X509Certificate2(textBox1.Text, "clientprivate");
            var store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadWrite);
            store.Add(certificate);
            store.Close();

            var store2 = new X509Store(StoreName.Root, StoreLocation.CurrentUser);
            store2.Open(OpenFlags.ReadWrite);
            store2.Add(certificate);
            store2.Close();

            X509Certificate2 certificate2 = new X509Certificate2(textBox2.Text);
            var store3 = new X509Store(StoreName.Root, StoreLocation.CurrentUser);
            store3.Open(OpenFlags.ReadWrite);
            store3.Add(certificate2);
            store3.Close();

            var store4 = new X509Store(StoreName.CertificateAuthority, StoreLocation.CurrentUser);
            store4.Open(OpenFlags.ReadWrite);
            store4.Add(certificate2);
            store4.Close();
        }
    }
}
