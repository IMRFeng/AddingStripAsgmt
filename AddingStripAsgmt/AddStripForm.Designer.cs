namespace AddingStripAsgmt
{
    partial class AddStripForm
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
            this.lstDisplay = new System.Windows.Forms.ListBox();
            this.lblCaculations = new System.Windows.Forms.Label();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNew = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.lblChange = new System.Windows.Forms.Label();
            this.lblBackground = new System.Windows.Forms.Label();
            this.txtChangeValue = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.openOptDlg = new System.Windows.Forms.OpenFileDialog();
            this.saveOptDlg = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstDisplay
            // 
            this.lstDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstDisplay.FormattingEnabled = true;
            this.lstDisplay.ItemHeight = 29;
            this.lstDisplay.Location = new System.Drawing.Point(53, 41);
            this.lstDisplay.Name = "lstDisplay";
            this.lstDisplay.ScrollAlwaysVisible = true;
            this.lstDisplay.Size = new System.Drawing.Size(232, 323);
            this.lstDisplay.TabIndex = 1;
            this.lstDisplay.Click += new System.EventHandler(this.lstDisplay_Click);
            // 
            // lblCaculations
            // 
            this.lblCaculations.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaculations.Location = new System.Drawing.Point(326, 41);
            this.lblCaculations.Name = "lblCaculations";
            this.lblCaculations.Size = new System.Drawing.Size(292, 65);
            this.lblCaculations.TabIndex = 2;
            this.lblCaculations.Text = "Enter your calcluations in the text box below";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(666, 40);
            this.menuStrip.TabIndex = 3;
            this.menuStrip.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNew,
            this.mnuOpen,
            this.mnuSave,
            this.mnuSaveAs,
            this.toolStripSeparator1,
            this.mnuPrint,
            this.toolStripSeparator2,
            this.mnuExit});
            this.mnuFile.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(64, 36);
            this.mnuFile.Text = "File";
            // 
            // mnuNew
            // 
            this.mnuNew.Name = "mnuNew";
            this.mnuNew.Size = new System.Drawing.Size(184, 36);
            this.mnuNew.Text = "New";
            this.mnuNew.Click += new System.EventHandler(this.mnuNew_Click);
            // 
            // mnuOpen
            // 
            this.mnuOpen.Name = "mnuOpen";
            this.mnuOpen.Size = new System.Drawing.Size(184, 36);
            this.mnuOpen.Text = "Open...";
            this.mnuOpen.Click += new System.EventHandler(this.mnuOpen_Click);
            // 
            // mnuSave
            // 
            this.mnuSave.Name = "mnuSave";
            this.mnuSave.Size = new System.Drawing.Size(184, 36);
            this.mnuSave.Text = "Save...";
            this.mnuSave.Click += new System.EventHandler(this.mnuSave_Click);
            // 
            // mnuSaveAs
            // 
            this.mnuSaveAs.Name = "mnuSaveAs";
            this.mnuSaveAs.Size = new System.Drawing.Size(184, 36);
            this.mnuSaveAs.Text = "Save as...";
            this.mnuSaveAs.Click += new System.EventHandler(this.mnuSaveAs_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(181, 6);
            // 
            // mnuPrint
            // 
            this.mnuPrint.Name = "mnuPrint";
            this.mnuPrint.Size = new System.Drawing.Size(184, 36);
            this.mnuPrint.Text = "Print";
            this.mnuPrint.Click += new System.EventHandler(this.mnuPrint_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(181, 6);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(184, 36);
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // txtValue
            // 
            this.txtValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValue.Location = new System.Drawing.Point(331, 110);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(221, 35);
            this.txtValue.TabIndex = 4;
            this.txtValue.TextChanged += new System.EventHandler(this.txtValue_TextChanged);
            this.txtValue.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtValue_KeyUp);
            // 
            // lblChange
            // 
            this.lblChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChange.Location = new System.Drawing.Point(326, 188);
            this.lblChange.Name = "lblChange";
            this.lblChange.Size = new System.Drawing.Size(301, 64);
            this.lblChange.TabIndex = 5;
            this.lblChange.Text = "To make changes select a line in the list first";
            // 
            // lblBackground
            // 
            this.lblBackground.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lblBackground.Location = new System.Drawing.Point(327, 262);
            this.lblBackground.Name = "lblBackground";
            this.lblBackground.Size = new System.Drawing.Size(291, 123);
            this.lblBackground.TabIndex = 6;
            // 
            // txtChangeValue
            // 
            this.txtChangeValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChangeValue.Location = new System.Drawing.Point(356, 278);
            this.txtChangeValue.Name = "txtChangeValue";
            this.txtChangeValue.Size = new System.Drawing.Size(221, 35);
            this.txtChangeValue.TabIndex = 7;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(342, 332);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(85, 43);
            this.btnUpdate.TabIndex = 8;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(524, 332);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(85, 43);
            this.btnInsert.TabIndex = 9;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(433, 332);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(85, 43);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // openOptDlg
            // 
            this.openOptDlg.Filter = "(*.cal)|*.cal";
            this.openOptDlg.InitialDirectory = "C:\\temp";
            // 
            // saveOptDlg
            // 
            this.saveOptDlg.FileName = "Calculation1";
            this.saveOptDlg.Filter = "(*.cal)|*.cal";
            this.saveOptDlg.InitialDirectory = "C:\\temp";
            // 
            // AddStripForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 451);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txtChangeValue);
            this.Controls.Add(this.lblBackground);
            this.Controls.Add(this.lblChange);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.lblCaculations);
            this.Controls.Add(this.lstDisplay);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "AddStripForm";
            this.Text = "AddStrip";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddStripForm_FormClosing);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstDisplay;
        private System.Windows.Forms.Label lblCaculations;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuNew;
        private System.Windows.Forms.ToolStripMenuItem mnuOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuSave;
        private System.Windows.Forms.ToolStripMenuItem mnuSaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuPrint;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Label lblChange;
        private System.Windows.Forms.Label lblBackground;
        private System.Windows.Forms.TextBox txtChangeValue;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.OpenFileDialog openOptDlg;
        private System.Windows.Forms.SaveFileDialog saveOptDlg;
    }
}

