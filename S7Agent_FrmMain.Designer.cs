
namespace S7Agent
{
    partial class S7Agent_FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.S7Agent_MainMenu = new System.Windows.Forms.MenuStrip();
            this.S7Agent_MainMenu_FileItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnConnect = new System.Windows.Forms.Button();
            this.IOAddress = new System.Windows.Forms.TextBox();
            this.BtnDisconnect = new System.Windows.Forms.Button();
            this.LblAddress = new System.Windows.Forms.Label();
            this.IOConnectionState = new System.Windows.Forms.PictureBox();
            this.S7Agent_StatusStrip = new System.Windows.Forms.StatusStrip();
            this.Time = new System.Windows.Forms.ToolStripStatusLabel();
            this.PLCStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.LblDB = new System.Windows.Forms.Label();
            this.IODB = new System.Windows.Forms.NumericUpDown();
            this.IOValues = new System.Windows.Forms.NumericUpDown();
            this.LblValues = new System.Windows.Forms.Label();
            this.IODBSize = new System.Windows.Forms.TextBox();
            this.LblDBSize = new System.Windows.Forms.Label();
            this.IOFamily = new System.Windows.Forms.ComboBox();
            this.GbPLC = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.S7Agent_MainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IOConnectionState)).BeginInit();
            this.S7Agent_StatusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IODB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IOValues)).BeginInit();
            this.GbPLC.SuspendLayout();
            this.SuspendLayout();
            // 
            // S7Agent_MainMenu
            // 
            this.S7Agent_MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.S7Agent_MainMenu_FileItem});
            this.S7Agent_MainMenu.Location = new System.Drawing.Point(0, 0);
            this.S7Agent_MainMenu.Name = "S7Agent_MainMenu";
            this.S7Agent_MainMenu.Size = new System.Drawing.Size(604, 24);
            this.S7Agent_MainMenu.TabIndex = 0;
            this.S7Agent_MainMenu.Text = "S7Agent_MainMenu";
            // 
            // S7Agent_MainMenu_FileItem
            // 
            this.S7Agent_MainMenu_FileItem.Name = "S7Agent_MainMenu_FileItem";
            this.S7Agent_MainMenu_FileItem.Size = new System.Drawing.Size(37, 20);
            this.S7Agent_MainMenu_FileItem.Text = "File";
            // 
            // BtnConnect
            // 
            this.BtnConnect.Location = new System.Drawing.Point(240, 44);
            this.BtnConnect.Name = "BtnConnect";
            this.BtnConnect.Size = new System.Drawing.Size(111, 23);
            this.BtnConnect.TabIndex = 2;
            this.BtnConnect.Text = "Spoji se";
            this.BtnConnect.UseVisualStyleBackColor = true;
            this.BtnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // IOAddress
            // 
            this.IOAddress.Location = new System.Drawing.Point(6, 45);
            this.IOAddress.Name = "IOAddress";
            this.IOAddress.Size = new System.Drawing.Size(111, 23);
            this.IOAddress.TabIndex = 1;
            this.IOAddress.Text = "192.168.7.141";
            // 
            // BtnDisconnect
            // 
            this.BtnDisconnect.Location = new System.Drawing.Point(357, 44);
            this.BtnDisconnect.Name = "BtnDisconnect";
            this.BtnDisconnect.Size = new System.Drawing.Size(111, 23);
            this.BtnDisconnect.TabIndex = 3;
            this.BtnDisconnect.Text = "Odspoji se";
            this.BtnDisconnect.UseVisualStyleBackColor = true;
            this.BtnDisconnect.Click += new System.EventHandler(this.BtnDisconnect_Click);
            // 
            // LblAddress
            // 
            this.LblAddress.AutoSize = true;
            this.LblAddress.Location = new System.Drawing.Point(6, 27);
            this.LblAddress.Name = "LblAddress";
            this.LblAddress.Size = new System.Drawing.Size(89, 15);
            this.LblAddress.TabIndex = 4;
            this.LblAddress.Text = "IP adresa PLC-a";
            // 
            // IOConnectionState
            // 
            this.IOConnectionState.Image = global::S7Agent.Properties.Resources.ImgTransparent;
            this.IOConnectionState.Location = new System.Drawing.Point(474, 44);
            this.IOConnectionState.Name = "IOConnectionState";
            this.IOConnectionState.Size = new System.Drawing.Size(23, 23);
            this.IOConnectionState.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.IOConnectionState.TabIndex = 5;
            this.IOConnectionState.TabStop = false;
            // 
            // S7Agent_StatusStrip
            // 
            this.S7Agent_StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Time,
            this.PLCStatus});
            this.S7Agent_StatusStrip.Location = new System.Drawing.Point(0, 384);
            this.S7Agent_StatusStrip.Name = "S7Agent_StatusStrip";
            this.S7Agent_StatusStrip.Size = new System.Drawing.Size(604, 22);
            this.S7Agent_StatusStrip.TabIndex = 6;
            this.S7Agent_StatusStrip.Text = "Neki tekst";
            // 
            // Time
            // 
            this.Time.Name = "Time";
            this.Time.Size = new System.Drawing.Size(128, 17);
            this.Time.Text = "dd.mm.yyyy hh:mm:ss";
            // 
            // PLCStatus
            // 
            this.PLCStatus.Name = "PLCStatus";
            this.PLCStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // LblDB
            // 
            this.LblDB.AutoSize = true;
            this.LblDB.Location = new System.Drawing.Point(6, 71);
            this.LblDB.Name = "LblDB";
            this.LblDB.Size = new System.Drawing.Size(86, 15);
            this.LblDB.TabIndex = 7;
            this.LblDB.Text = "DB s podacima";
            // 
            // IODB
            // 
            this.IODB.Location = new System.Drawing.Point(6, 89);
            this.IODB.Name = "IODB";
            this.IODB.Size = new System.Drawing.Size(111, 23);
            this.IODB.TabIndex = 9;
            this.IODB.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // IOValues
            // 
            this.IOValues.Location = new System.Drawing.Point(123, 89);
            this.IOValues.Name = "IOValues";
            this.IOValues.Size = new System.Drawing.Size(111, 23);
            this.IOValues.TabIndex = 10;
            this.IOValues.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // LblValues
            // 
            this.LblValues.AutoSize = true;
            this.LblValues.Location = new System.Drawing.Point(123, 71);
            this.LblValues.Name = "LblValues";
            this.LblValues.Size = new System.Drawing.Size(101, 15);
            this.LblValues.TabIndex = 11;
            this.LblValues.Text = "Ukupno podataka";
            // 
            // IODBSize
            // 
            this.IODBSize.Enabled = false;
            this.IODBSize.Location = new System.Drawing.Point(240, 89);
            this.IODBSize.Name = "IODBSize";
            this.IODBSize.Size = new System.Drawing.Size(111, 23);
            this.IODBSize.TabIndex = 12;
            // 
            // LblDBSize
            // 
            this.LblDBSize.AutoSize = true;
            this.LblDBSize.Location = new System.Drawing.Point(240, 71);
            this.LblDBSize.Name = "LblDBSize";
            this.LblDBSize.Size = new System.Drawing.Size(88, 15);
            this.LblDBSize.TabIndex = 13;
            this.LblDBSize.Text = "Dimenzije DB-a";
            // 
            // IOFamily
            // 
            this.IOFamily.FormattingEnabled = true;
            this.IOFamily.Items.AddRange(new object[] {
            "S7-1200",
            "S7-1500",
            "S7-300",
            "S7-400"});
            this.IOFamily.Location = new System.Drawing.Point(123, 44);
            this.IOFamily.Name = "IOFamily";
            this.IOFamily.Size = new System.Drawing.Size(111, 23);
            this.IOFamily.TabIndex = 14;
            // 
            // GbPLC
            // 
            this.GbPLC.Controls.Add(this.IOAddress);
            this.GbPLC.Controls.Add(this.IOFamily);
            this.GbPLC.Controls.Add(this.BtnConnect);
            this.GbPLC.Controls.Add(this.LblDBSize);
            this.GbPLC.Controls.Add(this.BtnDisconnect);
            this.GbPLC.Controls.Add(this.IODBSize);
            this.GbPLC.Controls.Add(this.LblAddress);
            this.GbPLC.Controls.Add(this.LblValues);
            this.GbPLC.Controls.Add(this.IOConnectionState);
            this.GbPLC.Controls.Add(this.IOValues);
            this.GbPLC.Controls.Add(this.LblDB);
            this.GbPLC.Controls.Add(this.IODB);
            this.GbPLC.Location = new System.Drawing.Point(12, 27);
            this.GbPLC.Name = "GbPLC";
            this.GbPLC.Size = new System.Drawing.Size(584, 135);
            this.GbPLC.TabIndex = 15;
            this.GbPLC.TabStop = false;
            this.GbPLC.Text = "Parametri PLC konekcije";
            // 
            // groupBox1
            // 
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(12, 168);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(584, 205);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parametri izvještaja";
            // 
            // S7Agent_FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 406);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GbPLC);
            this.Controls.Add(this.S7Agent_StatusStrip);
            this.Controls.Add(this.S7Agent_MainMenu);
            this.MainMenuStrip = this.S7Agent_MainMenu;
            this.Name = "S7Agent_FrmMain";
            this.Text = "ATO S7 Agent";
            this.S7Agent_MainMenu.ResumeLayout(false);
            this.S7Agent_MainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IOConnectionState)).EndInit();
            this.S7Agent_StatusStrip.ResumeLayout(false);
            this.S7Agent_StatusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IODB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IOValues)).EndInit();
            this.GbPLC.ResumeLayout(false);
            this.GbPLC.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip S7Agent_MainMenu;
        private System.Windows.Forms.ToolStripMenuItem S7Agent_MainMenu_FileItem;
        private System.Windows.Forms.Button BtnConnect;
        private System.Windows.Forms.TextBox IOAddress;
        private System.Windows.Forms.Button BtnDisconnect;
        private System.Windows.Forms.Label LblAddress;
        private System.Windows.Forms.PictureBox IOConnectionState;
        private System.Windows.Forms.StatusStrip S7Agent_StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel Time;
        private System.Windows.Forms.Label LblDB;
        private System.Windows.Forms.NumericUpDown IODB;
        private System.Windows.Forms.NumericUpDown IOValues;
        private System.Windows.Forms.Label LblValues;
        private System.Windows.Forms.TextBox IODBSize;
        private System.Windows.Forms.Label LblDBSize;
        private System.Windows.Forms.ToolStripStatusLabel PLCStatus;
        private System.Windows.Forms.ComboBox IOFamily;
        private System.Windows.Forms.GroupBox GbPLC;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

