using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace XML_generator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = @"C:\";
            saveFileDialog1.Title = "Save XML File";
            saveFileDialog1.DefaultExt = "xml";
            saveFileDialog1.Filter = "XML files (*.xml)|*.xml";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = saveFileDialog1.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            byte[] ba = Encoding.Default.GetBytes(textBox1.Text);
            var hexString = BitConverter.ToString(ba);
            hexString = hexString.Replace("-", "");

            XmlDocument xmlDoc = new XmlDocument();

            XmlDeclaration xmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0",null,null);
            XmlElement root = xmlDoc.DocumentElement;
            xmlDoc.InsertBefore(xmlDeclaration, root);

            XmlElement WLANProfile = xmlDoc.CreateElement("WLANProfile");
            XmlAttribute attribute = xmlDoc.CreateAttribute("xmlns");
            attribute.Value = "http://www.microsoft.com/networking/WLAN/profile/v1";
            WLANProfile.Attributes.Append(attribute);
            xmlDoc.AppendChild(WLANProfile);

            XmlElement name = xmlDoc.CreateElement("name");
            XmlText text = xmlDoc.CreateTextNode(textBox1.Text);
            name.AppendChild(text);
            WLANProfile.AppendChild(name);

            XmlElement SSIDConfig = xmlDoc.CreateElement("SSIDConfig");
            WLANProfile.AppendChild(SSIDConfig);

            XmlElement SSID = xmlDoc.CreateElement("SSID");
            SSIDConfig.AppendChild(SSID);

            XmlElement hex = xmlDoc.CreateElement("hex");
            XmlText text2 = xmlDoc.CreateTextNode(hexString);
            hex.AppendChild(text2);
            SSID.AppendChild(hex);

            XmlElement name1 = xmlDoc.CreateElement("name");
            XmlText text3 = xmlDoc.CreateTextNode(textBox1.Text);
            name1.AppendChild(text3);
            SSID.AppendChild(name1);

            XmlElement connectionType = xmlDoc.CreateElement("connectionType");
            XmlText text4 = xmlDoc.CreateTextNode("ESS");
            connectionType.AppendChild(text4);
            WLANProfile.AppendChild(connectionType);

            XmlElement connectionMode = xmlDoc.CreateElement("connectionMode");
            XmlText text5 = xmlDoc.CreateTextNode("auto");
            connectionMode.AppendChild(text5);
            WLANProfile.AppendChild(connectionMode);

            XmlElement MSM = xmlDoc.CreateElement("MSM");
            WLANProfile.AppendChild(MSM);

            XmlElement security = xmlDoc.CreateElement("security");
            MSM.AppendChild(security);

            XmlElement authEncryption = xmlDoc.CreateElement("authEncryption");
            security.AppendChild(authEncryption);

            XmlElement authentication = xmlDoc.CreateElement("authentication");
            XmlText text6 = xmlDoc.CreateTextNode("WPA2PSK");
            authentication.AppendChild(text6);
            authEncryption.AppendChild(authentication);

            XmlElement encryption = xmlDoc.CreateElement("encryption");
            XmlText text7 = xmlDoc.CreateTextNode("AES");
            encryption.AppendChild(text7);
            authEncryption.AppendChild(encryption);

            XmlElement useOneX = xmlDoc.CreateElement("useOneX");
            XmlText text8 = xmlDoc.CreateTextNode("false");
            useOneX.AppendChild(text8);
            authEncryption.AppendChild(useOneX);

            XmlElement sharedKey = xmlDoc.CreateElement("sharedKey");
            security.AppendChild(sharedKey);

            XmlElement keyType = xmlDoc.CreateElement("keyType");
            XmlText text9 = xmlDoc.CreateTextNode("passPhrase");
            keyType.AppendChild(text9);
            sharedKey.AppendChild(keyType);

            XmlElement protected1 = xmlDoc.CreateElement("protected");
            XmlText text10 = xmlDoc.CreateTextNode("false");
            protected1.AppendChild(text10);
            sharedKey.AppendChild(protected1);

            XmlElement keyMaterial = xmlDoc.CreateElement("keyMaterial");
            XmlText text11 = xmlDoc.CreateTextNode(textBox2.Text);
            keyMaterial.AppendChild(text11);
            sharedKey.AppendChild(keyMaterial);

            xmlDoc.Save(textBox3.Text);

        }
    }
}
