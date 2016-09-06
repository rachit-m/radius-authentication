using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Xml;
using System.Net;
using System.Net.NetworkInformation;
using System.Security;
using System.Security.Cryptography.X509Certificates;

namespace PoziomLabs
{
    public class Netsh
    {
        string profile;
        public string ProfileAdd(string path)
        {
            string output="";

            XmlDocument doc = new XmlDocument(); // parsing the xml document to find the SSID of network
            doc.Load(path);

            XmlNodeList elemList = doc.GetElementsByTagName("name");
            profile = elemList[0].InnerXml;

            // adding the profile to the system

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.CreateNoWindow = true;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C " + "netsh wlan add profile filename=" + "\"" + path + "\"";
            process.StartInfo = startInfo;
            process.Start();
            output = output + process.StandardOutput.ReadToEnd();
            output = output + process.StandardError.ReadToEnd();
            return output;
        }

        public string ProfileDelete(string ssid)
        {
            string output = "";

            // deleting the profile from the system

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.CreateNoWindow = true;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C " + "netsh wlan delete profile name=" + "\"" + ssid + "\"";
            process.StartInfo = startInfo;
            process.Start();
            output = output + process.StandardOutput.ReadToEnd();
            output = output + process.StandardError.ReadToEnd();
            return output;
        }

        public string Connect()
        {
            string output = "";
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.CreateNoWindow = true;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C " + "netsh wlan connect name=" + "\"" + profile + "\"";
            process.StartInfo = startInfo;
            process.Start();
            output = output + process.StandardOutput.ReadToEnd();
            output = output + process.StandardError.ReadToEnd();
            return output;
        }

        public string Connect(string ssid)
        {
            string output = "";
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.CreateNoWindow = true;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C " + "netsh wlan connect name=" + "\"" + ssid + "\"";
            process.StartInfo = startInfo;
            process.Start();
            output = output + process.StandardOutput.ReadToEnd();
            output = output + process.StandardError.ReadToEnd();
            return output;
        }

        public string Disconnect()
        {
            string output = "";
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.CreateNoWindow = true;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C " + "netsh wlan disconnect";
            process.StartInfo = startInfo;
            process.Start();
            output = output + process.StandardOutput.ReadToEnd();
            output = output + process.StandardError.ReadToEnd();
            return output;
        }

        public List<string> SavedProfileList()
        {
            List <string> profiles = new List<string>();
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
            while (test.Length > 5)
            {
                start = test.IndexOf(": ") + 2;
                test2 = test.Substring(start + 2);
                end = test2.IndexOf('\r');
                profiles.Add(test.Substring(start, end + 2));
                test = test.Substring(start + end + 2);

            }
            return profiles;
        }

        public string GetProfilePassword(string ssid)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.CreateNoWindow = true;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C " + "netsh wlan show profile name=\"" + ssid + "\" key=\"clear\"";
            process.StartInfo = startInfo;
            process.Start();
            string pass = process.StandardOutput.ReadToEnd();
            pass = pass.Substring(pass.IndexOf("Key Content"));
            pass = pass.Substring(pass.IndexOf(": ") + 2, pass.IndexOf('\r') - (pass.IndexOf(": ") + 2));
            return pass;
        }

        public string GetBSSID(string ssid)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.CreateNoWindow = true;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C " + "netsh wlan show networks mode=\"bssid\"";
            process.StartInfo = startInfo;
            process.Start();
            string bssid = process.StandardOutput.ReadToEnd();
            if (bssid.IndexOf(ssid) != -1)
            {
                bssid = bssid.Substring(bssid.IndexOf(ssid));
                bssid = bssid.Substring(bssid.IndexOf("BSSID"));
                bssid = bssid.Substring(bssid.IndexOf(": ") + 2, bssid.IndexOf('\r') - (bssid.IndexOf(": ") + 2));
                return bssid;
            }
            else
                return "N/A";
        }

    }
    public class Net_Stats
    {
        public int DownloadedKB()
        {
            int down = 0;
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
                int a = interfaces.Length, i;
                for (i = 0; i < interfaces.Length; i++)
                {
                    NetworkInterface nic = interfaces[i];
                    if (interfaces[i].OperationalStatus == OperationalStatus.Up && nic.GetIPv4Statistics().BytesReceived / 1024 > 20)
                    {
                        IPv4InterfaceStatistics netstats = nic.GetIPv4Statistics();
                        down = Convert.ToInt32(netstats.BytesReceived / 1024);
                        break;    
                    }
                }
            }
            return down;
        }

        public int UploadedKB()
        {
            int up = 0;
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
                int a = interfaces.Length, i;
                for (i = 0; i < interfaces.Length; i++)
                {
                    NetworkInterface nic = interfaces[i];
                    if (interfaces[i].OperationalStatus == OperationalStatus.Up && nic.GetIPv4Statistics().BytesReceived / 1024 > 20)
                    {
                        IPv4InterfaceStatistics netstats = nic.GetIPv4Statistics();
                        up = Convert.ToInt32(netstats.BytesSent / 1024);
                        break;
                    }
                }
            }
            return up;
        }

        public int DownloadedMB()
        {
            int down = 0;
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
                int a = interfaces.Length, i;
                for (i = 0; i < interfaces.Length; i++)
                {
                    NetworkInterface nic = interfaces[i];
                    if (interfaces[i].OperationalStatus == OperationalStatus.Up && nic.GetIPv4Statistics().BytesReceived / 1024 > 20)
                    {
                        IPv4InterfaceStatistics netstats = nic.GetIPv4Statistics();
                        down = Convert.ToInt32((netstats.BytesReceived / 1024) / 1024);
                        break;
                    }
                }
            }
            return down;
        }

        public int UploadedMB()
        {
            int up = 0;
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
                int a = interfaces.Length, i;
                for (i = 0; i < interfaces.Length; i++)
                {
                    NetworkInterface nic = interfaces[i];
                    if (interfaces[i].OperationalStatus == OperationalStatus.Up && nic.GetIPv4Statistics().BytesReceived / 1024 > 20)
                    {
                        IPv4InterfaceStatistics netstats = nic.GetIPv4Statistics();
                        up = Convert.ToInt32((netstats.BytesSent / 1024) / 1024);
                        break;
                    }
                }
            }
            return up;
        }


    }

    public class Cert
    {

        public void Add_p12(string p12_path, string password)
        {
            X509Certificate2 certificate = new X509Certificate2(p12_path, password);
            var store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadWrite);
            store.Add(certificate);
            store.Close();

            var store2 = new X509Store(StoreName.Root, StoreLocation.CurrentUser);
            store2.Open(OpenFlags.ReadWrite);
            store2.Add(certificate);
            store2.Close();
        }

        public void Add_der(string der_path)
        {
            X509Certificate2 certificate = new X509Certificate2(der_path);
            var store = new X509Store(StoreName.Root, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadWrite);
            store.Add(certificate);
            store.Close();

            var store2 = new X509Store(StoreName.CertificateAuthority, StoreLocation.CurrentUser);
            store2.Open(OpenFlags.ReadWrite);
            store2.Add(certificate);
            store2.Close();
        }

    }

    public class XmlProfile
    {
        public void Generate(string ssid, string password, string auth_type, string path)
        {
            switch (auth_type)
            {
                case "WPA2PSK":
                    {
                        byte[] ba = Encoding.Default.GetBytes(ssid);
                        var hexString = BitConverter.ToString(ba);
                        hexString = hexString.Replace("-", "");

                        XmlDocument xmlDoc = new XmlDocument();

                        XmlDeclaration xmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0", null, null);
                        XmlElement root = xmlDoc.DocumentElement;
                        xmlDoc.InsertBefore(xmlDeclaration, root);

                        XmlElement WLANProfile = xmlDoc.CreateElement("WLANProfile");
                        XmlAttribute attribute = xmlDoc.CreateAttribute("xmlns");
                        attribute.Value = "http://www.microsoft.com/networking/WLAN/profile/v1";
                        WLANProfile.Attributes.Append(attribute);
                        xmlDoc.AppendChild(WLANProfile);

                        XmlElement name = xmlDoc.CreateElement("name");
                        XmlText text = xmlDoc.CreateTextNode(ssid);
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
                        XmlText text3 = xmlDoc.CreateTextNode(ssid);
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
                        XmlText text11 = xmlDoc.CreateTextNode(password);
                        keyMaterial.AppendChild(text11);
                        sharedKey.AppendChild(keyMaterial);

                        xmlDoc.Save(path);

                        break;
                    }
                case "WPA2":
                    {


                        break;
                    }
            }
        }
    }

    public class PostRequest
    {
        public string otp_api(string user_contact)
        {
            using (var client = new WebClient())
            {
                var responseString = client.DownloadString("http://52.27.54.85/rad_app/otp_api.php/" + user_contact);
                return responseString;
            }
        }

        public string reg_api(string user_contact, string user_password, string user_otp)
        {
            using (var client = new WebClient())
            {
                var values = new NameValueCollection();
                values["user_contact"] = user_contact;
                values["user_password"] = user_password;
                values["user_otp"] = user_otp;

                var response = client.UploadValues("http://52.27.54.85/rad_app/reg_api.php", values);

                var responseString = Encoding.Default.GetString(response);
                return responseString;
            }
        }

        public string wifi_info_api(string user_contact, string ssid, string bssid, string password)
        {
            using (var client = new WebClient())
            {
                var values = new NameValueCollection();
                values["user_contact"] = user_contact;
                values["ssid"] = ssid;
                values["bssid"] = bssid;
                values["password"] = password;

                var response = client.UploadValues("http://52.27.54.85/rad_app/wifi_info_api.php", values);

                var responseString = Encoding.Default.GetString(response);
                return responseString;
            }
        }

        public string check_users_api(string contact)
        {
            using (var client = new WebClient())
            {
                var values = new NameValueCollection();
                values["contact"] = contact;

                var response = client.UploadValues("http://52.27.54.85/rad_app/check_users_api.php", values);

                var responseString = Encoding.Default.GetString(response);
                return responseString;
            }
        }

        public string request_api(string user_os, string req_id, string contact)
        {
            using (var client = new WebClient())
            {
                var values = new NameValueCollection();
                values["user_os"] = user_os;
                values["req_id"] = req_id;
                values["contact"] = contact;

                var response = client.UploadValues("http://52.27.54.85/rad_app/request_api.php", values);

                var responseString = Encoding.Default.GetString(response);
                return responseString;
            }
        }
    }
}
