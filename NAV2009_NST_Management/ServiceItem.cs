using System;
using System.Collections.Generic;
using System.Collections;
using System.ServiceProcess;
using System.Text;
using System.Management;
using System.IO;
using System.Xml;
using Microsoft.Win32;

namespace NAV2009_NST_Management
{
    public class NAVService : ServiceController
    {
        private string db;
        private string server;
        private bool debug;
    
        public NAVService(ServiceController service)
        {
            this.ServiceName = service.ServiceName;
            this.MachineName = service.MachineName;
            this.ReadConfig();
        }

        public NAVService(string serviceName, string machineName)
        {
            this.ServiceName = serviceName;
            this.MachineName = machineName;
            this.Refresh();
            this.ReadConfig();
        }

        public bool Debug
        {
            get
            {
                return this.debug;
            }
            set
            {
                this.debug = value;
            }
        }

        public string DB
        {
            get
            {
                return db;
            }
            set
            {
                db = value;
            }
        }

        public string Server
        {
            get
            {
                return server;
            }
            set
            {
                server = value;
            }
        }

        public new static NAVService[] GetServices()
        {
            ArrayList serviceList = new ArrayList();
            ServiceController[] services = ServiceController.GetServices();
            foreach (ServiceController service in services)
            {
                if (service.ServiceName.ToUpper().Contains("MICROSOFTDYNAMICSNAV"))
                {
                    serviceList.Add(service);
                }
            }
            NAVService[] result = new NAVService[serviceList.Count];
            int i = 0;
            foreach (object service in serviceList)
            {
                result[i] = new NAVService((ServiceController)service);
                i++;
            }
            return (result);
        }

        public new static NAVService[] GetServices(string machineName)
        {
            ArrayList serviceList = new ArrayList();
            ServiceController[] services = ServiceController.GetServices(machineName);
            foreach (ServiceController service in services)
            {
                if (service.ServiceName.ToUpper().Contains("MICROSOFTDYNAMICSNAV"))
                {
                    serviceList.Add(service);
                }
            }
            NAVService[] result = new NAVService[serviceList.Count];
            int i = 0;
            foreach (object service in serviceList)
            {
                result[i] = new NAVService((ServiceController)service);
                i++;
            }
            return (result);
        }


        public int Delete()
        {
            if (!this.ServiceName.Contains("$"))
                return -1;

            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            string parameters = string.Format("\\\\{0} delete {1}",this.MachineName,this.ServiceName);
            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName = "SC";
            proc.StartInfo.Arguments = parameters;
            proc.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            proc.Start();
            proc.WaitForExit();
            return (proc.ExitCode);
        }

        public string GetImagePath()
        {
            string keyName = "SYSTEM\\CurrentControlSet\\Services\\"+this.ServiceName;
            string path;
            if ((Environment.MachineName != this.MachineName) && (this.MachineName!="."))
                path = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, this.MachineName).OpenSubKey(keyName).GetValue("ImagePath").ToString();
            else
                path = Registry.LocalMachine.OpenSubKey(keyName).GetValue("ImagePath").ToString();
            path = path.Trim('"');
            return(path);
        }

        public void UpdateConfig()
        {
            XmlDocument xmlDoc = new XmlDocument();
            string path = Path.GetDirectoryName(GetImagePath());

            /* if remote service, transform the path to admin share */
            if (this.MachineName != ".")
            {
                path = "\\\\"+this.MachineName+"\\"+path.Replace(':', '$');
            }

            xmlDoc.Load(path + "\\CustomSettings.config");
            XmlNode key;
            XmlNode root = xmlDoc.DocumentElement;

            key = root.SelectSingleNode("/appSettings/add[@key=\"DatabaseServer\"]/@value");
            key.Value = this.server;

            key = root.SelectSingleNode("/appSettings/add[@key=\"DatabaseName\"]/@value");
            key.Value = this.db;

            key = root.SelectSingleNode("/appSettings/add[@key=\"ServerInstance\"]/@value");
            key.Value = this.ServiceName.Substring(this.ServiceName.LastIndexOf('$')+1);

            key = root.SelectSingleNode("/appSettings/add[@key=\"EnableDebugging\"]/@value");
            key.Value = this.debug.ToString();

            xmlDoc.Save(path + "\\CustomSettings.config");
        }


        public void SetDebugMode(bool enabled)
        {
            XmlDocument xmlDoc = new XmlDocument();
            string path = Path.GetDirectoryName(GetImagePath());
            /* if remote service, transform the path to admin share */
            if (this.MachineName != ".")
            {
                path = "\\\\" + this.MachineName + "\\" + path.Replace(':', '$');
            }
            xmlDoc.Load(path + "\\CustomSettings.config");
            XmlNode key;
            XmlNode root = xmlDoc.DocumentElement;

            key = root.SelectSingleNode("/appSettings/add[@key=\"EnableDebugging\"]/@value");
            if (key == null)
            {
                /*
                XmlElement addElement=new XmlElement();
                addElement.Name = "Add";
                addElement.NodeType = XmlNodeType.Element;
                addElement.SetAttribute("key", "EnableDebugging");
                addElement.SetAttribute("value", enabled.ToString());

                key = root.LastChild.AppendChild(addElement);
                //key.
                //root.A
                 */
            }
            else
            {
                key.Value = enabled.ToString();
            }

            xmlDoc.Save(path + "\\CustomSettings.config");
        }

        public void ReadConfig()
        {
            XmlDocument xmlDoc = new XmlDocument();
            string path = GetImagePath();
            path = Path.GetDirectoryName(path);
            try
            {
                /* if remote service, transform the path to admin share */
                if (this.MachineName != ".")
                {
                    path = "\\\\" + this.MachineName + "\\" + path.Replace(':', '$');
                }
                xmlDoc.Load(path + "\\CustomSettings.config");
                XmlNode key;
                XmlNode root = xmlDoc.DocumentElement;

                key = root.SelectSingleNode("/appSettings/add[@key=\"DatabaseServer\"]/@value");
                this.server = key.Value;

                key = root.SelectSingleNode("/appSettings/add[@key=\"DatabaseName\"]/@value");
                this.db = key.Value;

                key = root.SelectSingleNode("/appSettings/add[@key=\"EnableDebugging\"]/@value");
                this.debug = (key.Value.ToLower() == "true" ? true : false);
            }
            catch (Exception e)
            {
            }

        }
   }
}
