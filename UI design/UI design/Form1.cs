using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UI_design
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Close",pictureBox1);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Properties.Resources.close1;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Properties.Resources.close_black;
        }
        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.DarkOrange;
            pictureBox3.BackColor = Color.White;
            panel2.Visible = false;
            panel1.Visible = true;
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.DarkOrange;
            pictureBox2.BackColor = Color.White;
            panel1.Visible = false;
            panel2.Visible = true;
        }
    }
}
