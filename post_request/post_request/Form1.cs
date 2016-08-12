using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Collections.Specialized;

namespace post_request
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var client = new WebClient())
            {
                var values = new NameValueCollection();
                values["user_contact"] = textBox1.Text;
                values["user_password"] = "password";
                values["user_otp"] = "12345";

                var response = client.UploadValues("http://52.27.54.85/rad_app/reg.php", values);

                var responseString = Encoding.Default.GetString(response);

                MessageBox.Show(responseString);
            }
        }
    }
}
