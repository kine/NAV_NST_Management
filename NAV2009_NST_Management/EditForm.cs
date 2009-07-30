using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace NAV2009_NST_Management
{
    public partial class EditForm : Form
    {
        NAVService service;

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
            String conxString = string.Format("Data Source={0}; Integrated Security=True;",serverBox.Text);

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

        public EditForm(NAVService _service):this()
        {
            service = _service;
            ServerName = service.Server;
            DBName = service.DB;
            Debug = service.Debug;
            nameBox.Text = _service.ServiceName.Substring(_service.ServiceName.LastIndexOf('$')+1);
        }

        public EditForm()
        {
            InitializeComponent();
        }

        public string ServerName
        {
            get
            {
                return this.serverBox.Text;
            }
            set
            {
                this.serverBox.Text = value;
            }
        }
        public string DBName
        {
            get
            {
                return this.dbBox.Text;
            }
            set
            {
                this.dbBox.Text = value;
            }
        }

        public bool Debug
        {
            get
            {
                return this.debugCheck.Checked;
            }
            set
            {
                this.debugCheck.Checked = value;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            service.DB = DBName;
            service.Server = ServerName;
            service.Debug = debugCheck.Checked;
            service.UpdateConfig();
        }

        private void serverBox_DropDown(object sender, EventArgs e)
        {
            if (serverBox.Items.Count ==0)
                GetServers();
        }

        private void dbBox_DropDown(object sender, EventArgs e)
        {
            if (dbBox.Items.Count == 0)
                GetDBs();
        }

        private void serverBox_Validated(object sender, EventArgs e)
        {
            dbBox.Items.Clear();
        }
    }
}
