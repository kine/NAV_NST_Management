using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace NAV2009_NST_Management
{
    public partial class InstanceData : Form
    {
        NAVService service;

        public InstanceData()
        {
            InitializeComponent();
        }

        public InstanceData(NAVService _service):this()
        {
            service = _service;
            ServiceName = service.ServiceName;
        }

        public string ServiceName
        {
            get
            {
                return this.nameBox.Text;
            }

            set
            {
                this.nameBox.Text = value;
            }

        }
        public string ServerName
        {
            get
            {
                return this.serverBox.Text;
            }
        }
        public string DBName
        {
            get
            {
                return this.dbBox.Text;
            }
        }
        public string StartType
        {
            get
            {
                if (this.onDemandRadio.Checked) 
                {
                    return "demand";
                } 
                else if (this.autoRadio.Checked) 
                {
                    return "auto";
                }
                else if (this.disabledRadio.Checked)
                {
                    return "disabled";
                }
                return "";
            }
        }
        public bool CreateNST
        {
            get
            {
                return this.nstCheck.Checked;
            }
        }
        public bool CreateWS
        {
            get
            {
                return this.wsCheck.Checked;
            }
        }
        private void GetServers()
        {
            SqlDataSourceEnumerator servers = SqlDataSourceEnumerator.Instance;
            DataTable serversTable = servers.GetDataSources();

            foreach (DataRow row in serversTable.Rows)
            {
                string serverName = string.Format("{0}\\{1}", row[0], row[1]);
                char[] chars = { '\\' };
                serverName = serverName.TrimEnd(chars);
                serverBox.Items.Add(serverName);
                // Add this to your list
            }
        }

        private void GetDBs()
        {
            String conxString = string.Format("Data Source={0}; Integrated Security=True;", serverBox.Text);

            using (SqlConnection sqlConx = new SqlConnection(conxString))
            {
                try
                {
                    sqlConx.Open();
                    DataTable tblDatabases = sqlConx.GetSchema("Databases");
                    sqlConx.Close();

                    foreach (DataRow row in tblDatabases.Rows)
                    {
                        dbBox.Items.Add(row["database_name"]);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Result", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void serverBox_DropDown(object sender, EventArgs e)
        {
            if (serverBox.Items.Count == 0)
            {
                GetServers();
            }
        }

        private void serverBox_Validated(object sender, EventArgs e)
        {
            dbBox.Items.Clear();
        }

        private void dbBox_DropDown(object sender, EventArgs e)
        {
            if (dbBox.Items.Count == 0)
            {
                GetDBs();
            }
        }

    }
}
