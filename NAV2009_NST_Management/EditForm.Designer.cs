namespace NAV2009_NST_Management
{
    partial class EditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditForm));
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.debugCheck = new System.Windows.Forms.CheckBox();
            this.serverBox = new System.Windows.Forms.ComboBox();
            this.dbBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Font = null;
            this.label1.Name = "label1";
            // 
            // button1
            // 
            this.button1.AccessibleDescription = null;
            this.button1.AccessibleName = null;
            resources.ApplyResources(this.button1, "button1");
            this.button1.BackgroundImage = null;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Font = null;
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.AccessibleDescription = null;
            this.button2.AccessibleName = null;
            resources.ApplyResources(this.button2, "button2");
            this.button2.BackgroundImage = null;
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Font = null;
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AccessibleDescription = null;
            this.label3.AccessibleName = null;
            resources.ApplyResources(this.label3, "label3");
            this.label3.Font = null;
            this.label3.Name = "label3";
            // 
            // label2
            // 
            this.label2.AccessibleDescription = null;
            this.label2.AccessibleName = null;
            resources.ApplyResources(this.label2, "label2");
            this.label2.Font = null;
            this.label2.Name = "label2";
            // 
            // nameBox
            // 
            this.nameBox.AccessibleDescription = null;
            this.nameBox.AccessibleName = null;
            resources.ApplyResources(this.nameBox, "nameBox");
            this.nameBox.BackgroundImage = null;
            this.nameBox.Font = null;
            this.nameBox.Name = "nameBox";
            this.nameBox.ReadOnly = true;
            // 
            // debugCheck
            // 
            this.debugCheck.AccessibleDescription = null;
            this.debugCheck.AccessibleName = null;
            resources.ApplyResources(this.debugCheck, "debugCheck");
            this.debugCheck.BackgroundImage = null;
            this.debugCheck.Font = null;
            this.debugCheck.Name = "debugCheck";
            this.debugCheck.UseVisualStyleBackColor = true;
            // 
            // serverBox
            // 
            this.serverBox.AccessibleDescription = null;
            this.serverBox.AccessibleName = null;
            resources.ApplyResources(this.serverBox, "serverBox");
            this.serverBox.BackgroundImage = null;
            this.serverBox.Font = null;
            this.serverBox.FormattingEnabled = true;
            this.serverBox.Name = "serverBox";
            this.serverBox.Validated += new System.EventHandler(this.serverBox_Validated);
            this.serverBox.DropDown += new System.EventHandler(this.serverBox_DropDown);
            // 
            // dbBox
            // 
            this.dbBox.AccessibleDescription = null;
            this.dbBox.AccessibleName = null;
            resources.ApplyResources(this.dbBox, "dbBox");
            this.dbBox.BackgroundImage = null;
            this.dbBox.Font = null;
            this.dbBox.FormattingEnabled = true;
            this.dbBox.Name = "dbBox";
            this.dbBox.DropDown += new System.EventHandler(this.dbBox_DropDown);
            // 
            // EditForm
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.dbBox);
            this.Controls.Add(this.serverBox);
            this.Controls.Add(this.debugCheck);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nameBox);
            this.Font = null;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = null;
            this.Name = "EditForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.CheckBox debugCheck;
        private System.Windows.Forms.ComboBox serverBox;
        private System.Windows.Forms.ComboBox dbBox;
    }
}