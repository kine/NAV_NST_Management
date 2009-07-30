using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.ServiceProcess;
using System.Windows.Forms;
using System.IO;

namespace NAV2009_NST_Management
{
    public partial class Form1 : Form
    {
        NSTMgt nstMgt;
        NAVService[] services=NAVService.GetServices();

        public Form1()
        {
            InitializeComponent();
            nstMgt = new NSTMgt();
            serviceList.DataSource = services;
            serviceList.DisplayMember = "ServiceName";
            machineComboBox.Text = Environment.MachineName;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            nstMgt.Create();
            System.Threading.Thread.Sleep(1000);
            RefreshList();
        }

        private void toolStop_Click(object sender, EventArgs e)
        {
            NAVService serviceItem = (NAVService)serviceList.SelectedItem;
            try
            {
                if (serviceItem.CanStop)
                {
                    serviceItem.Stop();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Result", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStart_Click(object sender, EventArgs e)
        {
            NAVService serviceItem = (NAVService)serviceList.SelectedItem;
            try
            {
                serviceItem.Start();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Result", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void serviceList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((serviceList.SelectedIndex < 0) || (serviceList.SelectedIndex>=serviceList.Items.Count))
                return;

            NAVService serviceItem = (NAVService)serviceList.SelectedItem;
            if (serviceItem != null)
            {
                serviceItem.Refresh();
                statusBox.Text = serviceItem.Status.ToString();
                dbBox.Text = serviceItem.DB;
                serverBox.Text = serviceItem.Server;
            }
            else
            {
                statusBox.Text = "";
            }
        }

        private void toolDelete_Click(object sender, EventArgs e)
        {
            NAVService serviceItem = (NAVService)serviceList.SelectedItem;
            try
            {
                serviceItem.Delete();
                System.Threading.Thread.Sleep(1000);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Result", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            RefreshList();
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void RefreshList()
        {
            try
            {
                serviceList.BeginUpdate();
                if (machineComboBox.Text != "")
                    services = NAVService.GetServices(machineComboBox.Text);
                else
                    services = NAVService.GetServices();
                serviceList.DataSource = null;
                serviceList.DataSource = services;
                serviceList.DisplayMember = "ServiceName";
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Result", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                serviceList.EndUpdate();
            }
        }

        private void serviceList_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;
            NAVService serviceItem = (NAVService)serviceList.Items[e.Index];
            serviceItem.Refresh();
            System.Drawing.SolidBrush drawBrush;
            e.DrawBackground();
            try
            {
                if (serviceItem.Status == ServiceControllerStatus.Stopped)
                {
                    e.Graphics.DrawIcon(NAV2009_NST_Management.Properties.Resources.servicestopped1, e.Bounds.Location.X, e.Bounds.Location.Y);
                }
                else if (serviceItem.Status == ServiceControllerStatus.Running)
                {
                    e.Graphics.DrawIcon(NAV2009_NST_Management.Properties.Resources.servicerunning1, e.Bounds.Location.X, e.Bounds.Location.Y);
                }
                else if (serviceItem.Status == ServiceControllerStatus.Paused)
                {
                    e.Graphics.DrawIcon(NAV2009_NST_Management.Properties.Resources.servicepaused1, e.Bounds.Location.X, e.Bounds.Location.Y);
                }
                else
                    e.Graphics.DrawIcon(NAV2009_NST_Management.Properties.Resources.serviceunknown1, e.Bounds.Location.X, e.Bounds.Location.Y);

                if (serviceItem.ServiceName.Contains('$'))
                {
                    drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
                }
                else
                {
                    drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.LightGray);
                }

                if (serviceItem.Debug)
                {
                    e.Graphics.DrawString(serviceItem.DisplayName + " Debug", e.Font, drawBrush, e.Bounds.Location.X + NAV2009_NST_Management.Properties.Resources.servicepaused1.Width, e.Bounds.Location.Y + 2);
                }
                else
                {
                    e.Graphics.DrawString(serviceItem.DisplayName, e.Font, drawBrush, e.Bounds.Location.X + NAV2009_NST_Management.Properties.Resources.servicepaused1.Width, e.Bounds.Location.Y + 2);
                }
                e.DrawFocusRectangle();
            } catch
                {
                }
        }

        private void toolEdit_Click(object sender, EventArgs e)
        {
            NAVService serviceItem = (NAVService)serviceList.SelectedItem;
            if (!serviceItem.ServiceName.Contains('$'))
                return;
            EditForm editForm = new EditForm(serviceItem);
            editForm.ShowDialog(this);
            System.Threading.Thread.Sleep(1000);
            RefreshList();
        }

        private void machineComboBox_Click(object sender, EventArgs e)
        {

        }

        private void machineComboBox_Validated(object sender, EventArgs e)
        {
            try
            {
                nstMgt.MachineName = machineComboBox.Text;
                serviceList.SelectedIndex = 0;
                RefreshList();
            }
            catch (Exception exception)
            {
                nstMgt.MachineName = Environment.MachineName;
                machineComboBox.Text = nstMgt.MachineName;
                MessageBox.Show(exception.Message, "Result", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void aboutMenu_Click(object sender, EventArgs e)
        {
            MessageBox.Show(NAV2009_NST_Management.Properties.Resources.About, "About", MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(NAV2009_NST_Management.Properties.Resources.About, "About", MessageBoxButtons.OK, MessageBoxIcon.None);
        }

    }
}
