using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Management;
using System.IO;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using System.Configuration;
using System.Security.Permissions;
using Microsoft.Win32;
using System.Xml;

[assembly: RegistryPermissionAttribute(SecurityAction.RequestMinimum,
    Read = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Microsoft Dynamics NAV\60\Service\W1 6.0")]
[assembly: SecurityPermissionAttribute(SecurityAction.RequestMinimum,
    UnmanagedCode = true)]

namespace NAV2009_NST_Management
{
    class NSTMgt
    {
        private string originalFolder;
        private string machineName;

        public NSTMgt()
        {
            machineName = Environment.MachineName;
            ReadOrigFolder();
        }

        public string MachineName
        {
            get
            {
                return machineName;
            }
            set
            {
                machineName = value;
                ReadOrigFolder();
            }

        }

        public string OriginalFolder
        {
            get
            {
                return originalFolder;
            }
            set
            {
                originalFolder = value;
            }
        }

        private void CreateNewService(string _name, string _start, string _path, string _type)
        {
            string serviceName;
            string serviceCaption;

            serviceName = "MicrosoftDynamicsNavServer$" + _name;
            serviceCaption = "Microsoft Dynamics NAV Server " + _name;
            string parameters = string.Format("\\\\{0} CREATE {1}  binpath= \"{2}Microsoft.Dynamics.Nav.Server.exe ${3}\"  DisplayName= \"{4}\"  type= {5}  start= {6}  obj= \"NT Authority\\NetworkService\" depend= NetTcpPortSharing", machineName, serviceName, _path, _name,
                serviceCaption,_type,_start);
            
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.EnableRaisingEvents=false;
            proc.StartInfo.FileName = "SC";
            proc.StartInfo.Arguments = parameters;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            proc.Start();
            proc.WaitForExit();
            int exitCode = proc.ExitCode;
            if (exitCode == 0)
            {
                MessageBox.Show(NAV2009_NST_Management.Properties.Resources.NSTCreated,"Result",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(string.Format(NAV2009_NST_Management.Properties.Resources.NSTFailed, exitCode), "Result", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateNewWS(string _name, string _start, string _path, string _type)
        {
            string serviceName;
            string serviceCaption;

            serviceName = "MicrosoftDynamicsNavWS$" + _name;
            serviceCaption = "Microsoft Dynamics NAV WS " + _name;
            string parameters = string.Format("\\\\{0} CREATE {1}  binpath= \"{2}Microsoft.Dynamics.Nav.Server.exe ${3}\"  DisplayName= \"{4}\"  type= {5}  start= {6}"+
            "obj= \"NT Authority\\NetworkService\" depend= HTTP/NetTcpPortSharing/MicrosoftDynamicsNavServer${7}", machineName, serviceName, _path, _name,
                serviceCaption, _type, _start,_name);

            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName = "SC";
            proc.StartInfo.Arguments = parameters;
            proc.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            proc.Start();
            proc.WaitForExit();
            int exitCode = proc.ExitCode;
            if (exitCode == 0)
            {
                MessageBox.Show(NAV2009_NST_Management.Properties.Resources.WSCreated, "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(string.Format(NAV2009_NST_Management.Properties.Resources.WSFailed,exitCode), "Result", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool Is64bitOS()
        {
            RegistryKey key;
            if ((Environment.MachineName != this.MachineName) && (this.MachineName != "."))
            {
                key = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, this.MachineName).OpenSubKey("SOFTWARE\\Wow6432Node");
                return key != null;
            }
            else
            {
                key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Wow6432Node");
                return key != null;
            }
        }

        private void ReadOrigFolder()
        {
            string keyName;
            if (Is64bitOS())
                keyName = "SOFTWARE\\Wow6432Node\\Microsoft\\Microsoft Dynamics NAV\\60\\Service\\W1 6.0";
            else
                keyName = "SOFTWARE\\Microsoft\\Microsoft Dynamics NAV\\60\\Service\\W1 6.0";
            string path;
            object pathValue;
            try
            {
                if ((Environment.MachineName != this.MachineName) && (this.MachineName != "."))
                    pathValue = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, this.MachineName).OpenSubKey(keyName).GetValue("Path");
                else
                    pathValue = Registry.LocalMachine.OpenSubKey(keyName).GetValue("Path");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, NAV2009_NST_Management.Properties.Resources.RedingOrigPath, MessageBoxButtons.OK, MessageBoxIcon.Error);
                pathValue = "";
            }
            if (pathValue == null)
            {
                MessageBox.Show(string.Format(NAV2009_NST_Management.Properties.Resources.CannotReadOrigPath,this.MachineName), 
                    NAV2009_NST_Management.Properties.Resources.RedingOrigPath, MessageBoxButtons.OK, MessageBoxIcon.Error);
                path = "";
            } else {
                path = pathValue.ToString();
                if (!Directory.Exists(TransformDir(path)))
                {
                    MessageBox.Show(string.Format(NAV2009_NST_Management.Properties.Resources.OrigPathNotFound,path),
                        NAV2009_NST_Management.Properties.Resources.RedingOrigPath, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            this.originalFolder = path;
        }

        static public void CopyFolder(string sourceFolder, string destFolder)
        {
            if (!Directory.Exists(destFolder))
                Directory.CreateDirectory(destFolder);

            string[] files = Directory.GetFiles(sourceFolder);
            foreach (string file in files)
            {
                string name = Path.GetFileName(file);
                string dest = Path.Combine(destFolder, name);
                File.Copy(file, dest);
            }
            string[] folders = Directory.GetDirectories(sourceFolder);
            foreach (string folder in folders)
            {
                string name = Path.GetFileName(folder);
                string dest = Path.Combine(destFolder, name);
                CopyFolder(folder, dest);
            }
        }

        static public void DeleteFolder(string sourceFolder)
        {
            if (!Directory.Exists(sourceFolder))
                return;

            Directory.Delete(sourceFolder, true);
        }

        private string TransformDir(string path)
        {
            if ((Environment.MachineName != this.MachineName) && (this.MachineName != "."))
            {
                return "\\\\" + this.MachineName + "\\" + path.Replace(':', '$');
            }
            return path;
        }

        private string CreateNewDir(string _suffix)
        {
            string newFolderName = this.originalFolder.TrimEnd('\\') + _suffix + "\\";
            string newFolderNameLocal = newFolderName;
            string oldFolder = this.OriginalFolder;

            /* if remote service, transform the path to admin share */
            newFolderName = TransformDir(newFolderName);
            oldFolder = TransformDir(oldFolder);

            if (Directory.Exists(newFolderName))
            {
                return newFolderNameLocal;
            }
            else
            {
                Directory.CreateDirectory(newFolderName);
                CopyFolder(oldFolder, newFolderName);
                return newFolderNameLocal;
            }
        }

        public void Create()
        {
            InstanceData instanceData = new InstanceData();
            if (instanceData.ShowDialog(null) == System.Windows.Forms.DialogResult.OK)
            {
                string name = instanceData.ServiceName;
                string caption = name;
                string type = instanceData.StartType;
                string start = instanceData.StartType;
                string db = instanceData.DBName;
                string server = instanceData.ServerName;
                string path = CreateNewDir(name);
                string serviceType;

                if (instanceData.CreateNST && instanceData.CreateWS)
                {
                    serviceType = "share";
                }
                else
                {
                    serviceType = "own";
                }

                if (instanceData.CreateNST)
                {
                    
                    CreateNewService(name, start, path, serviceType);
                    NAVService serviceItem = new NAVService("MicrosoftDynamicsNavServer$" + name,machineName);

                    //serviceItem.GetDetails();
                    serviceItem.DB = db;
                    serviceItem.Server = server;
                    serviceItem.UpdateConfig();
                    
                }
                if (instanceData.CreateWS)
                {
                    
                    CreateNewWS(name, start, path, serviceType);
                    if (!instanceData.CreateNST)
                    {
                        NAVService serviceItem = new NAVService("MicrosoftDynamicsNAVWS$" + name,machineName);
                        serviceItem.DB = db;
                        serviceItem.Server = server;
                        serviceItem.UpdateConfig();
                    }
                }
            }
        }
    }
}
