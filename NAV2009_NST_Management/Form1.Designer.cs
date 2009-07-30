namespace NAV2009_NST_Management
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.serviceList = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.serverBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dbBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.statusBox = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolCreate = new System.Windows.Forms.ToolStripButton();
            this.toolDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStop = new System.Windows.Forms.ToolStripButton();
            this.toolStart = new System.Windows.Forms.ToolStripButton();
            this.toolEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.machineComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.serviceList);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.toolStrip1);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // serviceList
            // 
            resources.ApplyResources(this.serviceList, "serviceList");
            this.serviceList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.serviceList.FormattingEnabled = true;
            this.serviceList.Name = "serviceList";
            this.serviceList.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.serviceList_DrawItem);
            this.serviceList.SelectedIndexChanged += new System.EventHandler(this.serviceList_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.serverBox);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.dbBox);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.statusBox);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // serverBox
            // 
            resources.ApplyResources(this.serverBox, "serverBox");
            this.serverBox.Name = "serverBox";
            this.serverBox.ReadOnly = true;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // dbBox
            // 
            resources.ApplyResources(this.dbBox, "dbBox");
            this.dbBox.Name = "dbBox";
            this.dbBox.ReadOnly = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // statusBox
            // 
            resources.ApplyResources(this.statusBox, "statusBox");
            this.statusBox.Name = "statusBox";
            this.statusBox.ReadOnly = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolCreate,
            this.toolDelete,
            this.toolStop,
            this.toolStart,
            this.toolEdit,
            this.toolStripButton1,
            this.machineComboBox,
            this.toolStripButton2});
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Name = "toolStrip1";
            // 
            // toolCreate
            // 
            this.toolCreate.Image = global::NAV2009_NST_Management.Properties.Resources.document1;
            resources.ApplyResources(this.toolCreate, "toolCreate");
            this.toolCreate.Name = "toolCreate";
            this.toolCreate.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolDelete
            // 
            this.toolDelete.Image = global::NAV2009_NST_Management.Properties.Resources.delete1;
            resources.ApplyResources(this.toolDelete, "toolDelete");
            this.toolDelete.Name = "toolDelete";
            this.toolDelete.Click += new System.EventHandler(this.toolDelete_Click);
            // 
            // toolStop
            // 
            this.toolStop.Image = global::NAV2009_NST_Management.Properties.Resources.Stop1;
            resources.ApplyResources(this.toolStop, "toolStop");
            this.toolStop.Name = "toolStop";
            this.toolStop.Click += new System.EventHandler(this.toolStop_Click);
            // 
            // toolStart
            // 
            this.toolStart.Image = global::NAV2009_NST_Management.Properties.Resources.Run1;
            resources.ApplyResources(this.toolStart, "toolStart");
            this.toolStart.Name = "toolStart";
            this.toolStart.Click += new System.EventHandler(this.toolStart_Click);
            // 
            // toolEdit
            // 
            this.toolEdit.Image = global::NAV2009_NST_Management.Properties.Resources.gear_11;
            resources.ApplyResources(this.toolEdit, "toolEdit");
            this.toolEdit.Name = "toolEdit";
            this.toolEdit.Click += new System.EventHandler(this.toolEdit_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::NAV2009_NST_Management.Properties.Resources.RefreshDocViewHS1;
            resources.ApplyResources(this.toolStripButton1, "toolStripButton1");
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click_1);
            // 
            // machineComboBox
            // 
            this.machineComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.machineComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            this.machineComboBox.Name = "machineComboBox";
            resources.ApplyResources(this.machineComboBox, "machineComboBox");
            this.machineComboBox.Click += new System.EventHandler(this.machineComboBox_Click);
            this.machineComboBox.Validated += new System.EventHandler(this.machineComboBox_Validated);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::NAV2009_NST_Management.Properties.Resources.Help;
            resources.ApplyResources(this.toolStripButton2, "toolStripButton2");
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolCreate;
        private System.Windows.Forms.ToolStripButton toolDelete;
        private System.Windows.Forms.ToolStripButton toolStop;
        private System.Windows.Forms.ToolStripButton toolStart;
        private System.Windows.Forms.ToolStripButton toolEdit;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox statusBox;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ListBox serviceList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox serverBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox dbBox;
        private System.Windows.Forms.ToolStripComboBox machineComboBox;
        private System.Windows.Forms.ToolStripButton toolStripButton2;

    }
}

