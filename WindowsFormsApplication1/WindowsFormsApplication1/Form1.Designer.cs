namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.sideNav1 = new DevComponents.DotNetBar.Controls.SideNav();
            this.sideNavPanel1 = new DevComponents.DotNetBar.Controls.SideNavPanel();
            this.sideNavPanel3 = new DevComponents.DotNetBar.Controls.SideNavPanel();
            this.Share = new DevComponents.DotNetBar.ButtonX();
            this.checkedListBox2 = new System.Windows.Forms.CheckedListBox();
            this.sideNavPanel2 = new DevComponents.DotNetBar.Controls.SideNavPanel();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.sideNavItem1 = new DevComponents.DotNetBar.Controls.SideNavItem();
            this.separator1 = new DevComponents.DotNetBar.Separator();
            this.sideNavItem2 = new DevComponents.DotNetBar.Controls.SideNavItem();
            this.sideNavItem3 = new DevComponents.DotNetBar.Controls.SideNavItem();
            this.sideNavItem4 = new DevComponents.DotNetBar.Controls.SideNavItem();
            this.label1 = new System.Windows.Forms.Label();
            this.sideNav1.SuspendLayout();
            this.sideNavPanel3.SuspendLayout();
            this.sideNavPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // sideNav1
            // 
            this.sideNav1.Controls.Add(this.sideNavPanel2);
            this.sideNav1.Controls.Add(this.sideNavPanel1);
            this.sideNav1.Controls.Add(this.sideNavPanel3);
            this.sideNav1.Dock = System.Windows.Forms.DockStyle.Left;
            this.sideNav1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.sideNavItem1,
            this.separator1,
            this.sideNavItem2,
            this.sideNavItem3,
            this.sideNavItem4});
            this.sideNav1.Location = new System.Drawing.Point(0, 0);
            this.sideNav1.Name = "sideNav1";
            this.sideNav1.Padding = new System.Windows.Forms.Padding(1);
            this.sideNav1.Size = new System.Drawing.Size(417, 292);
            this.sideNav1.TabIndex = 0;
            this.sideNav1.Text = "sideNav1";
            this.sideNav1.Click += new System.EventHandler(this.sideNav1_Click);
            // 
            // sideNavPanel1
            // 
            this.sideNavPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sideNavPanel1.Location = new System.Drawing.Point(92, 36);
            this.sideNavPanel1.Name = "sideNavPanel1";
            this.sideNavPanel1.Size = new System.Drawing.Size(320, 255);
            this.sideNavPanel1.TabIndex = 2;
            this.sideNavPanel1.Visible = false;
            // 
            // sideNavPanel3
            // 
            this.sideNavPanel3.Controls.Add(this.Share);
            this.sideNavPanel3.Controls.Add(this.checkedListBox2);
            this.sideNavPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sideNavPanel3.Location = new System.Drawing.Point(92, 36);
            this.sideNavPanel3.Name = "sideNavPanel3";
            this.sideNavPanel3.Size = new System.Drawing.Size(320, 255);
            this.sideNavPanel3.TabIndex = 10;
            this.sideNavPanel3.Visible = false;
            // 
            // Share
            // 
            this.Share.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Share.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Share.Location = new System.Drawing.Point(219, 110);
            this.Share.Name = "Share";
            this.Share.Size = new System.Drawing.Size(75, 23);
            this.Share.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Share.TabIndex = 2;
            this.Share.Text = "Share";
            this.Share.Click += new System.EventHandler(this.Share_Click);
            // 
            // checkedListBox2
            // 
            this.checkedListBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.checkedListBox2.FormattingEnabled = true;
            this.checkedListBox2.Location = new System.Drawing.Point(0, 0);
            this.checkedListBox2.Name = "checkedListBox2";
            this.checkedListBox2.Size = new System.Drawing.Size(213, 255);
            this.checkedListBox2.TabIndex = 1;
            // 
            // sideNavPanel2
            // 
            this.sideNavPanel2.Controls.Add(this.checkedListBox1);
            this.sideNavPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sideNavPanel2.Location = new System.Drawing.Point(92, 36);
            this.sideNavPanel2.Name = "sideNavPanel2";
            this.sideNavPanel2.Size = new System.Drawing.Size(320, 255);
            this.sideNavPanel2.TabIndex = 6;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.BackColor = System.Drawing.Color.LightGreen;
            this.checkedListBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(0, 0);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(320, 255);
            this.checkedListBox1.TabIndex = 0;
            // 
            // sideNavItem1
            // 
            this.sideNavItem1.IsSystemMenu = true;
            this.sideNavItem1.Name = "sideNavItem1";
            this.sideNavItem1.Symbol = "";
            this.sideNavItem1.Text = "Menu";
            // 
            // separator1
            // 
            this.separator1.FixedSize = new System.Drawing.Size(3, 1);
            this.separator1.Name = "separator1";
            this.separator1.Padding.Bottom = 2;
            this.separator1.Padding.Left = 6;
            this.separator1.Padding.Right = 6;
            this.separator1.Padding.Top = 2;
            this.separator1.SeparatorOrientation = DevComponents.DotNetBar.eDesignMarkerOrientation.Vertical;
            // 
            // sideNavItem2
            // 
            this.sideNavItem2.Name = "sideNavItem2";
            this.sideNavItem2.Panel = this.sideNavPanel1;
            this.sideNavItem2.Symbol = "";
            this.sideNavItem2.Text = "Home";
            // 
            // sideNavItem3
            // 
            this.sideNavItem3.Checked = true;
            this.sideNavItem3.Name = "sideNavItem3";
            this.sideNavItem3.Panel = this.sideNavPanel2;
            this.sideNavItem3.Symbol = "";
            this.sideNavItem3.Text = "Contacts";
            // 
            // sideNavItem4
            // 
            this.sideNavItem4.Name = "sideNavItem4";
            this.sideNavItem4.Panel = this.sideNavPanel3;
            this.sideNavItem4.Symbol = "";
            this.sideNavItem4.Text = "Profiles";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(377, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 17;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 292);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sideNav1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.sideNav1.ResumeLayout(false);
            this.sideNav1.PerformLayout();
            this.sideNavPanel3.ResumeLayout(false);
            this.sideNavPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.SideNav sideNav1;
        private DevComponents.DotNetBar.Controls.SideNavPanel sideNavPanel3;
        private DevComponents.DotNetBar.ButtonX Share;
        private System.Windows.Forms.CheckedListBox checkedListBox2;
        private DevComponents.DotNetBar.Controls.SideNavPanel sideNavPanel1;
        private DevComponents.DotNetBar.Controls.SideNavPanel sideNavPanel2;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private DevComponents.DotNetBar.Controls.SideNavItem sideNavItem1;
        private DevComponents.DotNetBar.Separator separator1;
        private DevComponents.DotNetBar.Controls.SideNavItem sideNavItem2;
        private DevComponents.DotNetBar.Controls.SideNavItem sideNavItem3;
        private DevComponents.DotNetBar.Controls.SideNavItem sideNavItem4;
        private System.Windows.Forms.Label label1;
    }
}

