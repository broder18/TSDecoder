namespace GraphSample
{
    partial class MainForm
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

        private void SavePosition()
        {
            Properties.Settings.Default.WindowSize = this.Size;
            Properties.Settings.Default.WindowLocation = this.Location;
            SaveSettings();
        }

        private void SaveAddress()
        {
            Properties.Settings.Default.IP_address = textBox_IP.Text;
            Properties.Settings.Default.Port_address = System.UInt16.Parse(textBox_Port.Text);
            SaveSettings();
        }

        private void SaveSettings()
        {
            Properties.Settings.Default.Save();
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.StatisticsList = new System.Windows.Forms.ListView();
            this.columnPid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnBPS = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statsTimer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_IP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_Port = new System.Windows.Forms.TextBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.columnSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // StatisticsList
            // 
            this.StatisticsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnPid,
            this.columnCount,
            this.columnBPS,
            this.columnSize});
            this.StatisticsList.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StatisticsList.FullRowSelect = true;
            this.StatisticsList.GridLines = true;
            this.StatisticsList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.StatisticsList.HideSelection = false;
            this.StatisticsList.Location = new System.Drawing.Point(0, 97);
            this.StatisticsList.MultiSelect = false;
            this.StatisticsList.Name = "StatisticsList";
            this.StatisticsList.ShowGroups = false;
            this.StatisticsList.Size = new System.Drawing.Size(485, 153);
            this.StatisticsList.TabIndex = 0;
            this.StatisticsList.UseCompatibleStateImageBehavior = false;
            this.StatisticsList.View = System.Windows.Forms.View.Details;
            // 
            // columnPid
            // 
            this.columnPid.Text = "PID";
            this.columnPid.Width = 70;
            // 
            // columnCount
            // 
            this.columnCount.Text = "Count";
            this.columnCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnCount.Width = 110;
            // 
            // columnBPS
            // 
            this.columnBPS.Text = "Bitrate, MBPS";
            this.columnBPS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnBPS.Width = 150;
            // 
            // statsTimer
            // 
            this.statsTimer.Interval = 1000;
            this.statsTimer.Tick += new System.EventHandler(this.statsTimer_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(182, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "IP address: ";
            // 
            // textBox_IP
            // 
            this.textBox_IP.Location = new System.Drawing.Point(334, 12);
            this.textBox_IP.Name = "textBox_IP";
            this.textBox_IP.Size = new System.Drawing.Size(138, 20);
            this.textBox_IP.TabIndex = 2;
            this.textBox_IP.Text = global::GraphSample.Properties.Settings.Default.IP_address;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(182, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Port address:";
            // 
            // textBox_Port
            // 
            this.textBox_Port.Location = new System.Drawing.Point(334, 38);
            this.textBox_Port.Name = "textBox_Port";
            this.textBox_Port.Size = new System.Drawing.Size(138, 20);
            this.textBox_Port.TabIndex = 4;
            this.textBox_Port.Text = "1234";
            // 
            // buttonConnect
            // 
            this.buttonConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonConnect.Location = new System.Drawing.Point(334, 64);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(138, 27);
            this.buttonConnect.TabIndex = 5;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // columnSize
            // 
            this.columnSize.Text = "Renderer Size";
            this.columnSize.Width = 150;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 251);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.textBox_Port);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_IP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StatisticsList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Location = global::GraphSample.Properties.Settings.Default.WindowLocation;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(250, 250);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Graph Sample";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ColumnHeader columnPid;
        private System.Windows.Forms.ColumnHeader columnBPS;
        private System.Windows.Forms.ColumnHeader columnCount;
        private System.Windows.Forms.Timer statsTimer;
        private System.Windows.Forms.ListView StatisticsList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_IP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_Port;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.ColumnHeader columnSize;
    }
}

